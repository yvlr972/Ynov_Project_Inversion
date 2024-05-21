using UnityEngine;

public class MeasureLength : MonoBehaviour
{
    void Start()
    {
        // Obtenez tous les rendus enfants de cet objet
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        // Calculez la bounding box combinée de tous les rendus
        Bounds bounds = new Bounds(transform.position, Vector3.zero);
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }

        // La longueur de la route sur l'axe Z
        float roadLength = bounds.size.z;
        Debug.Log("La longueur de la section de route est: " + roadLength);
    }
}
