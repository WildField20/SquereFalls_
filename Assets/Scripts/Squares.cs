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
    public float rand;
    public float a=2;
    public float b=0;
    public int redBoss;
    public int S;
    public int SS ;
    public int SSS ;
    public int M ;
    public int B;

    void Start()
    {
        redBoss = 85;
        S =35;
        SS=26;
        SSS=20;
        M=17;
        B=17;
        scoreManager=GameObject.Find("EventSystem");
    }
    void AddGameObject()
    {
        rand = Random.Range(0f, 100f);
        if(rand > 85)
        {
            Instantiate(RedBoss);
        }
        else if (rand > S)
            Instantiate(Square);
        else if(rand > SS){
            Instantiate(SSSquare);  // SSSq - большие
            Debug.Log(SS);}
        else if(rand > SSS){
            Instantiate(MSquare);   //MSq - деньги
            Debug.Log(SSS);}
        else if(rand > M){
            Instantiate(BSquare); // bsqr - бессмертие
            Debug.Log(M);}
        else if(rand <= B)
            Instantiate(SSquare); // ssq - очки

        a=2;
        CancelInvoke();
    }

    void Update()
    {
        InvokeRepeating("AddGameObject",a,0);
        b=scoreManager.GetComponent<Play>().numbs/500f;
        a-=b;
    }
}
