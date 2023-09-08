using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    private Vector3 offSet;
    
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - Player.transform.position;
    }

    // Update is called once per frame after everything else.
    void LateUpdate()
    {
        transform.position = Player.transform.position + offSet;
    }
}
