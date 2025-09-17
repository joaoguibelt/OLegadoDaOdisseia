using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{

    //Player
    public float speed = 5.0f;
    public float jumpForce;
    public Rigidbody2D rigidBody;
    public ChecagemChao groundChecker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    void move() //funcao para movimentacao em x
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        // acessa o componente "transform" do objeto e altera o vetor x e y usando (new Vector2(x,y))
        gameObject.transform.Translate(new Vector2(HorizontalInput * speed * Time.deltaTime, 0));
    }

    void jump() //funcao para pulo
    {
        // se a tecla space for apertada, altera o valor da velocidade linear do componente RigidBody usando new Vector2(x,y)
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.IsOnFloor)
            rigidBody.linearVelocity = (new Vector2(0, jumpForce));
    }
}