using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

//Change of player speed loaded in MovingGround.cs
public class OptionsPlayerSpeed : MonoBehaviour
{
    //playerSpeed is speed of background moving, not player himself
    private float _playerSpeed;

    //Script is on this object
    private ToggleGroup _optionsPlayerSpeed;

    //[SerializeField]
    Text _playerSpeedText;

    // Start is called before the first frame update
    void Awake()
    {
        //Get value of speed of ground/player
        _playerSpeed = PlayerPrefs.GetFloat("PlayerSpeed", 5);
       
        _optionsPlayerSpeed = this.GetComponent<ToggleGroup>();
  
        //Visualy show what toggle is active;
        _playerSpeedText = GameObject.Find("PlayerSpeed_Text").GetComponent<Text>();

        _playerSpeedText.text = $"Current speed: {_playerSpeed}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePlayersSpeed()
    {
        Toggle toggle = _optionsPlayerSpeed.ActiveToggles().FirstOrDefault();

        float newSpeed = float.Parse(toggle.GetComponentInChildren<Text>().text);

        PlayerPrefs.SetFloat("PlayerSpeed", newSpeed);

        //RestartLevel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
