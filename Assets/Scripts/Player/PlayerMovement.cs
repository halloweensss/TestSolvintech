using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    
    private Rigidbody _rb;

    private Vector3 _moveDirection;
    private Vector3 _mousePositionStart;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePositionStart = Input.mousePosition;
        }
        
        if (Input.GetMouseButton(0))
        {
            _moveDirection = CalculateMoveDirection(_mousePositionStart, Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _moveDirection = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Rotation(_moveDirection.x);
    }

    private Vector3 CalculateMoveDirection(Vector3 startPosition, Vector3 currentPosition)
    {
        float distance = Vector3.Distance(startPosition, currentPosition);
        float force = distance / Screen.width * 5f;
        Vector3 direction = (Input.mousePosition - _mousePositionStart).normalized;
        return direction * force;
    }
    
    private void Move()
    {
        _rb.MovePosition(_rb.position + transform.forward * speed * Time.deltaTime);
    }

    private void Rotation(float direction)
    {
        transform.Rotate(0f, direction * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
    }
}
