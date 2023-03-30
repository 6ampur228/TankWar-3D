using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankDistanceTransitions : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangetSpread;

    private Vector3 _positionForShot;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangetSpread, _rangetSpread);
        _positionForShot = new Vector3(Target.transform.position.x / 2, Target.transform.position.y, Target.transform.position.z);
    }

    private void Update()
    {
        if (Target != null)
        {
            if (Vector3.Distance(transform.position, _positionForShot) < _transitionRange)
            {
                NeedTransit = true;
            }
        }
        else
        {
            NeedTransit = true;
        }
    }
}
