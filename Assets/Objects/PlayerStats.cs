using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStats", menuName = "Persistance", order = 1)]
public class PlayerStats : ScriptableObject
{
    public float maxHP;
    public float currentHP;
    public float moveSpeed;
    public float jumpForce;
    public float playerDamage = 1;
}
