using System;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    //REFERENCIAS
    public Transform player;
    public Rigidbody2D rb;
    public EnemyAttacks scriptEnemyAttack;

    //CHASE E E MOVING OUT
    public float chaseZone;
    public float chaseSpeed = 3f;
    public float outSpeed = 2f;
    public float safeZone = 7.5f;

    //CONTROLE DE ESTADO
    private float decisionTimer;
    public State currentState = State.Idle;

    //ANIMATOR
    public Animator animator;
    private bool estado;
    
    public enum State
    {
        Idle,
        Chasing,
        Attacking,
        movingOut
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //comeca a zona de chase como o raio de ataque do inimigo 
        chaseZone = scriptEnemyAttack.AttackRadius;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move(estado);
        if(MenuPrincipalManager.isPaused)
            return;
        //Debug.Log("Update -> State = " + currentState + "  Timer = " + decisionTimer);
        switch (currentState)
        {
            case State.Idle:
                estado = false;
                InIdle();
                break;
            case State.Chasing:
                estado = true;
                InChase();
                break;
            case State.movingOut:
                InMovingOut();
                break;
        }
    }

    //FUNCOES DE COMPORTAMENTO
    void InIdle()
    {
        //velocidade 0
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        //conta o cronometro
        decisionTimer -= Time.deltaTime;
        //acabando o tempo, toma alguma decisao (é como um "dlay humano")
        if (decisionTimer <= 0)
        {
            //Debug.Log("Vou fazer uma decisao!\n\n");
            MakeAction();
        }
    }

    void InChase()
    {
        //Debug.Log("Entrei em chase!");
        //encontrando a direcao pra seguir dependendo da posicao do player
        float direction;
        if (player.position.x > transform.position.x)
            direction = 1f;
        else
            direction = -1f;

        rb.linearVelocity = new Vector2(direction * chaseSpeed, rb.linearVelocity.y);

        float PlayerDistance = Math.Abs(player.position.x - transform.position.x);

        //DA CHASE SE A DISTANCIA FOR 1.5F x a chase soze E uma probabilidade de 70% rodar
        if (PlayerDistance < chaseZone * 1.5f && UnityEngine.Random.Range(0.0f, 1.0f) < 0.7f)
        {
            currentState = State.Idle;
            decisionTimer = UnityEngine.Random.Range(0.5f, 1.0f);
        }
    }

    void InMovingOut()
    {
        //Debug.Log("Estou recuando!");
        float direction_out;
        if (player.position.x > transform.position.x)
            direction_out = -1f;
        else
            direction_out = 1f;

        rb.linearVelocity = new Vector2(direction_out * chaseSpeed, rb.linearVelocity.y);

        float PlayerDistance = Math.Abs(player.position.x - transform.position.x);

        //SE A DISTANCIA ATE O PLAYER FOR MAIOR Q A SAFEZONE, OU SE RODAR UMA PROBABLIDADE DE 70%, ENTRA EM IDLE
        if (PlayerDistance > safeZone || UnityEngine.Random.Range(0.0f, 1.0f) > 0.7f)
        {
            currentState = State.Idle;
            decisionTimer = UnityEngine.Random.Range(0.5f, 1.0f);
        }
    }
    void MakeAction()
    {
        float PlayerDistance = Math.Abs(player.position.x - transform.position.x);
        //Debug.Log("Ditancia ate o player: " + PlayerDistance);

        //SE ESTIVER DENTRO DO RAIO DE ATAQUE MEELE, ESCOLHE ENTRE ATAQUE CORTANTE (70%) OU MOVER PRA TRAS(30%)
        if (PlayerDistance < chaseZone)
        {
            //Debug.Log("primeiro if");
            if (UnityEngine.Random.Range(0.0f, 1.0f) <= 0.6f)
                scriptEnemyAttack.AttackCortante();
            else
                currentState = State.movingOut;
        }

        //SE ESTIVER DETRO DE 2X O RAIO DE MEELE, ESCOLHE ENTRE CHASING (50%) OU ATAQUE DISTANCIA
        else if (PlayerDistance < (chaseZone * 2.5f))
        {
            //Debug.Log("Segundo if");
            if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.5f){
                currentState = State.Chasing;
            }
            else
                scriptEnemyAttack.AttackPerfurante();

        }

        //SE ESTIVER MUITO LONGE, ESCOLHE ENTRE CHASING(60%) OU RECUAR(40%)
        else
        {
            if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.6f)
                currentState = State.Chasing;
            else
                currentState = State.movingOut;
        }
        //Debug.Log("Reiniciando timer");
        decisionTimer = UnityEngine.Random.Range(0.5f, 1.5f);
    }
    void move(bool estado)
    {
        animator.SetBool("movendo", estado);
    }
}
