using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform _target;
    private float _height = 1f;
    private float _speed = 5f;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 targetPos = _target.position;
        targetPos.y = _height;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * _speed);
    }
}
