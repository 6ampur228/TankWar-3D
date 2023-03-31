using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTankGun))]
public class ShootState : State
{
    private EnemyTankGun _enemyTankGun;

    private void Start()
    {
        _enemyTankGun = GetComponent<EnemyTankGun>();
    }

    private void Update()
    {
        _enemyTankGun.TryShoot();
    }
}
