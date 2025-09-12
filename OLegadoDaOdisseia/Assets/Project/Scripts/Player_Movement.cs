using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    public float velocity = 5.0f;
    public Vector2 movement;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHori = Input.GetAxis("Horizontal");
        movement.x = moveHori * velocity * Time.deltaTime;
        transform.Translate(movement);
    }
}
