using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    // mov
    [SerializeField] Player2Moviment mov_script;

    //ataque a distancia
    public GameObject projectilePrefab;
    public Transform projectilePoint;

    //sons
    public AudioSource somParry;
    public AudioSource somCortante;
    public AudioSource somDistancia;
    //public AudioSource somPerfurante;

    // Variaveis do retorno visual do parry
    [SerializeField] Sprite perf_icon;
    [SerializeField] Sprite cort_icon;
    [SerializeField] Sprite dist_icon;
    public Image icon1;
    public Image icon2;
    public Image card;

    [SerializeField] private string Level;
    public bool actionOn = false;

    public void AttackCortante(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //roda animacao e seleciona o attacktype
            if (!actionOn){
                animator.SetTrigger("cortante");
                currentAttackType = AttackType.Cortante;
            }
        }
    }
    public void AttackPerfurante(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!actionOn){
                animator.SetTrigger("perfurante");
                currentAttackType = AttackType.Perfurante;
                }
        }
    }
    public void AttackDistancia(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (projectilePoint != null && projectilePoint != null)
            {
                somDistancia.Play();
                if (!actionOn){
                    animator.SetTrigger("ranged");
                    currentAttackType = AttackType.Distancia;
                    }
            }
        }
    }

    public void DistantAttack()
    {
        Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
    }

    public void actionStart()
    {
        actionOn = true;
    }

    public void actionEnd()
    {
        actionOn = false;
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

        else if (myAttack != AttackType.None && opponentattack == AttackType.None)
        {
            card.gameObject.SetActive(true);
            return 1;
        }
        else if (myAttack == AttackType.Distancia && opponentattack == AttackType.Cortante)
        {
            icon1.sprite = dist_icon;
            icon2.sprite = cort_icon;
            card.gameObject.SetActive(true);
            return 1;
        }
        else if (myAttack == AttackType.Cortante && opponentattack == AttackType.Perfurante)
        {
            icon1.sprite = cort_icon;
            icon2.sprite = perf_icon;
            card.gameObject.SetActive(true);
            return 1;
        }
        else if (myAttack == AttackType.Perfurante && opponentattack == AttackType.Distancia)
        {
            icon1.sprite = perf_icon;
            icon2.sprite = dist_icon;
            card.gameObject.SetActive(true);
            return 1;
        }

        //caso nao entre em nenhuma condicao de vitoria, entao considera derrota
        return -1;
    }

    public void TakeDamage(AttackType opponentattack, int damage)
    {
        //se a vida for igual ou menor que 0, nao continua a funcao e printa Player Died
        if (hp_script.vida_atual <= 0)
        {
            Debug.Log("Player Died");
            SceneManager.LoadScene(Level);
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
                somParry.Play();
                return;
            case 0:
                Debug.Log("EMPATE  " + gameObject.name + "  usou  " + currentAttackType + "  que EMPATA com  " + opponentattack);
                hp_script.DiminuirVida(damage);
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
