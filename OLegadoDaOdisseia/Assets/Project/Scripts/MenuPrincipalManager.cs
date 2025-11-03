using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string Level;
    public GameObject Pause;
    public static bool isPaused = false;

    public InputActionAsset player1;
    public InputActionAsset player2;

    void Update()
    {
        if (Pause.activeSelf)
        {
            isPaused = true;
            player1.Disable();
            player2.Disable();
        }
        else
        {
            isPaused = false;
            player1.Enable();
            player2.Enable();
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
