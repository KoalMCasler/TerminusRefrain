using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDebug : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Player) 
    {
        Debug.Log("TRIGGERED!");
    }
}
