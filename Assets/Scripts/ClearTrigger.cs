using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    private GameObject _gameController;
    // Start is called before the first frame update
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
