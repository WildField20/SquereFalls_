using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private void Update()
    {
        OnRestart();
    }
    private void Start()
    {
        StartCoroutine(Destroy());   
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    public void OnRestart()
    {
        if (GameObject.Find("Player") == null)
        {
            Destroy(gameObject);
        }
    }
}
