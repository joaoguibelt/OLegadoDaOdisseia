using UnityEngine;
using UnityEngine.UI;

public class Sumir : MonoBehaviour
{
    [SerializeField] Image card;
    private float timer = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (card.gameObject.activeSelf && timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            card.gameObject.SetActive(false);
            timer = 2.0f;
        }
    }
}
