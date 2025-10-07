using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour //manejara las colisiones
{
    private Victory _victory;

    private void Start()
    {
        _victory = Object.FindFirstObjectByType<Victory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Meta")
        {
            Debug.Log("Victoria");
            //SceneManager.LoadScene("Victory");
            _victory.WinGame();
        }
        else
        {
            Debug.Log("Chocado");
            SceneManager.LoadScene("GameOver");
        }

    }
}
