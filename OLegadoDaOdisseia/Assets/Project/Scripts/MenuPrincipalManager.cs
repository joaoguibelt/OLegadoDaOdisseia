using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    public string Level;
    public GameObject Pause;

    void Update()
    {
        if (Pause.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void muda_cena()
    {
        SceneManager.LoadScene(Level);
    }
    public void fechar_jogo()
    {
        Application.Quit();
    }
}
