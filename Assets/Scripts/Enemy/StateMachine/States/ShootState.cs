using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTankGun))]
public class ShootState : State
{
    private EnemyTankGun _enemyTankGun;

    private float _timeAfterShoot = 0;

    private void Start()
    {
        _enemyTankGun = GetComponent<EnemyTankGun>();
    }

    private void Update()
    {
        if (_enemyTankGun.TryEnemyTankShoot(_timeAfterShoot))
            _timeAfterShoot = 0;

        _timeAfterShoot += Time.deltaTime;
    }
}
