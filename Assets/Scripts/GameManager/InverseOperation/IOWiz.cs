using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOWiz : MonoBehaviour
{
    private GameObject gm;
    private GameObject monster;

    private Monsters monsters;
    private IO iO;
    private LinePool linePool;

    [SerializeField] private string wizCode;
    [SerializeField] private int startCircle;

    private GameObject lineOnEdit;
    private Transform lineOnEditTr;
    private GameObject ball;
    private Transform ballTr;

    private int circleOnEdit;
    private int monsterID;
    private int monsterState;
    private int[] circles = new int[6];
    private int[] lineNum = new int[5];
    private List<CircleId> circleIds = new List<CircleId>();

    private int usingCircleN;
    private float castingTime;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        iO = gm.transform.GetChild(2).GetComponent<IO>();

        monster = gameObject.transform.parent.gameObject;
        monsters = monster.GetComponent<Monsters>();
        monsterID = monsters.MonsterID;

        linePool = gameObject.transform.GetChild(6).GetComponent<LinePool>();
        ball = gameObject.transform.GetChild(7).gameObject;
        ballTr = ball.GetComponent<Transform>();

        for (int i = 1; i <= 5; i++)
        {
            circleIds.Add(transform.GetChild(i-1).GetComponent<CircleId>());
            circleIds[i - 1].id = i;
        }
        //init();
    }
    private void init()
    {
        circleOnEdit = 0;
        startCircle = 0;
        monsterState = 0;
        wizCode = null;
        for (int i = 0; i < 6; i++)
        {
            circles[i] = 0;
        }
        for (int i = 0; i < 5; i++)
        {
            lineNum[i] = 0;
        }
    }
    
    private void OnEnable()
    {
        iO.IsOnIO++;
        iO.IO_Decide(monsterID, monsters.MonsterState, ref wizCode, ref circles, ref lineNum);
        
        startCircle = circles[0];
        Set_CastingTime();
        Set_UsingCircleN();
    }
    private void Update() // 값이 바뀔 때만 체킹하고 싶은데 그건 나중에
    {
        //Timer();
        Caster();
        Checker();
    }
    
    private void Timer()
    {
        castingTime -= Time.deltaTime;
    }
    private void Caster()//setline 해주면서, setline의 크기를 바꿔줌 (공의 움직임을 매개로)
    {/*
        if () {
            ballTr.localPosition = Vector3.MoveTowards(ballTr.localPosition, , 2f);

            if ()//이동하는 공의 위치 == 다음 circle의 위치 -> 
            { }
        }*/
    }
    private void Checker()
    {
        if (castingTime < 0) // 입력 시간이 다 갔는지 체크
        {
            // 패턴 성공 애니메이션 함수 호출'

        }
        if (CompareWizCode(iO.Get_wizCode(), wizCode, iO.Get_endCircle(), startCircle)) // 거꾸로의 패턴 입력이 들어왔는가?
        {
            //'패턴 붕괴' 애니메이션 함수 호출
            iO.Init_wizCodeNendCircle();
            Debug.Log("역산 성공!!! 축하해요~~!");
        }
    }
    
    private void Set_UsingCircleN()
    {
        int i;
        for (i=0;i<circles.Length;i++)
        {
            if (circles[i] == 0)
               break;
        }
        usingCircleN = i;
    }
    private void Set_CastingTime()
    {
        int cnt = 5;
        for (int i = 0; i < lineNum.Length; i++)
        {
            if (lineNum[i] == 0)
            {
                cnt--;
            }
        }
        castingTime = cnt * (float)0.5 + 5;
    }
    public void Set_monsterState(int s)
    {
        monsterState = s;
    }
    private bool CompareWizCode(string wizcode1, string wizcode2, int circle1,int circle2)
    {
        if (circle1 !=0 && wizcode1 == wizcode2 && circle1 == circle2)
        {
            return true;
        }
        return false;
    }
    
    private void OnDisable()
    {
        iO.IsOnIO--;
        init();
    }

    
    private void SetLine(int c)
    {
        lineOnEdit = linePool.GetLine(circleIds[c - 1].transform.localPosition, c).gameObject;
        lineOnEditTr = lineOnEdit.GetComponent<Transform>();
        lineOnEditTr.localPosition = circleIds[c - 1].transform.localPosition;
        circleOnEdit = c;
    }

    // 만들어야하는것. 엘리트 몬스터가 만들어지고 난 후, 어떤 조건에서 IO system이 생겨날것인지 결정하는 것이 필요함. 몬스터 내에서 체력이나 만들어진 시간 등에 따라 함수를 호출하는 방식
}

