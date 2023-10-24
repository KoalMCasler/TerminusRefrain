using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayControls : MonoBehaviour
{
    public GameObject ControlText;
    void Start()
    {
        Invoke("CloseControls", 8);
    }
    void CloseControls()
    {
        ControlText.SetActive(false);
    }
}
