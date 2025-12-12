using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;


    void Start()
    {
        rb.linearVelocity = transform.right * speed;

        //destroi apos 3 segundos pra evitar consumo de memória
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bot")
        {
            collision.gameObject.GetComponent<EnemyAttacks>().TakeDamage(AttackType.Distancia, damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<Player2Attack>().TakeDamage(AttackType.Distancia, damage);
            Destroy(gameObject);
        }
    }
}