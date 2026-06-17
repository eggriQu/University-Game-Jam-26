using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
    void Interact();

    void OnTouchingPlayer();

    void OnNotTouchingPlayer();
}

public class Interactor : MonoBehaviour
{
    private IInteractable currentInteractable;
    private InputAction interact;

    void Update()
    {
        /*
        if (Keyboard.current.eKey.IsActuated() && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
        */
    }

    private void OnEnable()
    {
        interact = InputSystem.actions.FindAction("Interact");

        interact.Enable();
        interact.started += Interact;
    }

    void Interact(InputAction.CallbackContext context)
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null)
        {
            currentInteractable = interactable;
            currentInteractable.OnTouchingPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable.OnNotTouchingPlayer();
            currentInteractable = null;
        }
    }
}
