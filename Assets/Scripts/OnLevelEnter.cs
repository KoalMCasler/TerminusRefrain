using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelEnter : MonoBehaviour
{
    public GameObject Entrance;
    public GameObject Exit;
    public Vector3 EnterOffset = new Vector3(-1, 0, 0);
    public Vector3 ExitOffset = new Vector3(1, 0, 0);
    [SerializeField]
    public SceneInfo sceneInfo;
    private Rigidbody2D Player;
    
    
    void Awake()
    {
        Player = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject target = sceneInfo.IsNextScene ? Entrance : Exit;
        Vector3 Offset = sceneInfo.IsNextScene ? EnterOffset : ExitOffset;

        Player.position = target.transform.position + Offset;
    }
}