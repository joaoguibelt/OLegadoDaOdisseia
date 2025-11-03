using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider music;
    public Slider SFX;
    public AudioSource background;

    private void Start()
    {
        music.value = 0.5f;
        background.volume = music.value;
    }

    public void FixedUpdate()
    {
        SFX.value = GameData.SFX;
    }
    public void musicVolume()
    {
        background.volume = music.value;
    }
    public void sfxVolume()
    {
        GameData.SFX = SFX.value; 
    }
}
