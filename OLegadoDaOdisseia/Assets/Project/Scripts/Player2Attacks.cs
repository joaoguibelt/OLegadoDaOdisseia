using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class Player2Attack : MonoBehaviour
{

    //animacao
    public Animator animator;

    //hitbox
    public Transform AttackPoint;
    public float AttackRadius = 1.55f;
    public LayerMask AttackLayer;

    //tipo ataque
    public AttackType currentAttackType = AttackType.None;

    //vida
    [SerializeField] Health hp_script;

    //ataque a distancia
    public GameObject projectilePrefab;
    public Transform projectilePoint;

    //sons
    public AudioSource somParry;
    public AudioSource somCortante;
    public AudioSource somDistancia;
    //public AudioSource somPerfurante;

    public void AttackCortante(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //roda animacao e seleciona o attacktype
            animator.SetTrigger("cortante");
            currentAttackType = AttackType.Cortante;

        }
    }
    public void AttackPerfurante(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("perfurante");
            currentAttackType = AttackType.Perfurante;
        }
    }
    public void AttackDistancia(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (projectilePoint != null && projectilePoint != null)
            {
                somDistancia.Play();
                animator.SetTrigger("ranged");
                currentAttackType = AttackType.Distancia;
                Debug.Log("Atirou!");
            }
        }
    }

public void DistantAttack()
    {
        Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
    }

    public void RangeAttack()
    {
        //cortante por default para nao dar erro de unasigned, provisório
        AudioSource currentAttackSound = somCortante;
        
        /*método bonitinho usando ternário, aplicar qnd tiver som perfurante
        AudioSource currentAttackSound = somCortante ? currentAttackType == AttackType.Cortante : somPerfurante;*/

        currentAttackSound.pitch = Random.Range(0.9f, 1.2f);
        currentAttackSound.Play();

        Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRadius, AttackLayer);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.tag == "Player")
            {
                enemy.gameObject.GetComponent<PlayerAttack>().TakeDamage(currentAttackType, 1);
            }
        }
    }

    public void EndAttack()
    {
        //deixa o ataque atual como none (ativada no final da animacao com um "Animation Event")
        currentAttackType = AttackType.None;
    }

    private int MyAttackWins(AttackType myAttack, AttackType opponentattack)
    {
        //checagens de condicoes de vitoria (1) empate (0) e derrota (-1)

        if (myAttack == opponentattack)
            return 0;

        if (
           (myAttack != AttackType.None && opponentattack == AttackType.None)
        || (myAttack == AttackType.Distancia && opponentattack == AttackType.Cortante)
        || (myAttack == AttackType.Cortante && opponentattack == AttackType.Perfurante)
        || (myAttack == AttackType.Perfurante && opponentattack == AttackType.Distancia)
        )
            return 1;

        //caso nao entre em nenhuma condicao de vitoria, entao considera derrota
        return -1;
    }

    public void TakeDamage(AttackType opponentattack, int damage)
    {
        //se a vida for igual ou menor que 0, nao continua a funcao e printa Player Died
        if (hp_script.vida_atual <= 0)
        {
            Debug.Log("Player Died");
            return;
        }

        //TENTATIVA de ver se foi sem defesa (funciona mas ai printa aqui e printa no switch case tb)
        // if (currentAttackType == AttackType.None)
        // {
        //     Debug.Log("SEM DEFESA  " + "Oponente usou  " + opponentattack);
        //     maxHealth -= damage;
        // }

        switch (MyAttackWins(currentAttackType, opponentattack)) //dependendo do return da funcao MyAttackWins
        {
            case 1:
                Debug.Log("GANHEI  " + gameObject.name + "  usou  " + currentAttackType + "  que GANHA de  " + opponentattack);
                //se eu ganho, entao nao tomo dano, finaliza a funcao
                return;
            case 0:
                Debug.Log("EMPATE  " + gameObject.name + "  usou  " + currentAttackType + "  que EMPATA com  " + opponentattack);
                
                //coloquei o som do parry so no empate para nao ficar muito poluído depois deve sair daqui 
                somParry.Play();
                //Debug.Log("PLAYED PARRY");
                
                return;
            case -1:
                Debug.Log("PERDI  " + gameObject.name + "  usou  " + currentAttackType + "  que PERDE de  " + opponentattack);
                //perdi, logo toma dano
                hp_script.DiminuirVida(damage);
                break;
        }
    }

    private void OnDrawGizmosSelected() //desenha uma circunferencia com a mesma hitbox do ataque (apenas pra ajuste mais facil)
    {
        if (AttackPoint == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);

    }
}
