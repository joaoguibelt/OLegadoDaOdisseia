using UnityEngine;
using UnityEngine.UI;

public class Sumir : MonoBehaviour
{
    [SerializeField] Image card;
    private float timer = 2.0f;

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
