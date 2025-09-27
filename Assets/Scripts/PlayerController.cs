using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 20f;
    
    private PlayerControls _controls;
    private Vector2 _move;
    private float _look;
    
    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Player.Move.performed += ctx => 
            SendMessage(ctx.ReadValue<Vector2>());
        _controls.Player.Move.performed += ctx => _move = 
            ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => _move = Vector2.zero;
        
        _controls.Player.Look.performed += ctx => _look = 
            ctx.ReadValue<float>();
        _controls.Player.Look.canceled += ctx => _look = 0f;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    private void SendMessage(Vector2 coordinates)
    {
        Debug.Log(coordinates);
    }

    private void FixedUpdate()
    {
        var movement = new Vector3(_move.x, 0.0f, _move.y) * (speed * Time.fixedDeltaTime);
        transform.Translate(movement, Space.Self);
        // var rotation = new Vector3(0, _look.x, 0) * (rotationSpeed * Time.fixedDeltaTime);
        // transform.Rotate(rotation, Space.World);
        transform.Rotate(Vector3.up * (Time.deltaTime * rotationSpeed * _look));
    }
}
