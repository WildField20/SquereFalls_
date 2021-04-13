using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public GameObject Scene;
    public GameObject Player;
    public GameObject Shop_button;
    public GameObject Pause_button;
    public GameObject Resume_button;
    public GameObject Home_button;
    public GameObject Restart_button;
    public bool die=false;
    public int numbs=0;
    public int money;
    private string numbs_str;
    private GameObject Playing_scores;
    public GameObject Money_score;
    public bool Pause_is;
    public GameObject Restart_score;
    public GameObject Best_score;
    public GameObject Money_scorer;
    public GameObject Loading;
    public float y;
    public int SpawnCounter = 0;

    private void Awake() {
        Instantiate(Scene);
        Shop_button=GameObject.Find("Shop_button");
        Pause_button=GameObject.Find("Pause");
        Resume_button=GameObject.Find("Resum");
        Home_button=GameObject.Find("Home_button");
        Restart_button=GameObject.Find("Restart_button");
        Money_score=GameObject.Find("Money");
        Player=GameObject.Find("Player");
        Money_scorer=GameObject.Find("Money_rest");
        Restart_score=GameObject.Find("Restart_scores");
        Best_score=GameObject.Find("Best");
        Loading=GameObject.Find("Loading");
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        die =false;
        Pause_is=false;
        Playing_scores= GameObject.Find("Playing_scores");
        Button rs = Resume_button.GetComponent<Button>();
        Button ps = Pause_button.GetComponent<Button>();
        Button rest = Restart_button.GetComponent<Button>();
        Button home = Home_button.GetComponent<Button>();
        home.onClick.AddListener(Home);
        rest.onClick.AddListener(Restart);
        ps.onClick.AddListener(Pause_Resume);
        rs.onClick.AddListener(Pause_Resume);
        numbs=0;
        money=0;
        Button shop = Shop_button.GetComponent<Button>();       
        shop.onClick.AddListener(ShopOnCloick);        
    }

    void Home()
    {
        Loading.GetComponent<Loading>().SceneID=0;
        Loading.GetComponent<Loading>().enabled=true;
        Loading.GetComponent<Image>().enabled=true;
    }
    void Restart()
    {
        numbs=0;
        SpawnCounter = 0;
        Player.transform.position=(new Vector2(0,-2.84f));
        die=false;
    }
    private void Update() {
        numbs_str=numbs.ToString();
        if(die)
        {
            Money_scorer.GetComponent<Text>().text="$ "+PlayerPrefs.GetInt("Money").ToString();
            Restart_score.GetComponent<Text>().text="Your score "+numbs_str;
            Best_score.GetComponent<Text>().text="Best: "+PlayerPrefs.GetInt("Record").ToString();
            InvokeRepeating("TimeSlove",0.2f,0f);
        }
        if(!die && !Pause_is)
        {
        	Time.timeScale=1;
        }
        Playing_scores.GetComponent<Text>().text=numbs_str;
    }
    private void Pause_Resume()
    {
        Money_score.GetComponent<Text>().text="$ "+PlayerPrefs.GetInt("Money").ToString(); 
        if(Time.timeScale!=0)
        {
            Pause_is=true;
            Time.timeScale=0;
        }
        else
        {
            Pause_is=false;
            Time.timeScale=1;
        }
    }
    void ShopOnCloick()
    {
        Loading.GetComponent<Loading>().SceneID=2;
        Loading.GetComponent<Loading>().enabled=true;
        Loading.GetComponent<Image>().enabled=true;
    }
    void TimeSlove()
    {
        Time.timeScale=0;

        CancelInvoke();
    }
}
