using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squares : MonoBehaviour
{

    public GameObject Square;
    public GameObject SSquare;
    public GameObject SSSquare;
    public GameObject MSquare;
    public GameObject BSquare;
    public GameObject scoreManager;
    public GameObject RedBoss;
    public GameObject SpeedBoss;
    public float rand;
    public float a=2;
    public float b=0;
    public int S;
    public int SS ;
    public int SSS ;
    public int M ;
    public int B;

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
        }
        else if (rand > 90 && _score > 40)
        {
            Instantiate(SpeedBoss);
        }
        else if (rand > S)
            Instantiate(Square);
        else if (rand > SS)
        {
            Instantiate(SSSquare);  // SSSq - большие
        }
        else if (rand > SSS)
        {
            Instantiate(MSquare);   //MSq - деньги
        }
        else if (rand > M)
        {
            Instantiate(BSquare); // bsqr - бессмертие
        }
        else if (rand <= B)
        {
            Instantiate(SSquare); // ssq - очки
        }
        a=2;
        if(_score%10>=0 && _score/10> scoreManager.GetComponent<Play>().SpawnCounter)
        {
            for (int i = 0; i < _score / 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Instantiate(SSquare);
                    Instantiate(MSquare);
                }
            }
            scoreManager.GetComponent<Play>().SpawnCounter++;
        }

        CancelInvoke();
    }

    void Update()
    {
        InvokeRepeating("AddGameObject",a,0);
        b=scoreManager.GetComponent<Play>().numbs/500f;
        a-=b;
    }
}
