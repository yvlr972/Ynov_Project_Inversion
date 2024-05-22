using UnityEngine;

public class CarColorChange : MonoBehaviour
{
    public KeyCode changeColorKey = KeyCode.C; // Touche pour changer de couleur
    public Color whiteColor = Color.white; // Couleur blanche
    public Color blackColor = Color.black; // Couleur noire

    private bool isWhite = true; // Variable pour suivre la couleur actuelle du joueur
    private MeshRenderer[] carRenderers; // R�f�rences aux MeshRenderers de la voiture
    private Color[] originalColors; // Couleurs originales des mat�riaux de la voiture
    private PlayerDeath playerDeath; // R�f�rence au script PlayerDeath

    private void Start()
    {
        // R�cup�rer tous les MeshRenderers des enfants de la voiture
        carRenderers = GetComponentsInChildren<MeshRenderer>();
        if (carRenderers.Length == 0)
        {
            Debug.LogError("No MeshRenderers found on the car.");
        }
        else
        {
            // M�moriser les couleurs originales des mat�riaux
            originalColors = new Color[carRenderers.Length];
            for (int i = 0; i < carRenderers.Length; i++)
            {
                originalColors[i] = carRenderers[i].material.color;
            }

            // Initialiser la voiture en blanc
            ChangeColor();
        }

        // R�cup�rer la r�f�rence au script PlayerDeath
        playerDeath = FindObjectOfType<PlayerDeath>();
    }

    private void Update()
    {
        // Changer la couleur lorsque la touche sp�cifi�e est enfonc�e
        if (Input.GetKeyDown(changeColorKey))
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        isWhite = !isWhite; // Inverser la couleur actuelle

        // Changer la couleur de tous les MeshRenderers de la voiture en fonction de la couleur actuelle
        foreach (MeshRenderer renderer in carRenderers)
        {
            renderer.material.color = isWhite ? whiteColor : blackColor;
        }

        // Mettre � jour le tag du GameObject principal
        gameObject.tag = isWhite ? "WhiteCar" : "BlackCar";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isWhite)
        {
            // Si la voiture est blanche et touche un obstacle blanc, ignorer la collision
            if (other.CompareTag("WhiteObstacle"))
            {
                Physics.IgnoreCollision(other, GetComponent<Collider>());
            }
            // Si la voiture est blanche et touche un obstacle noir, le joueur meurt
            else if (other.CompareTag("BlackObstacle"))
            {
                playerDeath.Die();
            }
        }
        else // Si la voiture est noire
        {
            // Si la voiture est noire et touche un obstacle noir, ignorer la collision
            if (other.CompareTag("BlackObstacle"))
            {
                Physics.IgnoreCollision(other, GetComponent<Collider>());
            }
            // Si la voiture est noire et touche un obstacle blanc, le joueur meurt
            else if (other.CompareTag("WhiteObstacle"))
            {
                playerDeath.Die();
            }
        }
    }

}

