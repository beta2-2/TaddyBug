using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    private GameObject _gameController;
    private void Start()
    {
        _gameController = GameObject.FindWithTag("GameController");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_gameController != null)
            _gameController.SendMessage("IncreaseScore");

    }

}
