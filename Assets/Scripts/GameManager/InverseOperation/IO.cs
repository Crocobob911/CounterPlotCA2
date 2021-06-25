using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IO : MonoBehaviour
{
    public int IO_Decide(int MonsterID, int MonsterState)
    { //MonsterID => 일반몬스터 -> 000~999 엘리트몬스터 -> 1000~1999 // 보스몬스터 2000~

        int IO_level = 0;
        int MonsterType = MonsterID / 1000;
        if (MonsterType == 0)
        {
            if (MonsterState == 0)
            {
                IO_level = 1;
            }
            if (MonsterState == 1)
            {
                IO_level = 2;
            }
        }
        if (MonsterType == 1)
        {
            if (MonsterState == 0)
            {
                IO_level = 2;
            }
            if (MonsterState == 1)
            {
                IO_level = 3;
            }
        }
        if (MonsterType == 2)
        {
            if (MonsterState == 0)
            {
                IO_level = 4;
            }
            if (MonsterState == 1)
            {
                IO_level = 5;
            }
        }
        
        return IO_Make(IO_level);
    }
    public int IO_Make(int IO_level){
        int WizNum = 0;
        WizNum = IO_Rand(IO_level);
        return WizNum;
    }
    private int IO_Rand(int IO_level) //여기서 랜덤으로 고르고 난 뒤에, 플레이어가 가진 위즈와 동일한게 있는지 확인해서, 없는걸로 골라야함 (또는 그냥 역산 시스템 쓰면 위즈 시전 봉인되는걸로 하던가)
    {
        int r = 0;
        if (IO_level == 1)
        {
            r = Random.Range(1, 5);  //1성   5개      /0은 아예 안 그려져 있는 것
        }
        if (IO_level == 2)
        {
            r = Random.Range(6, 15); //2성  10개     
        }
        if (IO_level == 3)
        {
            r = Random.Range(16, 30);  //3성  
        }
        if (IO_level == 4)
        {
            r = Random.Range(31, 50);  //4성    
        }
        if (IO_level == 5)
        {
            r = Random.Range(51, 60);  //5성 
        }
        return r;
    }
    
}

//MonsterState -> 0: 일반 1: 분노
// IO_level -> 1~5 단계 구분
/*
1단계 : 1~2성   : q 초  : MonsterType 0 , MonsterState 0
2단계 : 2~3성   : w 초  : MonsterType 0, MonsterState 1   // MonsterType 1 , MonsterState 0
3단계 : 3~4성   : e 초  : MonsterType 1 , MonsterState 1
4단계 : 4~5성   : r 초  : MonsterType 2 , MonsterState 0
5단계 : 5성     : t 초  : MonsterType 2 , MonsterState 1
*/