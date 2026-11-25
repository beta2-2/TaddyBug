using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    private Block _block;
    private GameController _game;

    private void Start()
    {
        _block = GetComponentInParent<Block>();
        _game = FindFirstObjectByType<GameController>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_game != null && _block != null)
        {
            _game.RegisterPass(other.attachedRigidbody, _block);
        }
    }
}
