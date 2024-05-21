using UnityEngine;
using System.Collections;

public class DestroyRoad : MonoBehaviour
{
    public bool isClone = false; // Ajout d'un bool�en pour v�rifier si l'objet est un clone
    public float lifetime = 35f;
    public LayerMask playerLayer; // Layer du joueur

    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);

        // V�rifier si l'objet existe toujours et est un clone avant de le d�truire
        if (this != null && isClone)
        {
            // Obtenir la position du joueur
            Vector3 playerPosition = GetPlayerPosition();

            // Effectuer un raycast vers le bas � partir de la position du joueur pour v�rifier s'il est encore sur ce road
            RaycastHit hit;
            if (Physics.Raycast(playerPosition, Vector3.down, out hit, Mathf.Infinity, playerLayer))
            {
                // Si le joueur est toujours sur ce road, ne le d�truis pas
                Debug.Log("Player is still on this road, not destroying.");
            }
            else
            {
                // Si le joueur n'est pas sur ce road, d�truisez-le
                Destroy(gameObject);
            }
        }
    }

    private Vector3 GetPlayerPosition()
    {
        // Vous pouvez modifier cette m�thode pour obtenir la position du joueur selon votre configuration de jeu
        // Par exemple, vous pouvez obtenir la position du GameObject du joueur, ou utiliser une r�f�rence au Transform du joueur
        // Pour l'exemple, je vais simplement renvoyer la position de cet objet
        return transform.position;
    }
}
