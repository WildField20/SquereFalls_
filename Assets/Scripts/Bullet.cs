using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{ 
    public GameObject[] Skins;
    public GameObject Event_sys;
    private float speed; 
    private float rotation_speed;
    private float step; 
    public float progres; //в процентах прогрес движения
    private Vector2 a;
    private Vector2 b;


    void Start()
    {
        SetSkin();
        Event_sys=GameObject.Find("EventSystem"); 
        rotation_speed = Random.Range(0f,10f);
        speed = Random.Range(200f,500f);
        step = 0.0001f * speed;
        a=new Vector3(Random.Range(-3,3),5.5f,87.3f);
        b=new Vector3(Random.Range(-1.4f,1.4f),-5.5f,87.3f);
    }

    void FixedUpdate()
    {
        transform.position= Vector3.Lerp(a ,b,progres); //двигает от a до b с расстоянием в progress
        progres+=step*Time.fixedDeltaTime*8;
        if(progres > 1f) //если прогресс 100% то он пропадает
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
