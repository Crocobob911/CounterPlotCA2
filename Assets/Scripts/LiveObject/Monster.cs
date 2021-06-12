using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : LiveObject
{
    [SerializeField] private GameObject player;

    private void Start()
    {
        MonsterInit();
    }

    private void Update()
    {
        MonsterMove();
    }

    void MonsterInit()
    {
        MaxHP = 10f;
        HP = 10f;
        MaxMP = 10f;
        MP = 10f;
        attackDamage = 1f;
        moveSpeed = 0.3f;
    }

    void MonsterMove()
    {
        Move(player.transform.position - transform.position);
    }
}
