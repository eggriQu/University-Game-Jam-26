using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private InputAction move;
    private Vector2 moveInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private MushroomGauge shroomGauge;

    public float tripLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //tripLevel = 0;
    }

    private void OnEnable()
    {
        move = InputSystem.actions.FindAction("Move");

        move.Enable();
        move.performed += Move;
        move.canceled += StopMoving;

    }

    private void OnDisable()
    {
        move.Disable();
        move.performed -= Move;
        move.canceled -= StopMoving;
    }

    void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void StopMoving(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }
}
