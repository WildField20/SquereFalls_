using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squares : MonoBehaviour
{
    private const int BonusScore=25;

    public GameObject Square;
    public GameObject SSquare;
    public GameObject SSSquare;
    public GameObject MSquare;
    public GameObject BSquare;
    public GameObject scoreManager;
    public GameObject RedBoss;
    public GameObject SpeedBoss;
    public GameObject Panel1;
    public GameObject Panel2;

    public float rand;
    public float SpawnSpeed=2;
    public float GrowSpeed=0;
    public int S;
    public int SS ;
    public int SSS ;
    public int M ;
    public int B;
    public bool IsEvent=false;

    private float MaxSpeed=60/2000;
    private int _score;

    void Start()
    {
        S =35;
        SS=26;
        SSS=20;
        M=17;
        B=17;
        scoreManager=GameObject.Find("EventSystem");
    }
    void AddGameObject()
    {
        _score = scoreManager.GetComponent<Play>().numbs;
        rand = Random.Range(0f, 100f);
        if (rand > 95 && _score > 30)
        {
            Instantiate(RedBoss);
            IsEvent = true;
        }
        else if (rand > 92 && _score > 40)
        {
            Instantiate(SpeedBoss);
            IsEvent = true;
        }
        else if(rand > 87 && _score > 50)
        {
            Instantiate(Panel1);
            Instantiate(Panel2);
            IsEvent = true;
        } 
        else if (rand > S && !IsEvent)
        {
            Instantiate(Square);
        }
        else if (rand > SS)
        {
            Instantiate(SSSquare);  // SSSq - большие
            IsEvent = false;
        }
        else if (rand > SSS)
        {
            Instantiate(MSquare);   //MSq - деньги
            IsEvent = false;
        }
        else if (rand > M)
        {
            Instantiate(BSquare); // bsqr - бессмертие
            IsEvent = false;
        }
        else if (rand <= B)
        {
            Instantiate(SSquare); // ssq - очки
            IsEvent = false;
        }
        SpawnSpeed=1.5f;
        if(_score% BonusScore >= 0 && _score/ BonusScore > scoreManager.GetComponent<Play>().SpawnCounter)
        {
            for (int i = 0; i < _score / BonusScore; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Instantiate(SSquare);
                    Instantiate(MSquare);
                    IsEvent = true;
                }
            }
            scoreManager.GetComponent<Play>().SpawnCounter++;
        }

        CancelInvoke();
    }

    void Update()
    {
        InvokeRepeating("AddGameObject",SpawnSpeed,0);
        GrowSpeed=scoreManager.GetComponent<Play>().numbs/2000f;
        if (MaxSpeed < GrowSpeed)
            SpawnSpeed -= MaxSpeed;
        else
            SpawnSpeed -= GrowSpeed;
    }
}
