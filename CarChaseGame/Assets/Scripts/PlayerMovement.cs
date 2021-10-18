using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private float startpos;
    private int pos = 1; //Start from middle
    public float[] positionsset;
    private Vector3 velocityf = Vector3.zero;


    private void Update()
    {
        MovingPlayerCar();
    }

    private void MovingPlayerCar()
    {
        if ((Input.touchCount == 1) && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startpos = Input.GetTouch(0).position.x;
        }
        else if ((Input.touchCount == 1) && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (Input.GetTouch(0).position.x - startpos > 0 && pos < 2)
            {
                pos++;
            }
            else if (Input.GetTouch(0).position.x - startpos < 0 && pos > 0)
            {
                pos--;
            }
        }
        else if ((Input.touchCount == 1) && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Debug.Log("Touched the UI");
        }

        this.transform.position = Vector3.SmoothDamp(this.transform.position,
            new Vector3(positionsset[pos], this.transform.position.y, this.transform.position.z), ref velocityf, 0.2f);
    }

}
