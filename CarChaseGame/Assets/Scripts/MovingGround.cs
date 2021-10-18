using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{    
    public float speed;

    private void Awake()
    {
        speed = PlayerPrefs.GetFloat("PlayerSpeed", 5);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
    }

}
