using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_text : MonoBehaviour
{
    public GameObject[] Text;
    void Start()
    {
        for(int i=0; i<Text.Length;i++)
        {
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                Text[i-1].SetActive(false);
                Text[i].SetActive(true);
            }
        }
        }
    }

    void Update()
    {
        
    }
}
