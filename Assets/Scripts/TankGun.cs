using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankGun : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private Shell _shellTemplate;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _shootDelay;

    public float ShootDelay => _shootDelay;

    protected virtual bool TryShoot(float timeAfterShoot)
    {
        if (timeAfterShoot >= _shootDelay)
        {
            Shell shell = Instantiate(_shellTemplate, _shootPoint.position, _shootPoint.rotation);

            shell.transform.LookAt(shell.transform.position + shell.transform.forward);

            _shootEffect.Play();

            return true;
        }

        return false;
    }
}
