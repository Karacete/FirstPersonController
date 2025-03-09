using UnityEngine;

public class FirstPersonControllerScript : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float verticalRotation;
    [SerializeField] private Camera mainCamera;
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField]
    [Header("Mouse Look")]
    [SerializeField] private float mouseSensitivity = 3.0f;
    [SerializeField] private float upDownRange = 80.0f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
        float verticalInput = Input.GetAxis("Vertical") * walkSpeed;
        float horizontalInput = Input.GetAxis("Horizontal") * walkSpeed;
        Vector3 speed = new Vector3(horizontalInput, 0, verticalInput);
        speed = transform.rotation * speed;
        characterController.SimpleMove(speed);
    }
    private void HandleRotation()
    {
        float mouseRotationX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseRotationX, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
