using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerTankGun : TankGun
{
    [SerializeField] private AudioSource _reloadSound;
    [SerializeField] private AudioSource _shootSound;

    private const string Shoot = "Shoot";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {   
        if (Input.GetMouseButton(0))
            TryShoot();
    }

    protected override bool TryShoot()
    {
        if (base.TryShoot())
        {
            _shootSound.Play();
            _reloadSound.Play();
            _animator.Play(Shoot);

            return true;
        }

        return false;
    }
}
