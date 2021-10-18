using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject[] obstacles;
    private List<GameObject> obstaclesHidden = new List<GameObject>();
    private GameObject[] pickUps;
    private List<GameObject> pickUpsHidden = new List<GameObject>();

    [SerializeField]
    private string _difficultyLvl;
    void Awake()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        pickUps = GameObject.FindGameObjectsWithTag("PickUp");

        obstaclesHidden = GetAllHiddenObjects(obstacles);
        pickUpsHidden = GetAllHiddenObjects(pickUps);

        _difficultyLvl = PlayerPrefs.GetString("DifficultyLevel", "Normal");


        Debug.Log($"DifficultyLevel spanwManager: {_difficultyLvl}");

        SpawnObjects();
    }

    private List<GameObject> GetAllHiddenObjects(GameObject[] allObjects)
    {
        List<GameObject> hiddenObjects = new List<GameObject>();

        for (int i = 0; i < allObjects.Length; i++)
        {
            if (!allObjects[i].GetComponent<BoxCollider>().enabled)
            {
                hiddenObjects.Add(allObjects[i]);
            }
        }

        Debug.Log($"ObjectHidden.length: {hiddenObjects.Count}");
        return hiddenObjects;
    }

    private List<GameObject> GetAllVisibleObjects(GameObject[] allObjects)
    {
        List<GameObject> visibleObjects = new List<GameObject>();

        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].GetComponent<BoxCollider>().enabled)
            {
                visibleObjects.Add(allObjects[i]);
            }
        }

        Debug.Log($"ObjectVisible.length: {visibleObjects.Count}");
        return visibleObjects;
    }

    private void SpawnObjects()
    {
        //Show more pickUps, hide more obstacles
        if (_difficultyLvl.Equals("Easy"))
        {
            Debug.Log($"It's easy mode!");
            ShowObjects(pickUpsHidden, 4);
            ShowObjects(obstaclesHidden, 0);
        }
        else if (_difficultyLvl.Equals("Normal"))
        {
            Debug.Log($"It's normal mode!");
            ShowObjects(pickUpsHidden, 4);
            ShowObjects(obstaclesHidden, 2);
        }
        //Hide more pickUps, show more obstacles
        else if (_difficultyLvl.Equals("Hard"))
        {
            Debug.Log($"It's hard mode!");
            ShowObjects(pickUpsHidden, 2);
            ShowObjects(obstaclesHidden, 4);
        }

    }

    private void ShowObjects(List<GameObject> objectsToShow, int n)
    {
        int noToShow = n;
        for (int i = 0; i < objectsToShow.Count; i++)
        {
            int randomIndex = Random.Range(0, objectsToShow.Count);
            if (noToShow > 0)
            {
                //Set it visible
                objectsToShow[randomIndex].GetComponent<BoxCollider>().enabled = true;
              
                objectsToShow[randomIndex].GetComponent<MeshRenderer>().enabled = true;

                noToShow--;
            }
            
        }
    }
}
