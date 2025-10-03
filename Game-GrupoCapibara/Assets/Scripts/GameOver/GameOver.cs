using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    private Button _restart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _restart = transform.Find("Button").GetComponent<Button>();
        _restart.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        SceneManager.LoadScene("Level");
    }
}
