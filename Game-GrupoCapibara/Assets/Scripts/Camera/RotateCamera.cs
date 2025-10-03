using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private string _frontCommand = "mirar frente";
    private string _rightCommand = "mirar derecha";
    private string _leftCommand = "mirar izquierda";

    private Vector3 _targetDirection = Vector3.forward;
    private float _speed = 20f;   
    
    private VoiceRecognizer _voiceRecognizer;

    void Awake()
    {
        _voiceRecognizer = GetComponent<VoiceRecognizer>();

        _voiceRecognizer.AddCommand(_frontCommand, () =>
        {
            _targetDirection = Vector3.forward;

            Debug.Log(_frontCommand);

        });
        _voiceRecognizer.AddCommand(_rightCommand, () =>
        {
            _targetDirection = Vector3.right;

            Debug.Log(_rightCommand);

        });
        _voiceRecognizer.AddCommand(_leftCommand, () =>
        {
            _targetDirection = Vector3.left;

            Debug.Log(_leftCommand);

        });
    }


    void Update()
    {
        if (_targetDirection != Vector3.zero)
        {
            // rotacion interpolada
            // Quaternion targetRotation = Quaternion.LookRotation(_targetDirection, Vector3.up);
             //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _speed * Time.deltaTime);
            
            // rotacion instantanea
            Quaternion targetRotation = Quaternion.LookRotation(_targetDirection, Vector3.up);
            transform.rotation = targetRotation;

        }
    }
}
