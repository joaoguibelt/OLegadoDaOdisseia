using System.Numerics;
using UnityEngine;

public class ReescaleObjects : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Camera cam;

    [SerializeField] private bool RenderX;
    [SerializeField] private bool RenderY;
    void Start()
    {

    }
    void FixedUpdate()
    {
        //largura e altura da camera
        float camHeight = cam.orthographicSize * 2.0f; //essa funcao retorna a metade da altura
        //quando vale 5, significa que a altura é de -5 até +5 = 10 //por isso multiplica por 2
        float camWidth = camHeight * cam.aspect;  //cam aspect retorna largura/altura

        //largura e altura do sprite
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;


        UnityEngine.Vector2 newScale = transform.localScale;
        if (RenderX)
            newScale.x = camWidth / spriteWidth;
        if (RenderY)
            newScale.y = camHeight / spriteHeight;

        transform.localScale = newScale;

    }
}
