using UnityEngine;
using System.Collections;

public class AtaquesPlayer : MonoBehaviour
{
    private int tempoCortante = 1;
    public GameObject ataqueCortante;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AtacarCortante()
    {
        StartCoroutine(AtaqueCortanteRoutine());
    }


    public IEnumerator AtaqueCortanteRoutine()
    {
        ataqueCortante.SetActive(true);
        yield return new WaitForSeconds(tempoCortante);
        ataqueCortante.SetActive(false);
    }
}
