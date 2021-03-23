using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public GameObject[] Skins;
    void Start()
    {
        SetSkin();
        InvokeRepeating("Destroy",2f,0f);   
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
    void SetSkin()
    {
        for(int i=0;i<Skins.Length;i++)
        {
            Skins[i].SetActive(PlayerPrefs.GetInt("Skin"+i.ToString())==1);
        }
    }
}
