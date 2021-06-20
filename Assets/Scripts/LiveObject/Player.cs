using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LiveObject
{
    private Animator animator;
    private int State = 0;
    private int _State = 0;
    enum state
    {
        idle = 0,
        up = 1,
        right = 2,
        down = 3,
        left = 4
    }

    private void Awake()
    {
        State = 0;
        _State = 0;
        moveSpeed = 0.4f;
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
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
    
}
