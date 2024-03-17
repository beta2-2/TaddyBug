using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{

    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _startPosition = 9.0f;
    [SerializeField] private float _endPosition = -9.0f;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);

        if (transform.position.x < _endPosition)
        {
            ScrollEnd();
        }
    }

    private void ScrollEnd()
    {                                             
        transform.Translate(-1 * (_endPosition - _startPosition), 0, 0);
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}
