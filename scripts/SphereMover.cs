using UnityEngine;

public class SphereMover : MonoBehaviour
{
    public string tipo; // "Tipo1" o "Tipo2"
    public Transform objetivoTipo1; // destino para tipo1
    public Transform cilindro;      // destino para tipo2
    public float velocidad = 3f;

    private bool mover = false;

    private void OnEnable()
    {
        CylinderCollision.OnCylinderCollided += ActivarMovimiento;
    }

    private void OnDisable()
    {
        CylinderCollision.OnCylinderCollided -= ActivarMovimiento;
    }

    void ActivarMovimiento()
    {
        mover = true;
    }

    void Update()
    {
        if (!mover) return;

        if (tipo == "Tipo1" && objetivoTipo1 != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, objetivoTipo1.position, velocidad * Time.deltaTime);
        }
        else if (tipo == "Tipo2" && cilindro != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, cilindro.position, velocidad * Time.deltaTime);
        }
    }
}
