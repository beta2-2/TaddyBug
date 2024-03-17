using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    private void Start()
    {
        Ready();
    }

    private void LateUpdate()
    {
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
                if(Input.GetButtonDown("Fire1"))
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

        _scoreLabel.text = "Score : " + 0;
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

        var scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (var item in scrollObjects)
        {
            item.enabled = false;
        }

        _stateLabel.gameObject.SetActive(true);
        _stateLabel.text = "GameOver";
    }

    private void CountDown()
    {

    }

    private void Reload()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreLabel.text = "Score : " + _score;
    }
}
