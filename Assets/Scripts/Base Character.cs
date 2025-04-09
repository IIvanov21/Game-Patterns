using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public CharacterData characterData;

    string characterName;
    int health;
    float speed;
    float attackDamage;

    GameObject characterPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterName=characterData.characterName;
        health=characterData.health;
        speed=characterData.speed;
        attackDamage=characterData.attackDamage;
        characterPrefab = characterData.characterPrefab;

        characterPrefab=Instantiate(characterPrefab);
        characterPrefab.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
