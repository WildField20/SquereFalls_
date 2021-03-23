using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{ 
    public GameObject[] Skins;
    public GameObject Event_sys;
    private float speed;
    private float rotation_speed;
    private int index_end;
    private int index_start;
    private float step;
    public float progres;
    private Vector2 x;
    private Vector2 y;

    void Start()
    {
        SetSkin();
        Event_sys=GameObject.Find("EventSystem"); 
        rotation_speed = Random.Range(0f,10f);
        speed = Random.Range(200f,500f);
        step = 0.0001f * speed;
        x=new Vector3(Random.Range(-3,3),5.5f,87.3f);
        y=new Vector3(Random.Range(-1.4f,1.4f),-5.5f,87.3f);
    }

    void FixedUpdate()
    {
        transform.position= Vector3.Lerp(x ,y,progres);
        progres+=step*Time.fixedDeltaTime*8;
        if(progres > 1f)
            Destroy(gameObject);
        transform.Rotate(0,0,rotation_speed);    
        if(Event_sys.GetComponent<Play>().die==true)
            Destroy(gameObject);

    }
    void SetSkin()
    {
        for(int i=0;i<Skins.Length;i++)
        {
            Skins[i].SetActive(PlayerPrefs.GetInt("Skin"+i.ToString())==1);
        }
    }
}
