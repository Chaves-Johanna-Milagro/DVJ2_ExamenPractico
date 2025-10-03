using System.Collections.Generic;
using UnityEngine;

public class CarPooler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _carPrefabs;
    [SerializeField] private int _poolSize = 20;

    private Queue<GameObject> _carPool = new Queue<GameObject>();

    private void Awake()
    {
        FillPool();
    }

    private void FillPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            // Selecciona un prefab aleatorio de la lista
            GameObject randomPrefab = _carPrefabs[Random.Range(0, _carPrefabs.Count)];

            GameObject obj = Instantiate(randomPrefab, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            _carPool.Enqueue(obj);
        }
    }

    public GameObject GetCar()
    {
        if (_carPool.Count == 0)
        {
            // Si se acaba, instanciamos uno nuevo aleatorio
            GameObject randomPrefab = _carPrefabs[Random.Range(0, _carPrefabs.Count)];
            GameObject extra = Instantiate(randomPrefab);
            extra.transform.SetParent(transform);
            extra.SetActive(false);
            _carPool.Enqueue(extra);
        }

        GameObject car = _carPool.Dequeue();
        car.SetActive(true);
        return car;
    }

    public void ReturnCar(GameObject car)
    {
        car.SetActive(false);
        _carPool.Enqueue(car);
    }

}
