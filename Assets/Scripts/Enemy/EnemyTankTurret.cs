using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankTurret : MonoBehaviour
{
    [SerializeField] private GameObject _turret;

    [SerializeField] private float _rotationSpeed;

    private Transform _target;

    private void Update()
    {
        TurnTurret(_target);
    }

    public void TurnTurret(Transform target)
    {
        if (target == null)
            return;

        Vector3 direction = target.position - _turret.transform.position;

        direction.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion newRotation = Quaternion.Lerp(_turret.transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

        _turret.transform.rotation = newRotation;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
