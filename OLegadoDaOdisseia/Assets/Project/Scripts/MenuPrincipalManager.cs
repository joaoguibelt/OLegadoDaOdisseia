using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string Level;
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

    public void Muda_bool()
    {
        GameData.storyMode = true;
    }

    public void Muda_cena()
    {
        SceneManager.LoadScene(Level);
    }

    public void Fechar_jogo()
    {
        Application.Quit();
    }
}
