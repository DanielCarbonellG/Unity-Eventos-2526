using UnityEngine;
using System;

public class CylinderCollision : MonoBehaviour
{
    public static event Action OnCylinderCollided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cube"))
        {
            Debug.Log("El cubo ha colisionado con el cilindro");
            OnCylinderCollided?.Invoke();
        }
    }
}
