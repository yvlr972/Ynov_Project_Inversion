using UnityEngine;
using System.Collections;

public class DestroyRoad : MonoBehaviour
{
    public bool isClone = false; // Ajout d'un bool�en pour v�rifier si l'objet est un clone
    public float lifetime = 35f;

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
            Destroy(gameObject);
        }
    }
}

