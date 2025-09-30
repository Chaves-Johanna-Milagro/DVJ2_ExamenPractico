using System.Collections;
using UnityEngine;

public class SpawnLeftCar : MonoBehaviour
{
    private CarPooler _carPooler;

    private Vector3 _spawnPos;

    private float _distanceZ = 3f;

    private float _minDelay = 0.2f;
    private float _maxDelay = 5f;

    private int _amount = 5;

    private string _typeMove = "left";

    private void Start()
    {
        // Busca el pooler en la escena (puede estar en un objeto vacío llamado "CarPoolManager")
        _carPooler = Object.FindFirstObjectByType<CarPooler>();

        if (_carPooler == null)
        {
            Debug.LogError("CarPooler not found in scene.");
            return;
        }

        StartCoroutine(GenerateCar());
    }

    private IEnumerator GenerateCar()
    {
        for (int i = 0; i < _amount; i++)
        {
            _spawnPos = new Vector3(transform.position.x, 0, i * _distanceZ);

            GameObject newCar = _carPooler.GetCar(_typeMove);

            if (newCar != null)
            {
                newCar.transform.position = _spawnPos;
                newCar.transform.rotation = Quaternion.identity;
            }

            yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        }
    }

}
