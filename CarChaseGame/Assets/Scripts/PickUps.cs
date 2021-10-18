using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField]
    private float _points;

    [SerializeField]
    private bool _isGasoline;

    [SerializeField]
    private float _gasolineValue;

    private GameManager _gameManager;

    private AudioSource[] _audioManagerSounds;
    // Start is called before the first frame update
    void Awake()
    {
        _audioManagerSounds = GameObject.Find(TagManager.AUDIOMANAGER_NAME).GetComponents<AudioSource>();

        _gameManager = GameObject.Find(TagManager.GAMEMANAGER_NAME).GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(TagManager.PLAYER_TAG))
        {

            if (!_isGasoline)
            {
                //Play sound of pick up diamond
                _audioManagerSounds[TagManager.PICKUPDIAMOND_SOUND].Play();

                //Edit players score
                _gameManager.SCORE += _points;

            }
            else
            {
                //Play sound of pick up gasoline
                _audioManagerSounds[TagManager.PICKUPGASOLINE_SOUND].Play();

                //Edit players gasoline level
                _gameManager.GASOLINE += _gasolineValue;
            }

            //Destroy diamond
            Destroy(gameObject);
        }
    }
}
