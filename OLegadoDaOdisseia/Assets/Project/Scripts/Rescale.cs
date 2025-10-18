using UnityEngine;

public class Rescale : MonoBehaviour
{
    public string item;
    void Update(){
    if (item == "Chao"){
        transform.localScale = new Vector2(Screen.width, 4);
    }
    else
    {
        transform.localScale = new Vector2(Screen.width, 10);
    }
    }
}
