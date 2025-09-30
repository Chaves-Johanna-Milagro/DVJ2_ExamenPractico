using System.Collections.Generic;
using UnityEngine;

public class CarPooler : MonoBehaviour
{
    [SerializeField] private GameObject _carRightPrefab;
    [SerializeField] private GameObject _carLeftPrefab;
    [SerializeField] private int _poolSize = 10;

    private Queue<GameObject> _carRightPool = new Queue<GameObject>();
    private Queue<GameObject> _carLeftPool = new Queue<GameObject>();

    private string _rightCar = "right";
    private string _leftCar = "left";

    private void Awake()
    {
        FillPool(_carRightPrefab, _carRightPool);
        FillPool(_carLeftPrefab, _carLeftPool);
    }

    private void FillPool(GameObject prefab, Queue<GameObject> pool)
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(transform); // Organiza los autos como hijos del pooler
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetCar(string side)
    {
        Queue<GameObject> pool;
        GameObject prefab;

        if (side.ToLower() == _rightCar)
        {
            pool = _carRightPool;
            prefab = _carRightPrefab;

        }
        else if (side.ToLower() == _leftCar)
        {
            pool = _carLeftPool;
            prefab = _carLeftPrefab;

        }
        else
        {
            Debug.LogError($"Invalid side '{side}' passed to GetCar. Use 'right' or 'left'.");
            return null;
        }

        if (pool.Count == 0)
        {
            GameObject extra = Instantiate(prefab);
            extra.transform.SetParent(transform); // También para extras
            extra.SetActive(false);
            pool.Enqueue(extra);
        }

        GameObject car = pool.Dequeue();

        // Resetea la posicion de los autos
        if (side == _rightCar)
        {
            car.GetComponent<CarMoveRight>()?.ResetCarPos();
        }
        if (side == _leftCar)
        {
            car.GetComponent<CarMoveLeft>()?.ResetCarPos();
        }

        car.SetActive(true);
        return car;
    }

    public void ReturnCar(GameObject car, string side)
    {
        car.SetActive(false);
        Queue<GameObject> pool;

        if (side.ToLower() == _rightCar)
        {
            pool = _carRightPool;
        }
        else if (side.ToLower() == _leftCar)
        {
            pool = _carLeftPool;
        }
        else
        {
            Debug.LogError($"Invalid side '{side}' passed to ReturnCar. Use 'right' or 'left'.");
            return;
        }

        pool.Enqueue(car);
    }

}
