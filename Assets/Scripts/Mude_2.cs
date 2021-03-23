using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mude_2 : MonoBehaviour
{

    void Start()
    {
        if(PlayerPrefs.GetInt("Mude")==1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
