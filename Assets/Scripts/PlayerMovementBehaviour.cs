using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) { movementDirection += Vector3.forward; }
        if (Input.GetKey(KeyCode.S)) { movementDirection += Vector3.back; }
        if (Input.GetKey(KeyCode.A)) { movementDirection += Vector3.left; }
        if (Input.GetKey(KeyCode.D)) { movementDirection += Vector3.right; }
        movementDirection = movementDirection.normalized;

        Vector3 velocity =
                (movementDirection.z * transform.forward +
                movementDirection.x * transform.right) *
                _movementSpeed;
        if (Input.GetKey(KeyCode.LeftShift)) velocity *= 2;

        _rb.velocity = velocity;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
