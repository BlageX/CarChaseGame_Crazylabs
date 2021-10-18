using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

//Change of player speed loaded in SpawnManager.cs
public class OptionsDifficultyLevel : MonoBehaviour
{
    //playerSpeed is speed of background moving, not player himself
    private string _difficultyLevel;

    //Script is on this object
    private ToggleGroup _optionsDifficultyLevel;

    //[SerializeField]
    Text _difficultyLevelText;

    // Start is called before the first frame update
    void Awake()
    {
        //Get value of speed of ground/player
        _difficultyLevel = PlayerPrefs.GetString("DifficultyLevel", "Normal"); 

        _optionsDifficultyLevel = this.GetComponent<ToggleGroup>();

        Debug.Log($"Current diffic. lvl: {_difficultyLevel}");
        //Visualy show what toggle is active;
        _difficultyLevelText = GameObject.Find("DifficultyLevel_Text").GetComponent<Text>();

        _difficultyLevelText.text = $"Current diffic. lvl: {_difficultyLevel}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeDifficultyLevel()
    {
        Toggle toggle = _optionsDifficultyLevel.ActiveToggles().FirstOrDefault();

        string newDifficultyLevel = toggle.GetComponentInChildren<Text>().text;

        Debug.Log($"new dif. lvl:{newDifficultyLevel}");

        PlayerPrefs.SetString("DifficultyLevel", newDifficultyLevel);

        //RestartLevel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
