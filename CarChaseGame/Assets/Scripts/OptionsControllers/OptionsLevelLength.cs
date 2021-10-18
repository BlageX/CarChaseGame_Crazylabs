using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

//Change of level length loaded in MovingGround.cs
public class OptionsLevelLength : MonoBehaviour
{
    //playerSpeed is speed of background moving, not player himself
    private int _levelLength;

    //Script is on this object
    private ToggleGroup _optionsLevelLength;

    //[SerializeField]
    Text _levelLengthText;

    // Start is called before the first frame update
    void Awake()
    {
        //Get value of length of levele, or how many times bacground object need to spawn before its end of level;
        _levelLength = PlayerPrefs.GetInt("LevelLength", 3);

        _optionsLevelLength = this.GetComponent<ToggleGroup>();


        //Visualy show what toggle is active;
        _levelLengthText = GameObject.Find("LevelLength_Text").GetComponent<Text>();

        _levelLengthText.text = $"Current length: { _levelLength}";
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ChangeLevelLength()
    {
        Toggle toggle = _optionsLevelLength.ActiveToggles().FirstOrDefault();

        int newLength = int.Parse(toggle.GetComponentInChildren<Text>().text);

        PlayerPrefs.SetInt("LevelLength", newLength);

        //RestartLevel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
