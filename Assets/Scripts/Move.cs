using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject[] Skins;
    public GameObject restart;
    public AudioSource Menuer;
    public AudioSource colector;
    public AudioSource wallker;
    public AudioSource clik;
    public GameObject Event_sys;
    public GameObject squares_spawn;
    public GameObject scoreManager;
    private UnityEngine.Object exp;
    private UnityEngine.Object exp_m;
    private UnityEngine.Object exp_s;
    private UnityEngine.Object exp_r; 
    public GameObject plaing_elements;
    public GameObject Back;
    public GameObject plaing_GUI;
    public Rigidbody2D rb;
    public float speed;
    public bool click=true;
    public bool alive = false;
    public GameObject Block;
    public Vector2 maxVel=new Vector2(1f,0);
    void Start()
    {
        SetSkin();
        scoreManager=GameObject.Find("EventSystem");
        Event_sys=GameObject.Find("EventSystem");
        exp=Resources.Load("Exp");
        exp_r=Resources.Load("Exp_r");
        exp_m=Resources.Load("Exp_m");
        exp_s=Resources.Load("Exp_s");
    }
    private void FixedUpdate() {
        rb.velocity=maxVel*speed*Time.fixedDeltaTime;
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
           PlayerPrefs.SetInt("Money",0);
        }
        if (Input.touchCount>0 && click && !Event_sys.GetComponent<Play>().Pause_is)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                clik.Play();
                maxVel=maxVel*-1;
            }
        }
        //If GetKeyDown space
        if (Input.GetKeyDown("space") && click && !Event_sys.GetComponent<Play>().Pause_is)
        {
            clik.Play();
            maxVel=maxVel*-1;
        }
    }
    private void OnTriggerStay2D(Collider2D call)
    {
        //If player touch wall
        if(call.gameObject.tag == "Wall" )
        {
            click=false;
        }
        //If player touch a square 
        if(call.gameObject.tag == "Square" && !alive)
        { 
            Debug.Log(gameObject.transform.position);
            Debug.Log(call.gameObject.transform.position);
            GameObject ExpRef = (GameObject)Instantiate(exp);
            ExpRef.transform.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
            call.gameObject.SetActive(false);
            RestartGUI();
            Event_sys.GetComponent<Play>().die=true;
        }
        //If player touch a score square
        if(call.gameObject.tag == "SSquare" )
        {
            colector.Play(); 
            GameObject ExpRef_r = (GameObject)Instantiate(exp_r);
            ExpRef_r.transform.position = new Vector2(call.gameObject.transform.position.x,call.gameObject.transform.position.y);
            scoreManager.GetComponent<Play>().numbs+=1;
            Destroy(call.gameObject);
            if(scoreManager.GetComponent<Play>().numbs>PlayerPrefs.GetInt("Record"))
            {
            PlayerPrefs.SetInt("Record", scoreManager.GetComponent<Play>().numbs);
            }   
        }
        if(call.gameObject.tag == "SSSquare" )
        {
            colector.Play(); 
            GameObject ExpRef_s = (GameObject)Instantiate(exp_s);
            ExpRef_s.transform.position = new Vector2(call.gameObject.transform.position.x,call.gameObject.transform.position.y);
            scoreManager.GetComponent<Play>().numbs+=5;
            Destroy(call.gameObject);
            if(scoreManager.GetComponent<Play>().numbs>PlayerPrefs.GetInt("Record"))
            {
            PlayerPrefs.SetInt("Record", scoreManager.GetComponent<Play>().numbs);
            }   
        }
        if(call.gameObject.tag == "MSquare" )
        {
            colector.Play(); 
            GameObject ExpRef_m = (GameObject)Instantiate(exp_m);
            ExpRef_m.transform.position = new Vector2(call.gameObject.transform.position.x,call.gameObject.transform.position.y);
            scoreManager.GetComponent<Play>().money+=1;
            Destroy(call.gameObject); 
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money")+scoreManager.GetComponent<Play>().money);
            scoreManager.GetComponent<Play>().money=0;
        } 
        if(call.gameObject.tag == "Bsquare" )
        {
            colector.Play(); 
            GameObject ExpRef_m = (GameObject)Instantiate(exp_m);
            ExpRef_m.transform.position = new Vector2(call.gameObject.transform.position.x,call.gameObject.transform.position.y);
            alive=true;
            Block.SetActive(true);
            InvokeRepeating("block",15,0f);
            Destroy(call.gameObject); 
        }

        
    }
    void block()
    {
        alive = false;
        Block.SetActive(false);
        CancelInvoke();
    }
    private void OnTriggerExit2D(Collider2D call) {
        if(call.gameObject.tag == "Wall" )
            {
                click = true;
            }    
    }
    private void OnCollisionEnter2D(Collision2D call) {
        if(call.gameObject.tag == "TheWall" )
        {
            wallker.Play();
            maxVel = maxVel*-1;
        }
    }
    void RestartGUI()
    {
        Menuer.Play();
        plaing_GUI.SetActive(false);
        Back.SetActive(false);
        restart.SetActive(true);
        gameObject.SetActive(false);
        plaing_elements.SetActive(false);  
    }
    void SetSkin()
    {
        for(int i=0;i<Skins.Length;i++)
        {
            Skins[i].SetActive(PlayerPrefs.GetInt("Skin"+i.ToString())==1);
        }
    }

}
