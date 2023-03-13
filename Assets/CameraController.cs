using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField]
    private float sensitivity = 100;

    [SerializeField]
    private Transform playerTransform;

    private float xRotation = 0;


    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.MouseMovement.Enable();
    }

    private void OnDisable()
    {
        playerInput.MouseMovement.Disable();
    }

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update(){
        float mousePositionX = playerInput.MouseMovement.MousePosition.ReadValue<Vector2>().x * sensitivity * Time.deltaTime;
        float mousePositionY = playerInput.MouseMovement.MousePosition.ReadValue<Vector2>().y * sensitivity * Time.deltaTime;

        xRotation -= mousePositionY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerTransform.Rotate(Vector3.up * mousePositionX);
    }

    


}
