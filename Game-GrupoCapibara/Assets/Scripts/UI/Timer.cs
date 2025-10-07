using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMP_Text _txtTime;

    private bool _running = true;
    private float _elapsed;
    
    void Start()
    {
        _txtTime = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (!_running) return;

        _elapsed += Time.deltaTime;
        DisplayTime(_elapsed);
    }

    private void DisplayTime(float timeToDisplay)
    {

        _txtTime.text = FormatTime(timeToDisplay);
    }

    public string StopTimer()
    {
        _running = false;
        return FormatTime(_elapsed);
    }

    // Convierte un tiempo float a formato "mm:ss:ms"
    private string FormatTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliSeconds = Mathf.FloorToInt((time * 100) % 100);

        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
    }
}
