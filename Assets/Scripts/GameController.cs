using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private enum State
    {
        Ready,
        Play,
        GameOver
    }

    [SerializeField] private Text _scoreLabel;
    [SerializeField] private Text _stateLabel;
    [SerializeField] private GameObject _blocks;
    [SerializeField] private TaddyBugController _taddyBug;

    private State _state;
    private int _score;
    private int _pendingPoints;

    // Resolve the previous physics step before the next one starts.
    private void FixedUpdate()
    {
        ApplyPendingPoints();
    }

    private void Start()
    {
        Ready();
    }

    private void LateUpdate()
    {
        ApplyPendingPoints();

        switch (_state)
        {
            case State.Ready:
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                break;

            case State.Play:
                if (_taddyBug.IsDead())
                {
                    GameOver();
                }
                break;

            case State.GameOver:
                if (Input.GetButtonDown("Fire1"))
                {
                    Reload();
                }
                break;
        }
    }

    private void Ready()
    {
        _state = State.Ready;
        _taddyBug.SetSteerActive(false);
        _blocks.SetActive(false);

        _scoreLabel.text = "Score : 0";
        _stateLabel.gameObject.SetActive(true);
        _stateLabel.text = "Ready";
    }

    private void GameStart()
    {
        _state = State.Play;

        _taddyBug.SetSteerActive(true);
        _blocks.SetActive(true);
        _taddyBug.Flap();

        _stateLabel.gameObject.SetActive(false);
        _stateLabel.text = "";
    }

    private void GameOver()
    {
        _state = State.GameOver;

        var scrollObjects = GameObject.FindObjectsByType<ScrollObject>(FindObjectsSortMode.None);
        foreach (var item in scrollObjects)
        {
            item.enabled = false;
        }

        _stateLabel.gameObject.SetActive(true);
        _stateLabel.text = "GameOver";
    }

    private void Reload()
    {
        SceneManager.LoadScene(0);
    }

    public void RegisterPass(Rigidbody2D body, Block block)
    {
        if (_state == State.Play && body != null && body.gameObject == _taddyBug.gameObject && block.TryMarkPassed())
        {
            _pendingPoints++;
        }
    }

    private void ApplyPendingPoints()
    {
        if (_pendingPoints == 0)
        {
            return;
        }

        if (_state == State.Play && !_taddyBug.IsDead())
        {
            _score += _pendingPoints;
            _scoreLabel.text = "Score : " + _score;
        }
        _pendingPoints = 0;
    }
}
