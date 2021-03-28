using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses : MonoBehaviour
{

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

    public void SetStartPosition(float startRange, float endRange)
    {
        _startPosition =new Vector2(Random.Range(startRange,endRange),5.5f);
    }
    public void SetEndPosition(float startRange, float endRange)
    {
        _endPosition = new Vector2(Random.Range(startRange, endRange), -5.5f);
    }

    public void Move()
    {
         transform.position = Vector3.Lerp(_startPosition, _endPosition, _progress);
        _progress += _speed;
    }
    public void SetSpeed(float startRange, float endRange)
    {
        _speed = Random.Range(startRange, endRange)/100;
    }
    public virtual void Die()
    {
        if (_progress > 100)
        {
            Destroy(gameObject);
        }
    }
}
