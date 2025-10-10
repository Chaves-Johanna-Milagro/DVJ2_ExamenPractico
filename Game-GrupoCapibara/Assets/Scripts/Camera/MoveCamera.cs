using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private string _walkCommand = "caminar";
    private string _stopCommand = "parar";
    private string _backCommand = "retroceder";

    private Vector3 _direction = Vector3.forward;
    private float _speed = 3f;

    private bool _isWalking = false;
    private bool _isBack = false;

    private VoiceRecognizer _voiceRecognizer;

    private Victory _victory;

    void Awake()
    {
        _voiceRecognizer = GetComponent<VoiceRecognizer>();

        _voiceRecognizer.AddCommand(_walkCommand, () =>
        {
            _isWalking = true;

            Debug.Log(_walkCommand);
        });

        _voiceRecognizer.AddCommand(_backCommand, () =>
        {
            _isBack = true;

            Debug.Log(_stopCommand);
        });

        _voiceRecognizer.AddCommand(_stopCommand, () =>
        {
            _isWalking = false;
            _isBack = false;

            Debug.Log(_stopCommand);
        });

        _victory = Object.FindFirstObjectByType<Victory>();

    }

    void Update()
    {
        if (_victory.PlayerWin()) return;

        if (_isWalking)
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }

        if (_isBack)
        {
            transform.position -= _direction * _speed * Time.deltaTime;
        }
    }
}
