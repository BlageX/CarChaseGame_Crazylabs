using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class OptionsCameraPosition : MonoBehaviour
{

    private GameObject mainCamera;

    private ToggleGroup _optionsCameraPosition;

    private string _cameraPosition;

    //[SerializeField]
    Text _cameraPositionText;

    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");

        Debug.Log($"MainCamera: {mainCamera.name}");

        //Get value of curently selected camera postion
        _cameraPosition = PlayerPrefs.GetString("CameraPosition", "Default");

        Debug.Log($"Current camera pos: {_cameraPosition}");

        _optionsCameraPosition = this.GetComponent<ToggleGroup>();
        
        //Visualy show what toggle is active;
        _cameraPositionText = GameObject.Find("CameraPosition_Text").GetComponent<Text>();
        _cameraPositionText.text = $"Current camera position: {_cameraPosition}";
    }


    public void ChangeCameraPosition()
    {
        Toggle toggle = _optionsCameraPosition.ActiveToggles().FirstOrDefault();

        string newCameraPosition = toggle.GetComponentInChildren<Text>().text;

        PlayerPrefs.SetString("CameraPosition", newCameraPosition);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;

    }
}
