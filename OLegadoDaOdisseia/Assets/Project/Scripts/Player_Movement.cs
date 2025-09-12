using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    public float velocity = 5.0f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputSystem.EnableDevice(Keyboard.current);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("a"))
        {
                       transform.Translate(Vector3.left * velocity * Time.deltaTime);
        }
        else if (Input.GetButton("d"))
        {
            transform.Translate(Vector3.right * velocity * Time.deltaTime);
        }
        else if (Input.GetButton("w"))
        {
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        }
        else if (Input.GetButton("s"))
        {
            transform.Translate(Vector3.back * velocity * Time.deltaTime);
        }
    }
}
