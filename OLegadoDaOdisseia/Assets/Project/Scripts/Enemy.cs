using UnityEngine;

public class Enemy : MonoBehaviour

{
    public Transform player;
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) < 5.0f)
        {
        }
    }
}
