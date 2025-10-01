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

    private void Start()
    {
        // Busca el pooler en la escena
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
            Vector3 pos = transform.position;

            _spawnPos = new Vector3(pos.x, pos.y, pos.z + (i * _distanceZ));

            GameObject newCar = _carPooler.GetCar();

            if (newCar != null)
            {
                newCar.transform.position = _spawnPos;
                newCar.transform.rotation = Quaternion.identity;

                MoveLeft movement = newCar.GetComponent<MoveLeft>(); //le asignamos el movimineto al auto
                if (movement == null)
                {
                    movement = newCar.AddComponent<MoveLeft>();
                }

            }

            yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        }
    }


}
