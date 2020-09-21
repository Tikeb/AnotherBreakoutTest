using UnityEngine;

public class GameController : MonoBehaviour
{
    public int lives;

    public bool isStarted = false;
    public bool isPaused = false;

    [SerializeField]
    private BallController _ballController;
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private BrickController _brickController;

    private int score = 0;
    private int startingLives;

    void Start()
    {
        startingLives = lives;
    }

    public void PlayerScored(int points)
    {
        score += points;
        UpdateScore();
    }

    public void PlayerLostBall()
    {
        if (lives <= 0)
        {
    //menuManager.GameOverMenu();
            //lives = StartingLives;
            //Score = 0;
            //UpdateScore();
            //ResetLives();
            //ResetPosition(true);
        }
        else
        {
            ResetPosition(false);
            RemoveLife();
        }
    }

    public void EndGame(bool win)
    {
        if (win)
        {

        }
        else
        {

        }
    }

    private void ResetPosition(bool resetLevel)
    {
        _ballController.ResetBall();
        _playerController.ResetPlayer();
        isStarted = false;

        if (resetLevel)
            _brickController.ResetLevel();
    }

    private void UpdateScore()
    {
        
    }

    private void RemoveLife()
    {
        
    }
}
