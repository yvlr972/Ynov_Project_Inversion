using UnityEngine;
using System.Collections;

public class DestroyRoad : MonoBehaviour
{
    public bool isClone = false; // Ajout d'un booléen pour vérifier si l'objet est un clone
    public float lifetime = 35f;

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
            Destroy(gameObject);
        }
    }
}

