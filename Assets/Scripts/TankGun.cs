using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankGun : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private Shell _shellTemplate;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _shootDelay;

    private Coroutine _currentCoroutine;

    private float _timeAfterShoot = 0;
    private bool _canShoot = true;

    protected virtual bool TryShoot()
    {
        if (_canShoot)
        {
            Shell shell = Instantiate(_shellTemplate, _shootPoint.position, _shootPoint.rotation);

            shell.transform.LookAt(shell.transform.position + shell.transform.forward);

            _shootEffect.Play();
            _canShoot = false;
            _timeAfterShoot = 0;

            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);

            _currentCoroutine = StartCoroutine(IncreaseTimeAfterShoot());

            return true;
        }

        return false;
    }

    private IEnumerator IncreaseTimeAfterShoot()
    {
        while(_timeAfterShoot < _shootDelay)
        {
            _timeAfterShoot += Time.deltaTime;

            yield return null;
        }

        _canShoot = true;
    }
}
