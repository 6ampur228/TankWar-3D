using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTankMover : MonoBehaviour
{
    [SerializeField] private Transform _turret;
    [SerializeField] private Transform _hull;

    [SerializeField] private float _slowdown;

    private void Update()
    {
        float angleX = Input.mousePosition.x;

        _turret.eulerAngles = new Vector3(_hull.eulerAngles.x, angleX /  _slowdown, _hull.eulerAngles.z);
    }
}
