using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [HideInInspector] public static PlayerMovementBehaviour instance;
    [SerializeField] private float _movementSpeed;
    [HideInInspector] public Vector3 _movementDirection;
    private Rigidbody _rb;

    void Start()
    {
        instance = this;
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) { _movementDirection += Vector3.forward; }
        if (Input.GetKey(KeyCode.S)) { _movementDirection += Vector3.back; }
        if (Input.GetKey(KeyCode.A)) { _movementDirection += Vector3.left; }
        if (Input.GetKey(KeyCode.D)) { _movementDirection += Vector3.right; }
        _movementDirection = _movementDirection.normalized;

        Vector3 velocity =
                (_movementDirection.z * transform.forward +
                _movementDirection.x * transform.right) *
                _movementSpeed;
        if (Input.GetKey(KeyCode.LeftShift)) velocity *= 2;

        _rb.velocity = velocity;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
