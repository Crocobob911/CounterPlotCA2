using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LiveObject
{
    bool _isTestMode;
    private void Start()
    {
        PlayerInit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            _isTestMode = true;
            Debug.Log("---TEST MODE---");
        }


        if (_isTestMode)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                GetDamage(1f);
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                GetHeal(1f);
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                StartCoroutine(GetStun(1f));
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                StartCoroutine(GetSlow(30f, 2f));
            }
        }
    }

    void PlayerInit()
    {
        _isTestMode = false;
        MaxHP = 10f;
        HP = 10f;
        MaxMP = 10f;
        MP = 10f;
        attackDamage = 1f;
        moveSpeed = 0.5f;
    }
}
