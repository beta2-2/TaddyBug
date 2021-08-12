using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;
    int score;

    public TaddyBugController taddyBug;
    public GameObject blocks;
    public Text scoreLabel;
    public Text stateLabel;

    // Start is called before the first frame update
    void Start()
    {
        Ready();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                break;

            case State.Play:
                if (taddyBug.IsDead())
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

    void Ready()
    {
        state = State.Ready;
        taddyBug.SetSteerActive(false);
        blocks.SetActive(false);

        scoreLabel.text = "Score : " + 0;
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "Ready";
    }

    void GameStart()
    {
        state = State.Play;

        taddyBug.SetSteerActive(true);
        blocks.SetActive(true);
        taddyBug.Flap();

        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";
    }

    void GameOver()
    {
        state = State.GameOver;

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (ScrollObject item in scrollObjects)
        {
            item.enabled = false;
        }

        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "GameOver";
    }

    void Reload()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        score++;
        scoreLabel.text = "Score : " + score;
    }
}
