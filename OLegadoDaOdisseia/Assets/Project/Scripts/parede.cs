using UnityEngine;

public class parede : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private bool esquerda;
    void Update()
    {
        //logica de controle da posicao da camera parecida com o de Rescale
        float camWidth = (cam.orthographicSize * 2.0f) * cam.aspect; //cam aspect retorna largura/altura


        if (esquerda == true)
        {
            transform.position = new Vector2(-(camWidth / 2), 0);
        }
        else
        {
            transform.position = new Vector2(camWidth / 2, 0);
        }
    }
}
