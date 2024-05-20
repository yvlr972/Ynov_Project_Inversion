using UnityEngine;

public class PlayerTriggerBox : MonoBehaviour
{
    public GameObject[] roadSections; // Tableau des préfabriqués de sections de route
    private float roadLength = 200;
    private bool hasSpawned = false; // Ajout d'un booléen pour vérifier si une nouvelle section de route a déjà été créée
    private GameObject lastRoadSection; // Référence à la dernière section de route créée

    private void Start()
    {
        // Initialiser la dernière section de route avec la première section de route
        lastRoadSection = roadSections[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerBox") && !hasSpawned)
        {
            // Sélectionner un préfabriqué de section de route aléatoire
            GameObject roadSection = roadSections[Random.Range(0, roadSections.Length)];
            if (lastRoadSection != null)
            {
                // Obtenir la position de la dernière section de route
                Vector3 lastRoadSectionPosition = lastRoadSection.transform.position;

                // Créer la nouvelle section de route à la fin de la dernière section de route
                Vector3 newRoadSectionPosition = new Vector3(lastRoadSectionPosition.x, lastRoadSectionPosition.y, lastRoadSectionPosition.z + roadLength);
                lastRoadSection = Instantiate(roadSection, newRoadSectionPosition, Quaternion.identity);
                lastRoadSection.GetComponent<DestroyRoad>().isClone = true;
                hasSpawned = true; // Une nouvelle section de route a été créée
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerBox"))
        {
            hasSpawned = false; // Réinitialiser le booléen lorsque la voiture quitte le déclencheur
        }
    }
}
