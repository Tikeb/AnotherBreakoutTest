using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;

    [SerializeField]
    private GameController _gameController;
    [SerializeField]
    private BrickController _brickController;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            PauseGame(menuPanel);
    }

    public void MainMenu()
    {
        PreviousScene();
    }

    public void ReplayLevel()
    {
        _brickController.ResetLevel();

        PauseGame(gameOverPanel);

    }

    public void NextLevel()
    {
        _brickController.NextLevel();
    }

    public void TogglePauseMenu()
    {
        PauseGame(menuPanel);
    }

    public void GameOverMenu()
    {
        PauseGame(gameOverPanel);
    }

    public void NextLevelMenu()
    {
        PauseGame(nextLevelPanel);
    }

    public void PauseGame(GameObject menuItem)
    {
        if (_gameController.isPaused)
        {
            menuItem.SetActive(false);
            Time.timeScale = 1f;
            _gameController.isPaused = false;
        }
        else
        {
            menuItem.SetActive(true);
            Time.timeScale = 0f;
            _gameController.isPaused = true;
        }
    }

    public void ExitGame()
    {
        Debug.Log($"Game has exited");
        Application.Quit();
    }










    public void NextScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
