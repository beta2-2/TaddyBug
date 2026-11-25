using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private GameObject _pivot;
    private bool _passed;

    private void OnValidate()
    {
        _maxHeight = Mathf.Max(_minHeight, _maxHeight);
    }

    private void Start()
    {
        ChangeHeight();
    }

    public bool TryMarkPassed()
    {
        if (_passed)
        {
            return false;
        }

        _passed = true;
        return true;
    }

    private void ChangeHeight()
    {
        _passed = false;
        var height = Random.Range(_minHeight, _maxHeight);
        _pivot.transform.localPosition = new Vector3(0.0f, height, 0.0f);
    }

    private void OnScrollEnd()
    {
        ChangeHeight();
    }
}
