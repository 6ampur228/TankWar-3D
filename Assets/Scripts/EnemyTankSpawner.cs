using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankSpawner : MonoBehaviour
{
    [SerializeField] private EnemyTank _template;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject[] _spawnPoints;

    [SerializeField] private int _timeBetweenSpawn;

    private float _elapsedTime;

    private void Start()
    {
        _elapsedTime = _timeBetweenSpawn;

        _objectPool.Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenSpawn)
        {
            if (_objectPool.TryGetObject(out EnemyTank enemyTank))
            {
                int randomSpawnIndex = Random.Range(0, _spawnPoints.Length);

                Transform spawnPoint = _spawnPoints[randomSpawnIndex].transform;

                enemyTank.gameObject.SetActive(true);
                enemyTank.transform.position = spawnPoint.position;
                enemyTank.GetComponent<EnemyTankTurret>().SetTarget(_target);

                _elapsedTime = 0;
            }
        }
    }
}
