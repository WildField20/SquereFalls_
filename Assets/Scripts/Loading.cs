using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public int SceneID;

    private void Start()
    {
        StartCoroutine(LoadScene());    
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneID);
        while (!operation.isDone)
        {
            gameObject.transform.Rotate(0,0,10);
            yield return null;
        }
    }

}
