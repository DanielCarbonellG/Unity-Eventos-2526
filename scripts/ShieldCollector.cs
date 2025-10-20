using UnityEngine;
using TMPro;

public class ShieldCollector : MonoBehaviour
{
    private int puntuacion = 0;
    private int siguienteRecompensa = 100; // primera recompensa a 100 puntos

    [Header("UI")]
    public TMP_Text textoPuntuacion;   // arrastrar el TMP Text que muestra la puntuación
    public TMP_Text textoRecompensa;   // arrastrar el TMP Text que mostrará la recompensa (inactivo al inicio)

    [Header("Recompensa (opcional)")]
    public float duracionRecompensa = 2f; // tiempo en segundos que se muestra el mensaje
    // public GameObject prefabRecompensa; // opcional: spawnar un prefab visual (si quieres)

    private void Start()
    {
        ActualizarUI();
        if (textoRecompensa != null)
            textoRecompensa.gameObject.SetActive(false); // asegurar que esté oculto al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        // Asegúrate de que tus escudos tengan los tags "Escudo1" y "Escudo2"
        if (other.CompareTag("Escudo1"))
        {
            puntuacion += 5;
            Debug.Log("Recolectaste un Escudo Tipo1! Puntuación: " + puntuacion);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Escudo2"))
        {
            puntuacion += 10;
            Debug.Log("Recolectaste un Escudo Tipo2! Puntuación: " + puntuacion);
            Destroy(other.gameObject);
        }
        else
        {
            // no es un escudo → no hacemos nada
            return;
        }

        ActualizarUI();

        // comprobar si hemos alcanzado o superado la próxima recompensa
        while (puntuacion >= siguienteRecompensa)
        {
            // mostrar la recompensa por cada umbral alcanzado
            MostrarRecompensa();
            siguienteRecompensa += 100; // siguiente umbral (200, 300, ...)
        }
    }

    private void ActualizarUI()
    {
        if (textoPuntuacion != null)
            textoPuntuacion.text = "Puntuación: " + puntuacion;
    }

    private void MostrarRecompensa()
    {
        if (textoRecompensa == null)
        {
            Debug.Log("Recompensa! (pero no hay texto de recompensa asignado).");
            return;
        }

        textoRecompensa.gameObject.SetActive(true);
        textoRecompensa.text = "🎉 ¡Recompensa obtenida! 🎁";

        CancelInvoke(nameof(OcultarRecompensa)); // evitar múltiples invokes solapados
        Invoke(nameof(OcultarRecompensa), duracionRecompensa);
    }

    private void OcultarRecompensa()
    {
        if (textoRecompensa != null)
            textoRecompensa.gameObject.SetActive(false);
    }
}
