using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoss : Bosses
{
    private void Awake()
    {
        SetSkin();
        SetSpeed(1f, 2f);
        StartPosition = new Vector2(-3,6);
        EndPosition = new Vector2(3,6 - Random.Range(2, 4));
    }
    private void FixedUpdate()
    {
        Move();
        NewDestroy();
        ChangeDirection();
        OnRestart();
    }
    public void ChangeDirection()
    {
        if (Progress > 1)
        {
            StartPosition = EndPosition;
            EndPosition = new Vector2(EndPosition.x * -1, EndPosition.y - Random.Range(1f, 3.5f)  );
            Progress = 0;
        }
    }
    public void NewDestroy()
    {
        if(transform.position.y<-5.5)
        {
            Destroy(gameObject);
        }
    }
}
