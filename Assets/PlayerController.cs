using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

private PlayerInput playerInput;
private Vector2 moveVector;
private Rigidbody rb;
    
   [SerializeField]
private float speed = 15;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerInput.Movement.Enable();
    }

    private void OnDisable()
    {
        playerInput.Movement.Disable();
    }

    private void Update()
    {
        moveVector = playerInput.Movement.Move.ReadValue<Vector2>();

        Vector3 moveVector3D = new Vector3(moveVector.x * speed, rb.velocity.y, moveVector.y * speed);

        rb.velocity = transform.TransformDirection(moveVector3D);
    }

    
}
