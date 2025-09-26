using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class AtaquesPlayer : MonoBehaviour
{

    //animacao
    public Animator animator;

    //hitbox
    public Transform AttackPoint;
    public float AttackRadius = 0.5f;
    public LayerMask AttackLayer;

    //tipo ataque
    public int AttackType = 0;
    // 1: cortante
    // 2: contundente
    // 3: perfurante

    public void AttackCortante(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("AtkCortante");
            AttackType = 1;

        }
    }

    public void AttackContundente(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("AtkCortante");
            AttackType = 2;

        }
    }

    public void AttackPerfurante(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("AtkCortante");
            AttackType = 3;

        }
    }

    public void CortanteRange()
    {
        Collider2D collinfo = Physics2D.OverlapCircle(AttackPoint.position, AttackRadius, AttackLayer);
        if (collinfo)
        {

            switch (AttackType)
            {
                case 1:
                    Debug.Log("Cortante");
                    break;
                case 2:
                    Debug.Log("Contundente");
                    break;
                case 3:
                    Debug.Log("Perfurante");
                    break;

            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);

    }
}