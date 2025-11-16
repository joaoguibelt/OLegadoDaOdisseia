using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image barra_de_vida;
    [SerializeField] Image barra_secundaria;

    public float vida_max = 1000;
    public float vida_atual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida_atual = vida_max;
    }

    // Update is called once per frame
    void Update()
    {
        DiminuirSecundaria();
    }

    public void DiminuirVida(float quantidade)
        {
            vida_atual = Mathf.Clamp(vida_atual - quantidade, 0, vida_max);

            Vector3 barra_de_vida_escala = barra_de_vida.rectTransform.localScale;
            barra_de_vida_escala.x = vida_atual / vida_max;
            barra_de_vida.rectTransform.localScale = barra_de_vida_escala;

        }
    
    public void DiminuirSecundaria()
    {
        Vector3 barra_secundaria_escala = barra_secundaria.transform.localScale;

        if (barra_secundaria.transform.localScale.x > barra_de_vida.rectTransform.localScale.x)
        {
            barra_secundaria_escala.x -= Time.deltaTime * 0.15f;
            barra_secundaria.transform.localScale = barra_secundaria_escala;
        }
    }

}

