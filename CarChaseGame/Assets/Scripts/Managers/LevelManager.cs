using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    //Numbero of how many times will background with road will respawn
    //It basically set length of level
    [SerializeField]
    private int _noOfRespawns;

    [SerializeField]
    private GameObject[] backgrounds;

    public Vector3 spawningPosition;

    public Quaternion spawningRotation;

    [SerializeField]
    public Vector3 spawningPositionEndLevel;
    [SerializeField]
    public Quaternion spawningRotationEndLevel;

    private void Awake()
    {
        _noOfRespawns = PlayerPrefs.GetInt("LevelLength", 3);
    }

    public void OnTriggerEnter(Collider colider)
    {
        //Respawn road, and background
        if (colider.CompareTag("Background"))
        {
            if (_noOfRespawns > 0)
            {
                Instantiate(backgrounds[0].gameObject, spawningPosition, spawningRotation);
                _noOfRespawns--;
                Debug.Log($"Respawns:{ _noOfRespawns}");
            }
            else
            {
                //Respawn endgame part of level
                Debug.Log($"Respawn end game!");
                Instantiate(backgrounds[1], spawningPositionEndLevel, spawningRotationEndLevel);

            }
        }
    }



}
