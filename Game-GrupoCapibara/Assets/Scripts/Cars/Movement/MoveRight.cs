using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MoveRight : MonoBehaviour
{
    private float _speed = 5f;
    private Vector3 _direction = Vector3.right;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;

        if (_direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_direction);
        }
    }
}
