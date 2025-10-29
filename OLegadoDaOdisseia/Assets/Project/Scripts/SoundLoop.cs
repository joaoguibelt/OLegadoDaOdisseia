using UnityEngine;



public class SoundLoop : MonoBehaviour
{

    public float finalDoLoop;
    public float inicioDoLoop;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    // Update is called once per frame
    void Update(){
        if (audioSource.time >= finalDoLoop){
            audioSource.time = inicioDoLoop;
        }
    }   

}
