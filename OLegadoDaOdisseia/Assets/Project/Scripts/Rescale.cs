using UnityEngine;

public class Rescale : MonoBehaviour
{
    public float altura;
    void Update(){
        transform.localScale = new Vector2((float)Screen.width / (float)Screen.height * 10, altura);
    }
}
