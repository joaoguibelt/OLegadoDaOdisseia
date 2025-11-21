using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Image barra_de_vida;
    [SerializeField] Image barra_secundaria;

    public float vida_max = 1000;

    public float vida_atual;

    //public AudioSource somGemido;

    private float tempoParaDescer = 0f;


    void Start()
    {
        vida_atual = vida_max;
    }

    void Update()
    {
        DiminuirSecundaria();
    }

    public void DiminuirVida(int quantidade)
        {
            vida_atual = Mathf.Clamp(vida_atual - quantidade, 0, vida_max);

            Vector3 barra_de_vida_escala = barra_de_vida.rectTransform.localScale;
            barra_de_vida_escala.x = vida_atual / vida_max;
            barra_de_vida.rectTransform.localScale = barra_de_vida_escala;

            tempoParaDescer = 0.5f;//delay pra secundária vir

            /*
            //geme quando toma hit
            somGemido.pitch = Random.Range(0.9f, 1.2f);
            somGemido.Play();
            */
            
        }
    
    public void DiminuirSecundaria()
    {
        //fica esperando pra descer
        if (tempoParaDescer > 0)
        {
            tempoParaDescer -= Time.deltaTime;//descendo cronometro do delay
            return;
        }   

        Vector3 barra_secundaria_escala = barra_secundaria.transform.localScale;

        if (barra_secundaria.transform.localScale.x > barra_de_vida.rectTransform.localScale.x)
        {
            barra_secundaria_escala.x -= Time.deltaTime * 0.15f;
            barra_secundaria.transform.localScale = barra_secundaria_escala;
        }
    }

}