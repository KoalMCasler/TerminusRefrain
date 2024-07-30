using UnityEngine;


[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistance", order = 2)]
public class SceneInfo : ScriptableObject
{
    public bool IsNextScene = true;
    void OnEnable()
    {
        IsNextScene = true;
    } 
}



