using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : Bosses
{
    [SerializeField] Bosses _redBoss=new Bosses();
    private void Awake()
    {
        gameObject = GameObject.Find("BigRed");
    }
    private void FixedUpdate()
    {
        _redBoss.Move();
    }
}
