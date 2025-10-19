using UnityEngine;

public class Rescale : MonoBehaviour
{
    public float altura;
    void Update(){
        transform.localScale = new Vector2(Screen.width, altura);
    }
}
