using UnityEngine;

public class CarMoveLeft : MonoBehaviour
{
    private Vector3 _initPos = Vector3.zero;
    private Vector3 _newPos = Vector3.left;

    private float _speed = 5f;

    public void Update()
    {
        transform.position += _newPos * _speed * Time.deltaTime;

    }

    public void ResetCarPos()
    {
        transform.position = _initPos;
    }
}
