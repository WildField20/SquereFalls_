using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour 
{ 
    public GameObject[] Skins;
    public GameObject Event_sys;
    private float _speed; 
    private float _rotation_speed;
    private float _step; 
    public float _progress; //в процентах прогрес движения
    private Vector2 _a;
    private Vector2 _b;


    void Start()
    {
        SetSkin();
        Event_sys=GameObject.Find("EventSystem"); 
        _rotation_speed = Random.Range(0f,10f);
        _speed = Random.Range(200f,500f);
        _step = 0.0001f * _speed;

        _a = new Vector3(Random.Range(-3,3),5.5f,87.3f);
        _b = new Vector3(Random.Range(-1.4f,1.4f),-5.5f,87.3f);
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(_a ,_b, _progress); //двигает от a до b с расстоянием в progress
        _progress += _step*Time.fixedDeltaTime*8;
        transform.Rotate(0, 0, _rotation_speed);
        
        if (_progress > 1f)        //если прогресс 100% то он пропадает
        {
            Destroy(gameObject);
        }

        if (Event_sys.GetComponent<Play>().die == true)
        {
            Destroy(gameObject);
        }

    }
    void SetSkin()
    {
        for(int i=0; i<Skins.Length; i++)
        {
            Skins[i].SetActive(PlayerPrefs.GetInt("Skin"+i.ToString())==1);
        }
    }
}
