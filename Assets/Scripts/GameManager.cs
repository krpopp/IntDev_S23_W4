using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    enum State {Main, Game, End}

    State currentState = State.Main;

    private static GameManager instance;
    public static GameManager FindInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame(string nextScene)
    {
        SwitchStates();
        SceneManager.LoadScene(nextScene);
    }

    void SwitchStates() {
        switch (currentState) {
            case State.Main:
                currentState = State.Game;
                break;
            case State.Game:
                currentState = State.End;
                break;
        }
    }

}
