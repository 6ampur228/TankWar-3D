using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTank : Tank
{
    [SerializeField] private PlayerTank _target;

    public PlayerTank Target => _target;
}
