using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTankMover : MonoBehaviour
{
    [SerializeField] private Material _track;
    [SerializeField] private AudioSource _motorSound;
    [SerializeField] private AudioSource _motionSound;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody _playerTank;

    private float _positionX;
    private float _rotationY;
    private float _offset = 0;
    private float _changeValue = 0.003f;

    private void Start()
    {
        _playerTank = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _positionX = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        _rotationY = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;

        PlayRightSound();

        Vector3 moveTank = new Vector3(_positionX, 0, 0);
        Quaternion rotationTank = Quaternion.Euler(new Vector3(0, _rotationY, 0));

        _playerTank.MoveRotation(_playerTank.rotation * rotationTank);

        Vector3 direction = _playerTank.rotation * moveTank + _playerTank.position;

        _playerTank.MovePosition(direction);

        if (_positionX > 0)
            _offset += _changeValue;
        else if (_positionX < 0)
            _offset -= _changeValue;

        ChangeTrackTextureOffset(_track, _offset);
    }

    private void ChangeTrackTextureOffset(Material track,float offset)
    {
        track.mainTextureOffset = new Vector2(0, offset);
    }

    private void PlayRightSound()
    {
        if(_positionX != 0)
        {
            if(_motionSound.isPlaying == false)
            {
                _motorSound.Stop();
                _motionSound.Play();
            }           
        }
        else
        {
            if(_motorSound.isPlaying == false)
            {
                _motionSound.Stop();
                _motorSound.Play();
            }           
        }
    }
}
