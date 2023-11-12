using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;

    private Vector2 _moveInput;

    private void Update()
    {
        Vector3 position = transform.position;

        position.x += _moveInput.x * moveSpeed * Time.deltaTime;
        position.z += _moveInput.y * moveSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
        position.z = Mathf.Clamp(position.z, minPosition.y, maxPosition.y);

        transform.position = position;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveInput.Normalize();
        _moveInput = moveInput;
    }
}
