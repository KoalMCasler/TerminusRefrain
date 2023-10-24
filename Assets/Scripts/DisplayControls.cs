using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayControls : MonoBehaviour
{
    public GameObject ControlText;
    public int DisplayDelay;
    void Start()
    {
        Invoke("CloseControls", DisplayDelay);
    }
    void CloseControls()
    {
        ControlText.SetActive(false);
    }
}
