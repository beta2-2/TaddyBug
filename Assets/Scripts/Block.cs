using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private GameObject _pivot;
    private void Start()
    {
        ChangeHeight();
    }

    private void ChangeHeight()
    {
        var height = Random.Range(_minHeight, _maxHeight);
        _pivot.transform.localPosition = new Vector3(0.0f, height, 0.0f);
    }

    private void OnScrollEnd()
    {
        ChangeHeight();
    }
}
