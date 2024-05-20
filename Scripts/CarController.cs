using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 50.0f;
    public float gravity = -9.8f;
    private Vector3 velocity;

    void Update()
    {
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Appliquer la gravité
        velocity.y += gravity * Time.deltaTime;

        // Raycast vers le bas
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            // Aligner la voiture avec la surface
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            // Si la voiture est proche du sol, annuler la gravité
            if (hit.distance < 1.0f)
            {
                velocity.y = 0;
            }
        }

        // Déplacer la voiture
        transform.Translate(0, 0, move);
        transform.Translate(velocity * Time.deltaTime);
    }
}
