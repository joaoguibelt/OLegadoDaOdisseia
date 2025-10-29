using UnityEngine;

public class ModeControl : MonoBehaviour
{
    [SerializeField] private GameObject Pvp;
    [SerializeField] private GameObject Story;

    void Start()
    {
        if (GameData.storyMode)
        {
            Story.SetActive(true);
            Pvp.SetActive(false);
            GameData.storyMode = false;
        }
        else
        {
            Story.SetActive(false);
            Pvp.SetActive(true);
        }
    }
}
