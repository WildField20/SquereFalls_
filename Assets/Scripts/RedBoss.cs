using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : Bosses
{
    [SerializeField] private bool isSmall = false;

    private void Awake()
    {
        SetSkin();
        SetStartPosition(-3, 3);
        SetEndPosition(-1.4f, 1.4f);
        SetSpeed(0.2f,0.8f);
    }
    private void FixedUpdate()
    {
        Move();
        Scale();
        Die();
        OnRestart();
    }

    public void Scale()
    {
        const float SmallSize=0.5f;
        const float BigSize = 2f;
        const float ScaleSpeed=0.05f;

        if (isSmall)
        {
            transform.localScale = new Vector2(transform.localScale.x + ScaleSpeed, transform.localScale.y + ScaleSpeed);
        }
        if (!isSmall)
        {
            transform.localScale = new Vector2(transform.localScale.x - ScaleSpeed, transform.localScale.y - ScaleSpeed);
        }
        if(transform.localScale.x < SmallSize)
        {
            isSmall = true;
        }
        if (transform.localScale.x > BigSize)
        {
            isSmall = false;
        }
    }
}