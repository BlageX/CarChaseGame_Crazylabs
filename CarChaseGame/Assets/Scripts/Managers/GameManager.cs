using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float _score = 0f;

    private float _gasoline;

    [SerializeField]
    private Slider playerGasolineSlider;

    [SerializeField]
    private Text _gasolineProcent;

    [SerializeField]
    private Text _scoreText;

    private AudioSource[] _audioManagerSounds;

    private float _timer;
    private float _timeWait = 1f; // 1f == 1 sec

    [SerializeField]
    private GameObject _gameEndPanel;
    [SerializeField]
    private GameObject _GameEndTitle;
    [SerializeField]
    private GameObject _diamondScoreValueText;
    [SerializeField]
    private GameObject _gasValueText;
    [SerializeField]
    private GameObject _scoreValueText;
    [SerializeField]
    private GameObject _pauseButton;
    [SerializeField]
    private GameObject _shownOnScreenScoreText;
    [SerializeField]
    private GameObject _highScoreComment;

    private float _currentHighScore;


    public float SCORE
    {
        get { return _score; }
        set {
            if (value < 0)
            {
                return;
            }
            _score = value;
            //Debug.Log($"Score updated: {_score}");
            _scoreText.text = $"Score: ${_score}";
        }
    }

    public float GASOLINE
    {
        get { return _gasoline; }
        set
        { 
            _gasoline = value;
            if (_gasoline <= 0)
            {
                Debug.Log($"Level of gasoline belove zero!");
                _gasoline = 0;
                playerGasolineSlider.value = 0;
                GameOver();
            }
           

            _gasolineProcent.text = Mathf.Ceil((_gasoline/playerGasolineSlider.maxValue) * 100) + " %";
            playerGasolineSlider.value = _gasoline;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _gasoline = PlayerPrefs.GetFloat("GasLevel", 100);
        //For slider to change its max value 
        playerGasolineSlider.maxValue = _gasoline;

        _currentHighScore = PlayerPrefs.GetFloat("HighScore", 0);

        _score = 0f;
        _audioManagerSounds = GameObject.Find(TagManager.AUDIOMANAGER_NAME).GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //On every n sec level of fuel drop;
        if (_timer < Time.time)
        {
            GASOLINE--;
            _timer = Time.time + _timeWait;
        }

    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Game Over");
        //_audioManagerSounds[TagManager.GAMEOVER_SOUND].Play();

        //Show menu!
        ShowRightPanel();
        SetUIComponents(true);
    }

    public void EndGame()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Level Finished");
        _audioManagerSounds[TagManager.GAMEOVER_SOUND].Play();

        //Show menu!
        ShowRightPanel();
        SetUIComponents(false);
    }

    //Show EndGame panel and hide pause button and score text on screen
    private void ShowRightPanel()
    {
        _gameEndPanel.SetActive(true);
        _pauseButton.SetActive(false);
        _shownOnScreenScoreText.SetActive(false);
    }

    private void SetUIComponents(bool isGameOver)
    {

        if (isGameOver)
        {
            _GameEndTitle.GetComponent<Text>().text = $"Game Over";
        }
        else
        {
            _GameEndTitle.GetComponent<Text>().text = $"Level Finished";
        }

        _diamondScoreValueText.GetComponent<Text>().text = $"${SCORE}";

        _gasValueText.GetComponent<Text>().text = $"{GASOLINE} X2";

        float newScore = SCORE + GASOLINE * 2;
        _scoreValueText.GetComponent<Text>().text = $"{newScore}";

        if (_currentHighScore < newScore)
        {
            _highScoreComment.GetComponent<Text>().text = $"Congratulations!\nThis is Yor New High Score For This Level!";
            PlayerPrefs.SetFloat("HighScore", newScore);
        }
        else
        {
            _highScoreComment.GetComponent<Text>().text = $"Your Best Score For This Level is {_currentHighScore}!\nCan You Beat it?!";
        }
       
    }

}
