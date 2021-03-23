using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mude_1 : MonoBehaviour
{

    void Start()
    {
        if(PlayerPrefs.GetInt("Mude")==0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
