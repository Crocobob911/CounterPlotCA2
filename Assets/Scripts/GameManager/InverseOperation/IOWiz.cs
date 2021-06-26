using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOWiz : MonoBehaviour
{
    private GameObject gm;
    private GameObject GO_Monster;

    private Monsters monsters;

    private GameObject lineOnEdit;
    private CircleId circleOnEdit;
    private CircleId circleStart;
    private IO iO;

    private string wizCode;
    private int[] lineNum = new int[6];
   
    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        iO = gm.transform.GetChild(2).GetComponent<IO>();
        GO_Monster = gameObject.transform.parent.gameObject;
        monsters = GO_Monster.GetComponent<Monsters>();
        init();
    }
    private void init()
    {
        circleOnEdit.id = 0;
        circleStart.id = 0;
        wizCode = null;
        lineNum = null;
    }
    
    private void OnEnable()
    {
        wizCode = iO.IO_Decide(monsters.MonsterID, monsters.MonsterState);
        Debug.Log(wizCode);

    }
    private void OnDisable()
    {
        init();
    }

    // 만들어야하는것. 엘리트 몬스터가 만들어지고 난 후, 어떤 조건에서 IO system이 생겨날것인지 결정하는 것이 필요함. 몬스터 내에서 체력이나 만들어진 시간 등에 따라 함수를 호출하는 방식
}

