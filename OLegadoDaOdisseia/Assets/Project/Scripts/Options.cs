using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider music;
    public Slider SFX;

    public void FixedUpdate()
    {
        music.value = GameData.music;
        SFX.value = GameData.SFX;
    }
    public void Volume()
    {
        GameData.music = music.value;
        GameData.SFX = SFX.value;   
    }
}
