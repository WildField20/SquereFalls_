using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses
{
    public GameObject gameObject;

    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _endPosition;
    [SerializeField] private float _progress;

    public float Speed
    {
        get { return _speed; }
        set { _speed=value; }
    }
    public Vector2 StartPosition
    {
        get { return _startPosition; }
        set { _startPosition = value; }
    }
    public Vector2 EndPosition
    {
        get { return _endPosition; }
        set { _endPosition = value; }
    }
    public Bosses()
    {
        _startPosition = new Vector2(0, 5.5f);
        _endPosition = new Vector2(0, -5.5f);
        _speed = 0.001f;
        _progress = 0;
    }
    public Bosses(float Speed)
    {
        this._speed = Speed;
        _progress = 0;
    }
    public void Move()
    {
         gameObject.transform.position = Vector3.Lerp(_startPosition, _endPosition, _progress);
        _progress += _speed;
    }
}
