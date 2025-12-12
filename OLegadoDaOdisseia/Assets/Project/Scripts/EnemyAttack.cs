using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public Animator animator;
    public AudioSource somParry;


    //hitbox
    public Transform AttackPoint;
    public float AttackRadius = 0.5f;
    public LayerMask AttackLayer;

    //tipo ataque
    public AttackType currentAttackType = AttackType.None;

    //vida
    [SerializeField] Health hp_script;

    //ataque a distancia
    public GameObject projectilePrefab;
    public Transform projectilePoint;

    public void AttackCortante()
    {
        Debug.Log("Ciclope Cortante!");
        animator.SetTrigger("AtkCortante");
        currentAttackType = AttackType.Cortante;
    }

    public void AttackPerfurante()
    {
            Debug.Log("Ciclope Perfurante!");
            animator.SetTrigger("AtkPerfurante");
            currentAttackType = AttackType.Perfurante;
    }

    public void AttackDistancia()
    {
        if (projectilePoint != null && projectilePoint != null)
        {
            animator.SetTrigger("AtkDistancia");
            currentAttackType = AttackType.Distancia;
            Debug.Log("Ciclope Atirou!");

        }
    }

    public void DistanciaRange()
    {
        Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
    }

    public void CortanteRange()
    {
        Collider2D collinfo = Physics2D.OverlapCircle(AttackPoint.position, AttackRadius, AttackLayer);
        if (collinfo.gameObject.tag == "Player")
        {
            //pega o script PlayerAttack do que foi atingido na layer e ativa a funcao TakeDamage com
            // o parametro do tipo de ataque dado e do dano
            collinfo.gameObject.GetComponent<PlayerAttack>().TakeDamage(currentAttackType, 1);
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
