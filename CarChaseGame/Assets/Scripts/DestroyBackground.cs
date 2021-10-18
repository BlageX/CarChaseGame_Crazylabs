using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBackground : MonoBehaviour
{
    public void OnTriggerEnter(Collider colider)
    {
      
        if (colider.CompareTag("Background"))
        {
            Destroy(colider.gameObject);
        }
    }
}
