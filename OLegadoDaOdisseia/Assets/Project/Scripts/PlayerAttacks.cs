using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class AtaquesPlayer : MonoBehaviour
{
    public Animator animator;

    public Transform AttackPoint;
    public float AttackRadius = 0.5f;
    public LayerMask AttackLayer;

    private int tempoCortante = 1;
    public GameObject ataqueCortante;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }


    public void AtacarCortante(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Keyboard.current == null && !Keyboard.current.qKey.isPressed)
            {
                animator.SetTrigger("AtkCortante");
            }

        }
        //StartCoroutine(AtaqueCortanteRoutine());
    }
    public void CortanteRange()
    {
        Collider2D collinfo = Physics2D.OverlapCircle(AttackPoint.position, AttackRadius, AttackLayer);
        if (collinfo)
        {
            Debug.Log(collinfo.transform.name);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);

    }

    // public IEnumerator AtaqueCortanteRoutine()
    // {
    //     ataqueCortante.SetActive(true);
    //     yield return new WaitForSeconds(tempoCortante);
    //     ataqueCortante.SetActive(false);
    //}
}
