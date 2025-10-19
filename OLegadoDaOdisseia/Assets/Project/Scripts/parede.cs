using UnityEngine;

public class parede : MonoBehaviour
{
    public bool esquerda;
    void Update()
    {
        if (esquerda == true)
        {
            transform.position = new Vector2(Camera.main.transform.position.x - (Screen.width)/100, 0);
        }
    }
}
