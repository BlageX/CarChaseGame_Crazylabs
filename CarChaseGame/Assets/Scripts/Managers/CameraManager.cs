using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private GameObject target;

    private string _cameraPosition;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindWithTag("Player");

        _cameraPosition = PlayerPrefs.GetString("CameraPosition", "Default");
        
        SetCameraPositionThirdPerson();

        switch (_cameraPosition)
        {
            case "Default":
                SetCameraPositionDefault();
                break;
            case "Other side":
                SetCameraPositionOtherSide();
                break;
            case "3rd person":
                SetCameraPositionThirdPerson();
                break;
        }

    }

    public void SetCameraPositionOtherSide()
    {
        this.GetComponent<Camera>().orthographic = true;
        //this.transform.position = new Vector3(0f, 8f, -8f);
        this.transform.position = new Vector3(-7f, 13f, -17f);
        transform.LookAt(target.transform);
   
    }

    public void SetCameraPositionDefault()
    {
        this.GetComponent<Camera>().orthographic = true;
        this.transform.position = new Vector3(24f, 14f, -23f);
        transform.LookAt(target.transform);

    }


    //public void SetCameraPositionThirdPerson()
    //{
    //    this.GetComponent<Camera>().orthographic = false;
    //    this.transform.position = new Vector3(7f, 3f, -14f);
    //    transform.LookAt(target.transform);
    //}


    public void SetCameraPositionThirdPerson()
    {
        this.GetComponent<Camera>().orthographic = false;
        this.transform.position = new Vector3(7f, 5.7f, -14.5f);
        transform.LookAt(target.transform);
    }
}
