using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelEnter : MonoBehaviour
{
    private GameObject Entrance;
    private GameObject Exit;
    public Vector3 EnterOffset = new Vector3(-1, 0, 0);
    public Vector3 ExitOffset = new Vector3(1, 0, 0);
    [SerializeField]
    public SceneInfo sceneInfo;
    private Rigidbody2D Player;
    
    
    void Awake()
    {
        Player = gameObject.GetComponent<Rigidbody2D>();
        Entrance = GameObject.FindWithTag("Enter");
        Exit = GameObject.FindWithTag("Exit");
    }

    void Start()
    {
        if(Entrance == null)
            {return;}
        if(Exit == null)
            {return;}
        GameObject target = sceneInfo.IsNextScene ? Entrance : Exit;
        Vector3 Offset = sceneInfo.IsNextScene ? EnterOffset : ExitOffset;

        Player.position = target.transform.position + Offset;
    }
}
