using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOWiz : MonoBehaviour
{
    private GameObject gm;
    private GameObject GO_Monster;
    private IO iO;

    private int WizNum;
   
    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        iO = gm.transform.GetChild(2).GetComponent<IO>();
        GO_Monster = gameObject.transform.parent.transform.parent.gameObject;
        //몬스터에다가 라이브 오브젝트 붙이기.

        init();
    }
    private void init()
    {
        WizNum = 0;
    }
    
    private void OnEnable()
    {
        //WizNum = iO.IO_Decide();
    }

    // 만들어야하는것. 엘리트 몬스터가 만들어지고 난 후, 어떤 조건에서 IO system이 생겨날것인지 결정하는 것이 필요함. 몬스터 내에서 체력이나 만들어진 시간 등에 따라 함수를 호출하는 방식이 첫번째, 또는 여기서 몬스터의 상태를 체킹하고 IO 시스템 ON 시키는 함수를 실행하는것이 두번째
}

