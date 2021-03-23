using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mude : MonoBehaviour
{
    public AudioSource Music;
    public Button Mude_button;
    void Start()
    {
        Button button = Mude_button.GetComponent<Button>();
        button.onClick.AddListener(MudeOn);
        if(PlayerPrefs.GetInt("Mude")==1)
        {
            Music.mute=true;
        }
        else
            Music.mute=false;  
        if(PlayerPrefs.GetInt("Mude")!=1 && PlayerPrefs.GetInt("Mude")!=0)
        {
            Music.mute=false;
            PlayerPrefs.SetInt("Mude",0);
        }
    }

    void MudeOn()
    {
        if(PlayerPrefs.GetInt("Mude")==0)
        {
            Music.mute=true;
            PlayerPrefs.SetInt("Mude",1);
        }
        else
        {
            Music.mute=false;
            PlayerPrefs.SetInt("Mude",0);
        }
        
    }
}
