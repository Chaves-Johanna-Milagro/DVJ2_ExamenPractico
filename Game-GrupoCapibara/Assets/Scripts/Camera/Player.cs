using UnityEngine;

public class Player : MonoBehaviour //manejara las colisiones
{
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Chocado");
    }
}
