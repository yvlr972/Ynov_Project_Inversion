using UnityEngine;

public class PlayerTriggerBox : MonoBehaviour
{
    public GameObject[] roadSections; // Tableau des pr�fabriqu�s de sections de route
    private float roadLength = 200;
    private bool hasSpawned = false; // Ajout d'un bool�en pour v�rifier si une nouvelle section de route a d�j� �t� cr��e
    private GameObject lastRoadSection; // R�f�rence � la derni�re section de route cr��e

    private void Start()
    {
        // Initialiser la derni�re section de route avec la premi�re section de route
        lastRoadSection = roadSections[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerBox") && !hasSpawned)
        {
            // S�lectionner un pr�fabriqu� de section de route al�atoire
            GameObject roadSection = roadSections[Random.Range(0, roadSections.Length)];
            if (lastRoadSection != null)
            {
                // Obtenir la position de la derni�re section de route
                Vector3 lastRoadSectionPosition = lastRoadSection.transform.position;

                // Cr�er la nouvelle section de route � la fin de la derni�re section de route
                Vector3 newRoadSectionPosition = new Vector3(lastRoadSectionPosition.x, lastRoadSectionPosition.y, lastRoadSectionPosition.z + roadLength);
                lastRoadSection = Instantiate(roadSection, newRoadSectionPosition, Quaternion.identity);
                lastRoadSection.GetComponent<DestroyRoad>().isClone = true;
                hasSpawned = true; // Une nouvelle section de route a �t� cr��e
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerBox"))
        {
            hasSpawned = false; // R�initialiser le bool�en lorsque la voiture quitte le d�clencheur
        }
    }
}
