using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _speed = 3.0f;
    [SerializeField] private float _startPosition = 9.0f;
    [SerializeField] private float _endPosition = -9.0f;

    private void Update()
    {
        transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (transform.position.x < _endPosition)
        {
            ScrollEnd();
        }
    }

    private void ScrollEnd()
    {
        transform.Translate(_startPosition - _endPosition, 0, 0);
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}
