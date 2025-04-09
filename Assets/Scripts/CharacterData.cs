using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Character Tools/CharacterData")]
public class CharacterData : ScriptableObject
{

    public string characterName;
    public int health;
    public float speed;
    public float attackDamage;

    public GameObject characterPrefab;

    //Specific parameters for the Player
    public float attackTime;
}
