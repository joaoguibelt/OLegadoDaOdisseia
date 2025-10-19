using UnityEngine;

public class parede : MonoBehaviour
{
    public bool esquerda;
    void Update()
    {
        if (esquerda == true)
        {
            transform.position = new Vector2(-(float)Screen.width / (float)Screen.height * 5, 0);
        }
        else
        {
            transform.position = new Vector2((float)Screen.width / (float)Screen.height * 5, 0);
        }
    }
}
