using UnityEngine;
using System;

public class CubeCollision : MonoBehaviour
{
    public static event Action<string> OnHumanoidCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Tipo1"))
        {
            Debug.Log("Cubo tocó humanoide Tipo1");
            OnHumanoidCollision?.Invoke("Tipo1");
        }
        else if (collision.collider.CompareTag("Tipo2"))
        {
            Debug.Log("Cubo tocó humanoide Tipo2");
            OnHumanoidCollision?.Invoke("Tipo2");
        }
    }
}
