using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LiveObject
{
    [SerializeField] private Animator animator;
    private int State = 0;
    private int _State = 0;

    bool _isTestMode;

    enum state
    {
        idle = 0,
        up = 1,
        right = 2,
        down = 3,
        left = 4
    }

    private void Start()
    {
        PlayerInit();
    }

    void PlayerInit()
    {
        State = 0;
        _State = 0;
        _isTestMode = false;
        MaxHP = 10f;
        HP = 10f;
        MaxMP = 10f;
        MP = 10f;
        attackDamage = 1f;
        moveSpeed = 0.4f;
    }

    public void ChangeMoveAnima(Vector3 rot)
    {
        State = DecideMoveState(rot);
        if (State != _State)
        {
            animator.SetInteger("State", State);
            _State = State;
        }
    }
    private int DecideMoveState(Vector3 rot) //애니메이션 전환을 위해 사용하는 이동 방향 상태
    {
        if (rot == new Vector3(0, 0, 0)) return (int)state.idle;
        if (rot.y > 0 && Mathf.Abs(rot.y) > Mathf.Abs(rot.x)) return (int)state.up;
        if (rot.x > 0 && Mathf.Abs(rot.x) > Mathf.Abs(rot.y)) return (int)state.right;
        if (rot.y < 0 && Mathf.Abs(rot.y) > Mathf.Abs(rot.x)) return (int)state.down;
        if (rot.x < 0 && Mathf.Abs(rot.x) > Mathf.Abs(rot.y)) return (int)state.left;
        return 0;
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
}
