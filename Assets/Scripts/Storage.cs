using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public CharacterBehaviour character;
    public PlayerAttack attack;

    public static Storage instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    private void Start()
    {
        character = GameObject.Find("Player").GetComponent<CharacterBehaviour>();
        attack = GameObject.Find("AttackHitbox").GetComponent<PlayerAttack>();
    }
}
