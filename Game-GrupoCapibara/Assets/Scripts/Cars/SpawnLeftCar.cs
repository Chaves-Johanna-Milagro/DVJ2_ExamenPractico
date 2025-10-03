using System.Collections;
using UnityEngine;

public class SpawnLeftCar : MonoBehaviour //spawn de autos que van hacia la izquierda
{
    private CarPooler _carPooler;

    private float _minDelay = 3f;
    private float _maxDelay = 5f;

    private float _timeLifeCar = 15f;

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
        yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));

        while (true)
        {
            Vector3 pos = transform.position;

            GameObject newCar = _carPooler.GetCar();

            if (newCar != null)
            {
                newCar.transform.position = pos;
                newCar.transform.rotation = Quaternion.identity;

                // añade el movimiento
                MoveLeft movement = newCar.GetComponent<MoveLeft>();
                if (movement == null)
                {
                    movement = newCar.AddComponent<MoveLeft>();
                }

                // devolver el auto al pool
                StartCoroutine(ReturnCar(newCar));
            }

            yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        }
    }

    private IEnumerator ReturnCar(GameObject car)
    {
        yield return new WaitForSeconds(_timeLifeCar);

        // Quitar movimiento
        MoveLeft movement = car.GetComponent<MoveLeft>();
        if (movement != null)
        {
            Destroy(movement);
        }

        // Devolver al pool
        _carPooler.ReturnCar(car);
    }


}
