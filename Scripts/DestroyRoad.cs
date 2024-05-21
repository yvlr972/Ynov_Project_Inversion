using UnityEngine;
using System.Collections;

public class DestroyRoad : MonoBehaviour
{
    public bool isClone = false; // Ajout d'un booléen pour vérifier si l'objet est un clone
    public float lifetime = 35f;
    public LayerMask playerLayer; // Layer du joueur

    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);

        // Vérifier si l'objet existe toujours et est un clone avant de le détruire
        if (this != null && isClone)
        {
            // Obtenir la position du joueur
            Vector3 playerPosition = GetPlayerPosition();

            // Effectuer un raycast vers le bas à partir de la position du joueur pour vérifier s'il est encore sur ce road
            RaycastHit hit;
            if (Physics.Raycast(playerPosition, Vector3.down, out hit, Mathf.Infinity, playerLayer))
            {
                // Si le joueur est toujours sur ce road, ne le détruis pas
                Debug.Log("Player is still on this road, not destroying.");
            }
            else
            {
                // Si le joueur n'est pas sur ce road, détruisez-le
                Destroy(gameObject);
            }
        }
    }

    private Vector3 GetPlayerPosition()
    {
        // Vous pouvez modifier cette méthode pour obtenir la position du joueur selon votre configuration de jeu
        // Par exemple, vous pouvez obtenir la position du GameObject du joueur, ou utiliser une référence au Transform du joueur
        // Pour l'exemple, je vais simplement renvoyer la position de cet objet
        return transform.position;
    }
}
