using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Off_Elements : MonoBehaviour
{
    public GameObject restart;
    public GameObject pause;
    void Start()
    {
        restart.SetActive(false);
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
