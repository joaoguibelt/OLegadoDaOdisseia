using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefense : MonoBehaviour
{
    public Animator animator;

    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    public void DefenderCortante(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Keyboard.current != null && Keyboard.current.qKey.isPressed)
            {
                animator.SetTrigger("DefCortante");
            }

        }
    }
}
