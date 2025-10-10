using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Victory : MonoBehaviour
{
    private Button _menu;
    private Button _restart;
   
    private Timer _timer;

    private TMP_Text _timeText;
    private TMP_Text _titleText;

    private bool _isWin = false;

    private GameObject[] _childs;
    private int _count = 0;

    void Start()
    {
        _count = transform.childCount;
        _childs = new GameObject[_count];

        SetStateChilds(false); //desactivamos a los hijos al inicio

        _timer = Object.FindFirstObjectByType<Timer>();

        _timeText = transform.Find("TTime").GetComponent<TMP_Text>();
        _titleText = transform.Find("TTitle").GetComponent<TMP_Text>();

        _menu = transform.Find("BMenu").GetComponent<Button>();
        _restart = transform.Find("BRestart").GetComponent<Button>();

        _menu.onClick.AddListener(Menu);
        _restart.onClick.AddListener(Restart);
    }

    private void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    private void Restart()
    {
        SceneManager.LoadScene("Level");
    }
    public void WinGame()
    {
        _isWin = true;
        SetStateChilds(_isWin);

        _timeText.text = _timer.StopTimer();

        _titleText.text = GetTitleByTime(_timer.TimeTotal());
    }

    // Cambia el texto según el tiempo final
    private string GetTitleByTime(float time)
    {

        if (time < 20f)
        {
            return "Rápido";
        }
        if (time < 40f)
        {
            return "Normal";
        }
        if (time < 60f)
        {
            return "Tortuga";
        }
        else
        {
            return "Caracol!";
        }
    }


    private void SetStateChilds(bool state)
    {
        for (int i = 0; i < _count; i++)
        {
            _childs[i] = transform.GetChild(i).gameObject;
            _childs[i].SetActive(state);
        }
    }

    public bool PlayerWin()
    {
        return _isWin;
    }
}
