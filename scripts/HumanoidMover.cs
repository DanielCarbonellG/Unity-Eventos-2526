using UnityEngine;

public class HumanoidMover : MonoBehaviour
{
    public string tipo; // "Tipo1" o "Tipo2"
    public Transform objetivoTipo1; // destino para tipo1
    public Transform objetivoTipo2; // destino para tipo2
    public float velocidad = 3f;

    private bool mover = false;

    private void OnEnable()
    {
        CubeCollision.OnHumanoidCollision += ActivarMovimiento;
    }

    private void OnDisable()
    {
        CubeCollision.OnHumanoidCollision -= ActivarMovimiento;
    }

    void ActivarMovimiento(string tipoHumanoide)
    {
        // Cuando cubo toca humanoide Tipo2, los Tipo1 se mueven
        if (tipo == "Tipo1" && tipoHumanoide == "Tipo2")
            mover = true;

        // Cuando cubo toca humanoide Tipo1, los Tipo2 se mueven
        if (tipo == "Tipo2" && tipoHumanoide == "Tipo1")
            mover = true;
    }

    void Update()
    {
        if (!mover) return;

        Transform destino = tipo == "Tipo1" ? objetivoTipo1 : objetivoTipo2;
        if (destino != null)
        {
            Vector3 nuevaPos = Vector3.MoveTowards(transform.position, destino.position, velocidad * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(nuevaPos);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Cambiar color si choca con un escudo
        if (collision.gameObject.CompareTag("Escudo"))
        {
            GetComponent<Renderer>().material.color = Color.yellow; // ejemplo
        }
    }
}
