using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSlimeScript : Monsters
{
    enum state
    {
        idle = 0,
        left = 1,
        right = 2,
        leftAttack = 3,
        rightAttack = 4
    }
    private Animator animator;
    private int State = 0;
    private int _State = 0;

    public void SetAnima()
    {
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }
    public void ChangeMoveAnima(Vector3 rot, bool isAttack)
    {
        State = DecideMoveState(rot, isAttack);
        if (State != _State)
        {
            animator.SetInteger("State", State);
            _State = State;
        }
    }
    public int DecideMoveState(Vector3 rot, bool isAttack)
    {
        if (rot == new Vector3(0, 0, 0)) return (int)state.idle;
        if (rot.x < 0 && !isAttack) return (int)state.left;
        if (rot.x > 0 && !isAttack) return (int)state.right;
        if (rot.x < 0 && isAttack) return (int)state.leftAttack;
        if (rot.x > 0 && isAttack) return (int)state.rightAttack;
        return 0;
    }
    // 위에는 애니메이션 변환하는거, 이걸 다른 오브젝트 하나에 (컨트롤하는) 이식해도 되는지 궁금함. 일단 여기다 써놓음)


    private Transform pt, t;
    
    private Vector2 moveVec;
    
    private float Dis;
    private bool isAttack;


    private void init()
    {
        moveSpeed = 0.7f;
    }
    private void Awake()
    {
        init();
        SetAnima();
        pt = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        t = gameObject.GetComponent<Transform>();
    }
    private void OnEnable()
    {
        init();
    }
    private void Update()
    {
        SlimeMove();
    }
    
    private void SlimeMove()
    {
        moveVec = (pt.position - t.position).normalized;
        Dis = (pt.position - t.position).magnitude;
        Move(moveVec);
        DecideIsAttack(Dis);
        ChangeMoveAnima(moveVec, isAttack);
    }
    private void DecideIsAttack(float d)
    {
        if (d < 3)
        {
            isAttack = true;
            moveSpeed = 1f;
            return;
        }
        isAttack = false;
        moveSpeed = 0.7f;
        return;
    }
}
