using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankGun : TankGun
{
    public bool TryEnemyTankShoot(float timeAfterShoot)
    {
        return base.TryShoot(timeAfterShoot);
    }
}
