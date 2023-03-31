using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(other.gameObject.TryGetComponent(out Tank tank))
        {
            tank.TakeDamage(_damage);
            tank.TryDie();
        }
            
    }
}
