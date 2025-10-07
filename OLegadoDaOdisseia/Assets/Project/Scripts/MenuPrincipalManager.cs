using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string Level;
    [SerializeField] private GameObject MenuInicial;
    [SerializeField] private GameObject PainelOpcoes;

    public void jogar() {
        SceneManager.LoadScene(Level);
    }
    public void abrir_opcoes() {
        MenuInicial.SetActive(false);
        PainelOpcoes.SetActive(true);
    }
    public void fechar_opcoes() {
        MenuInicial.SetActive(true);
        PainelOpcoes.SetActive(false);
    }
    public void fechar_jogo() {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
