using UnityEngine;

public class Rescale : MonoBehaviour
{
    public float altura;
    void Update(){
        // transform.localScale = new Vector2((float)Screen.width * 3 / (float)Screen.height * 2, altura);
        Debug.Log(Screen.width);
        transform.localScale = new Vector2((float)Screen.width / 3000, altura);
    }
}
