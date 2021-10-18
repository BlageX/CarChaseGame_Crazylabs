using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Class that take care of menu options
public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseButton;

    [SerializeField]
    private GameObject _optionsMenu;

    [SerializeField]
    private GameObject scoreText;

    private int _currentSceneIndex;

    public bool _isPaused = false;

    // Start is called before the first frame update
    void Awake()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0.0f;
        _pauseButton.SetActive(!_isPaused);
        scoreText.SetActive(!_isPaused);
        _optionsMenu.SetActive(_isPaused);
    }


    public void ContinueGame()
    {
        Debug.Log("ContinueGame!");
        _isPaused = false;
        Time.timeScale = 1.0f;
        _pauseButton.SetActive(!_isPaused);
        scoreText.SetActive(!_isPaused);
        _optionsMenu.SetActive(_isPaused);
    }

    public void Restart()
    {
        Debug.Log($"Game restarted!");
        SceneManager.LoadScene(_currentSceneIndex);
        ContinueGame();
    }

    public void QuiteGame(bool isPaused)
    {
        Debug.Log($"Game closed!");
        Application.Quit();
    }

}
