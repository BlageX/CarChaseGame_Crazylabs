using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndScript : MonoBehaviour
{
    private AudioSource[] _audioManagerSounds;
    // Start is called before the first frame update

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(TagManager.PLAYER_TAG))
        {
            //Play sound of levels end
            //_audioManagerSounds[TagManager.HITOBSTACLE_SOUND].Play();
            _gameManager.EndGame();

            //Trenutno
            Time.timeScale = 0.0f;

        }
    }
}
