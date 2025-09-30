using UnityEngine;

public class CarMoveRight : MonoBehaviour
{
    private Vector3 _initPos = Vector3.zero;
    private Vector3 _newPos = Vector3.right;

    private float _speed = 5f;

    public void Update()
    {
        transform.position +=  _newPos * _speed * Time.deltaTime;

    }

    public void ResetCarPos()
    {
        transform.position = _initPos;
    }
}
