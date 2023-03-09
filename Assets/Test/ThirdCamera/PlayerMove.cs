using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController _player = null;
    public float Speed = 2;
    public float RotateSpeed = 10;
    public float Gravity = -10f;
    private Vector3 Velocity = Vector3.zero;

    private Camera _camera = null;
    private Vector3 _targetPos = Vector3.zero;
    public float _distanceUP = 1.3f;
    public float _distanceAway = 1.7f;
    private float _smooth = 2f;

    void Start()
    {
        _player = transform.Find("unitychan").GetComponent<CharacterController>();
        _camera = Camera.main;
    }
    
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 move = _player.transform.forward * Speed * vertical * Time.deltaTime;
        _player.Move(move);

        Velocity.y += Gravity * Time.deltaTime;
        _player.Move(Velocity * Time.deltaTime);

        _player.transform.Rotate(Vector3.up, horizontal * RotateSpeed);
    }

    private void LateUpdate()
    {
        //_targetPos = _player.transform.position + Vector3.up * _distanceUP - _player.transform.forward * _distanceAway;
        //_camera.transform.position = Vector3.Lerp(_camera.transform.position, _targetPos, _smooth * Time.deltaTime);
        //_camera.transform.LookAt(_player.transform);
    }
}
