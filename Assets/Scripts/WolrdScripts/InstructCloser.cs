using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class InstructCloser : MonoBehaviour
{
    public GameObject Text;
    public int Delay;

    void Start()
    {
        Invoke("CloseText", Delay);
    }
    void CloseText()
    {
        Text.SetActive(false);
    }
}
