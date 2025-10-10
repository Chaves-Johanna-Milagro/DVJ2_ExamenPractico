using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private string _frontCommand = "mirar frente";
    private string _rightCommand = "mirar derecha";
    private string _leftCommand = "mirar izquierda";

    private Quaternion _targetDirection;
    private float _speed = 20f;   
    
    private VoiceRecognizer _voiceRecognizer;

    private Victory _victory;
    void Awake()
    {
        _voiceRecognizer = GetComponent<VoiceRecognizer>();

        _voiceRecognizer.AddCommand(_frontCommand, () =>
        {
            _targetDirection = Quaternion.Euler(0f, 0f, 0f);

            Debug.Log(_frontCommand);

        });
        _voiceRecognizer.AddCommand(_rightCommand, () =>
        {
            _targetDirection = Quaternion.Euler(0f, 45f, 0f);

            Debug.Log(_rightCommand);

        });
        _voiceRecognizer.AddCommand(_leftCommand, () =>
        {
            _targetDirection = Quaternion.Euler(0f, -45f, 0f);

            Debug.Log(_leftCommand);

        });

        _victory = Object.FindFirstObjectByType<Victory>();

    }


    void Update()
    {
        if (_victory.PlayerWin()) return;

        transform.rotation = Quaternion.Slerp(transform.rotation, _targetDirection, Time.deltaTime * _speed);
    }

}
