using UnityEngine;

public class CubeProximity : MonoBehaviour
{
    [Header("Referencias")]
    public Transform cilindro;         // Cilindro de referencia
    public Transform escudoTipo1;      // Escudo destino para humanoides Tipo1
    public Transform orientadorTipo2;  // Objeto hacia el que se orientan humanoides Tipo2

    [Header("Configuración")]
    public float distanciaActivacion = 5f; // Distancia para activar la acción
    private bool accionRealizada = false;  // Para que solo ocurra una vez

    private void Update()
    {
        if (accionRealizada) return;

        // Calcula la distancia del cubo al cilindro
        float distancia = Vector3.Distance(transform.position, cilindro.position);

        if (distancia <= distanciaActivacion)
        {
            // Encuentra todos los humanoides de la escena
            HumanoidMover[] humanoides = FindObjectsOfType<HumanoidMover>();

            foreach (HumanoidMover h in humanoides)
            {
                if (h.tipo == "Tipo1")
                {
                    // Teletransportación segura usando Rigidbody
                    Rigidbody rb = h.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;                  // Desactiva física
                        // Pequeño offset para que no se superpongan
                        Vector3 offset = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
                        h.transform.position = escudoTipo1.position + offset; 
                        rb.isKinematic = false;                 // Reactiva física
                    }
                    else
                    {
                        h.transform.position = escudoTipo1.position;
                    }
                }
                else if (h.tipo == "Tipo2")
                {
                    // Orienta hacia el objetivo
                    Vector3 direccion = (orientadorTipo2.position - h.transform.position).normalized;
                    if (direccion != Vector3.zero)
                        h.transform.rotation = Quaternion.LookRotation(direccion);
                }
            }

            accionRealizada = true; // Solo se realiza una vez
        }
    }
}
