using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    private float _demage = 25f;

    private GameManager _gameManager;

    private AudioSource[] _audioManagerSounds;

    // Start is called before the first frame update
    void Awake()
    {
        _audioManagerSounds = GameObject.Find(TagManager.AUDIOMANAGER_NAME).GetComponents<AudioSource>();

        _gameManager = GameObject.Find(TagManager.GAMEMANAGER_NAME).GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(TagManager.PLAYER_TAG))
        {
            //Play sound of pick up diamond
            _audioManagerSounds[TagManager.HITOBSTACLE_SOUND].Play();

            //Edit players score
            _gameManager.GASOLINE -= _demage;

            //Destroy diamond
            Destroy(gameObject);

        }
    }
}
