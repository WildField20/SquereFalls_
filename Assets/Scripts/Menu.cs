using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject Scene;
    public GameObject Play_Button;
    public GameObject Shop_button;
    public GameObject Money_score;
    public GameObject Loading;
    private void Awake() {
        Instantiate(Scene);
    }
    void Start()
    {
        Loading=GameObject.Find("Loading");
        Money_score=GameObject.Find("Money");
        Shop_button=GameObject.Find("Shop_button");
        Play_Button=GameObject.Find("Play");
        
        if(PlayerPrefs.GetInt("Skin0")==0 && PlayerPrefs.GetInt("Skin1")==0 && PlayerPrefs.GetInt("Skin2")==0 && PlayerPrefs.GetInt("Skin3")==0 && PlayerPrefs.GetInt("Skin4") == 0)
            PlayerPrefs.SetInt("Skin0",1);
        Money_score.GetComponent<Text>().text="$ "+PlayerPrefs.GetInt("Money").ToString();
        Button play = Play_Button.GetComponent<Button>();
        play.onClick.AddListener(PlayOnCloick);
        Button shop = Shop_button.GetComponent<Button>();
        shop.onClick.AddListener(ShopOnCloick);
    }

    void PlayOnCloick()
    {
        Loading.GetComponent<Loading>().SceneID=1;
        Loading.GetComponent<Loading>().enabled=true;
        Loading.GetComponent<Image>().enabled=true;
    }
    void ShopOnCloick()
    {   
        Loading.GetComponent<Loading>().SceneID=2;
        Loading.GetComponent<Loading>().enabled=true;
        Loading.GetComponent<Image>().enabled=true;
    }
}
