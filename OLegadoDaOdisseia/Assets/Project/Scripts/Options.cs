using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider music;
    public Slider SFX;
    public AudioSource background;
    public void FixedUpdate()
    {
        music.value = GameData.music;
        SFX.value = GameData.SFX;
        background.volume = GameData.music;
    }
    public void musicVolume()
    {
        GameData.music = music.value;
    }
    public void sfxVolume()
    {
        GameData.SFX = SFX.value; 
    }
}
