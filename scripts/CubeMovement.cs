using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Leer el input del teclado
        float moveX = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        float moveZ = Input.GetAxis("Vertical");   // W/S o flechas arriba/abajo

        // Crear vector de movimiento
        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed;

        // Aplicar movimiento
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }
}
