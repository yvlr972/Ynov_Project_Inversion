using UnityEngine;

public class CarColorChange : MonoBehaviour
{
    public KeyCode changeColorKey = KeyCode.C; // Touche pour changer de couleur
    public Color whiteColor = Color.white; // Couleur blanche
    public Color blackColor = Color.black; // Couleur noire

    private bool isWhite = true; // Variable pour suivre la couleur actuelle du joueur
    private Rigidbody rb; // Référence au Rigidbody du joueur

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Récupérer le Rigidbody du joueur
    }

    private void Update()
    {
        // Changer la couleur lorsque la touche spécifiée est enfoncée
        if (Input.GetKeyDown(changeColorKey))
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        isWhite = !isWhite; // Inverser la couleur actuelle

        // Changer la couleur du joueur en fonction de la couleur actuelle
        GetComponent<Renderer>().material.color = isWhite ? whiteColor : blackColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si la voiture est de la même couleur que l'obstacle
        if (other.CompareTag("Obstacle"))
        {
            Color obstacleColor = other.GetComponent<Renderer>().material.color;

            if ((isWhite && obstacleColor == whiteColor) || (!isWhite && obstacleColor == blackColor))
            {
                // Si la voiture est de la même couleur que l'obstacle, désactiver la collision avec l'obstacle
                Physics.IgnoreCollision(other, GetComponent<Collider>());
            }
        }
    }
}
