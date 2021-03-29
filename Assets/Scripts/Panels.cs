using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panels : SpeedBoss
{
    [SerializeField] private Vector2 _randomRange;
    [SerializeField] private float _speedThis;


    private void Awake()
    {
        SetSpeed(_speedThis, _speedThis);
        SetSkin();
        SetStartPosition(_randomRange.x, _randomRange.y);
        SetEndPosition(StartPosition.x, StartPosition.x);
    }
    private void FixedUpdate()
    {
        Move();
        NewDestroy();
        ChangeDirection();
        OnRestart();
    }
}
