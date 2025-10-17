using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{

    //Player
    public float moveSpeed = 5.0f;
    public float JumpForce = 3.0f;

    private bool isOnFloor = true;
    private float horizontalMoviment;
    public Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int movendoHash = Animator.StringToHash("movendo");

    private void Awake()
    {
        //Obtém a referência do componente Rigidbody2D quando o jogo começa
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        animator.SetBool(movendoHash, horizontalMoviment != 0);
        if (horizontalMoviment < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isOnFloor)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isOnFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MainGround")
        {
            isOnFloor = true;
        }
    }

}