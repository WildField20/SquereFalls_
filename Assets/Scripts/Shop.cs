using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int[] price_int;


    public GameObject scene;
    public GameObject[] select; //масив выбраных скинов
    public GameObject[] price; 
    public GameObject[] buttons;
    public GameObject Home_button;
    public GameObject Money_score;
    public GameObject Error_text;
    public GameObject Loading;
    public Button[] buttonsklick;
    public int skins;

    private void Awake() {
        Instantiate(scene);
        for(int i=0;i<select.Length;i++)
        {
            select[i]=GameObject.Find("SkinSelection"+i.ToString());
            select[i].SetActive(false);
        }
        for(int i=0;i<price.Length;i++)
        {
            price[i]=GameObject.Find("Price_"+i.ToString());
        }
        for(int i=0;i<buttons.Length;i++)
        {
            buttons[i]=GameObject.Find("Button"+i.ToString());
        }
        
    }
    void Start()
    {
        if(PlayerPrefs.GetInt("Skin0")==0 && PlayerPrefs.GetInt("Skin1")==0 && PlayerPrefs.GetInt("Skin2")==0 && PlayerPrefs.GetInt("Skin3")==0)
            PlayerPrefs.SetInt("Skin0",1);
        Money_score=GameObject.Find("Money");
        Home_button=GameObject.Find("Home_button");
        Error_text=GameObject.Find("Error");
        Button home = Home_button.GetComponent<Button>();
        for(int i=0;i<buttons.Length;i++)
        {
            buttonsklick[i]=buttons[i].GetComponent<Button>();
        }
        home.onClick.AddListener(Home);
        buttonsklick[0].onClick.AddListener(Skine0);
        buttonsklick[1].onClick.AddListener(Skine1);
        buttonsklick[2].onClick.AddListener(Skine2);
        buttonsklick[3].onClick.AddListener(Skine3);
        Loading=GameObject.Find("Loading");
        Check();

    }

    void Home()
    {
        Loading.GetComponent<Loading>().SceneID=0;
        Loading.GetComponent<Loading>().enabled=true;
        Loading.GetComponent<Image>().enabled=true;
    }

    void Skine(int i){
    if(PlayerPrefs.GetInt("Skinb"+i.ToString())==1)
    {
    Skin_set(i);
    }
    else
    {
    Skine_buy(i);
    }
    }
    void Skin_set(int z)
    {
        for(int i=0;i<skins;i++)
        {
            if(z==i)
            {
                PlayerPrefs.SetInt("Skin"+z.ToString(),1);
                select[z].SetActive(true);
            }
            else
            {
                PlayerPrefs.SetInt("Skin"+i.ToString(),0);
                StopSelect(i);
            }
        }
    }
    void Skine_buy(int z)
    {
        if(PlayerPrefs.GetInt("Money")>=price_int[z])
        {
        PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money")-price_int[z]);
        Money_score.GetComponent<Text>().text="$ "+PlayerPrefs.GetInt("Money").ToString();
        PlayerPrefs.SetInt("Skinb"+z.ToString(),1); 
        price[z].SetActive(false);
        Skin_set(z);
        }
        else
        {
        FaileBuy();                
        }
        Check();
    }
    void Check()
    {
        for(int i=0; i<skins; i++)
        {
        Money_score.GetComponent<Text>().text="$ "+PlayerPrefs.GetInt("Money").ToString();
        if(PlayerPrefs.GetInt("Skin"+i.ToString())==1)
        {
            select[i].SetActive(true);
        }
        if(PlayerPrefs.GetInt("Skinb"+i.ToString())==1)
        {
            price[i].SetActive(false);
        }
        }
    }
    void Skine0(){
        Skin_set(0);
    }
    void Skine1(){
        Skine(1);
    }
    void Skine2(){
        Skine(2);
    }
    void Skine3(){
        Skine(3);
    }
    void FaileBuy()
    {
        Error_text.GetComponent<Text>().text="You don't have enough money";
        InvokeRepeating("StopFaile",1,10);
    }
    void StopFaile()
    {
        Error_text.GetComponent<Text>().text="";
        CancelInvoke();
    }
    
    void StopSelect(int i)
    {
        string str=i.ToString();
        select[i].SetActive(false);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
