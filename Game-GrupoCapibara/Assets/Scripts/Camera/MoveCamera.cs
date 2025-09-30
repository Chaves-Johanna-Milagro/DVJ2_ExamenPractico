using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private string _walkCommand = "caminar";
    private string _stopCommand = "parar";

    private Vector3 _direction = Vector3.forward;
    private float _speed = 8f;

    private bool _isWalking = false;

    private VoiceRecognizer _voiceRecognizer;

    
    void Awake()
    {
        _voiceRecognizer = GetComponent<VoiceRecognizer>();

        _voiceRecognizer.AddCommand(_walkCommand, () =>
        {
            _isWalking = true;

            Debug.Log(_walkCommand);
        });

        _voiceRecognizer.AddCommand(_stopCommand, () =>
        {
            _isWalking = false;

            Debug.Log(_stopCommand);
        });

    }

    void Update()
    {
        if (_isWalking)
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }
    }
}
