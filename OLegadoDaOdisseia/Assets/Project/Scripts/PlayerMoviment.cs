using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{

    //Player
    public float moveSpeed = 5.0f;
    public float JumpForce = 3.0f;

    private float horizontalMoviment;
    public Rigidbody2D rb;

    private void Awake()
    {
        //Obtém a referência do componente Rigidbody2D quando o jogo começa
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //altera o valor da velocidade linear do componente RigidBody usando new Vector2(x,y)
        rb.linearVelocity = new Vector2(horizontalMoviment * moveSpeed, rb.linearVelocityY);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalMoviment = context.ReadValue<Vector2>().x;

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}