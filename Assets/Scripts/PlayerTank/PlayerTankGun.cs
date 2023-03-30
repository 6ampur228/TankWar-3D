using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerTankGun : TankGun
{
    [SerializeField] private AudioSource _reloadSound;
    [SerializeField] private AudioSource _shootSound;

    private Animator _animator;

    private float _timeAfterShoot;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _timeAfterShoot = ShootDelay;
    }

    private void Update()
    {   
        _timeAfterShoot += Time.deltaTime;
        
        if (Input.GetMouseButton(0))
        {
            if (TryShoot(_timeAfterShoot))
                _timeAfterShoot = 0;
        }
    }

    protected override bool TryShoot(float timeAfterShoot)
    {
        if (base.TryShoot(timeAfterShoot))
        {
            _shootSound.Play();
            _reloadSound.Play();
            _animator.Play("Shoot");

            return true;
        }

        return false;
    }
}
