using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Target != null)
        {
            Vector3 direction = Target.gameObject.transform.position - transform.position;

            transform.rotation = Quaternion.LookRotation(direction);
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        }
    }
}
