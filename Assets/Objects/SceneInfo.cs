using UnityEngine;


[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistance")]
public class SceneInfo : ScriptableObject
{
    public bool IsNextScene = true;
    void OnEnable()
    {
        IsNextScene = true;
    } 
}



