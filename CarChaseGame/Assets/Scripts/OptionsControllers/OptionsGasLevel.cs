using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

//Change of gas level loaded in MovingGround.cs
public class OptionsGasLevel : MonoBehaviour
{
    //playerSpeed is speed of background moving, not player himself
    private float _gasLevel;

    //Script is on this object
    private ToggleGroup _optionsGasLevel;

    //[SerializeField]
    Text _gasLevelText;

    // Start is called before the first frame update
    void Awake()
    {
        //Get value of speed of ground/player
        _gasLevel = PlayerPrefs.GetFloat("GasLevel", 100);

        Debug.Log($"GAS LEVEL: {_gasLevel}");

        _optionsGasLevel = this.GetComponent<ToggleGroup>();

        //Visualy show what toggle is active;
        _gasLevelText = GameObject.Find("GasolineLevel_Text").GetComponent<Text>();

        _gasLevelText.text = $"Current gas level: {_gasLevel}";
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ChangeGasLevel()
    {
        Toggle toggle = _optionsGasLevel.ActiveToggles().FirstOrDefault();

        float newGasLevel = float.Parse(toggle.GetComponentInChildren<Text>().text);

        PlayerPrefs.SetFloat("GasLevel", newGasLevel);

        //RestartLevel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
