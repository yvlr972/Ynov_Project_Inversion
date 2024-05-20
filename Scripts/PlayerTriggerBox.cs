using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerBox : MonoBehaviour
{
    public GameObject roadSection;
    private float roadLength = 200; // La longueur de la section de route

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerBox"))
        {
            // Obtenir la position de la dernière section de route
            Vector3 lastRoadSectionPosition = roadSection.transform.position;

            // Créez la nouvelle section de route à la fin de la dernière section de route
            Vector3 newRoadSectionPosition = new Vector3(lastRoadSectionPosition.x, lastRoadSectionPosition.y, lastRoadSectionPosition.z + roadLength);
            Instantiate(roadSection, newRoadSectionPosition, Quaternion.identity);
        }
    }
}
