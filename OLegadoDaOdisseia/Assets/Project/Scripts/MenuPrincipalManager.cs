using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    public string Level;
    public GameObject MenuInicial;
    public GameObject PainelOpcoes;
    public GameObject Menu;
    public GameObject Pause;

    public void muda_cena()
    {
        SceneManager.LoadScene(Level);
    }
    public void fechar_jogo()
    {
        Application.Quit();
    }
}
