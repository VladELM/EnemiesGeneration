using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _timeDelay = 2;
    [SerializeField] List<SpawnPoint> _spawnPoints;
    [SerializeField] private int _minAngle = -180;
    [SerializeField] private int _maxAngle = 180;

    [SerializeField] private int _minCoordinateValue;
    [SerializeField] private int _maxCoordinateValue;


    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void GenerateEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.Initialize(GetSpawnPosiiton(), GetRandomDirection(enemy.transform.position.y));
    }

    private Vector3 GetRandomDirection(float positionY)
    {
        int positionX = Random.Range(_minCoordinateValue, _maxCoordinateValue);
        int positionZ = Random.Range(_minCoordinateValue, _maxCoordinateValue);

        return new Vector3(positionX, positionY, positionZ);
    }

    private Vector3 GetSpawnPosiiton()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count-1);
        return _spawnPoints[randomIndex].transform.position;
    }

    private int GetRandomRotationAngle()
    {
        return Random.Range(_minAngle, _maxAngle);
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds interval = new WaitForSeconds(_timeDelay);

        while (enabled)
        {
            yield return interval;
            GenerateEnemy();
        }
    }
}
