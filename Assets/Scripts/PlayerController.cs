using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    
    private PlayerControls _controls;
    private Vector2 _move;
    
    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Player.Move.performed += ctx => 
            SendMessage(ctx.ReadValue<Vector2>());
        _controls.Player.Move.performed += ctx => _move = 
            ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => _move = Vector2.zero; 
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
        transform.Translate(movement, Space.World);
    }
}
