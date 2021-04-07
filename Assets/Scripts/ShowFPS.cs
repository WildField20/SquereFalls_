using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    private float _fps;
    private Text _text;

    private void Start()
    {
        _text = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        _fps = 1.0f / Time.deltaTime;
        _text.text = "FPS "+(int)_fps;
    }
}
