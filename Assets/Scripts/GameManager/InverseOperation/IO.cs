using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IO : MonoBehaviour
{
    private void Awake()
    {
        
    }
    private void init()
    {
        
    }
    public string IO_Decide(int MonsterID, int MonsterState)
    { //MonsterID => 일반몬스터 -> 000~999 엘리트몬스터 -> 1000~1999 // 보스몬스터 2000~
        // 특정 보스 몬스터의 경우 연속된 IOwiz가 있었으면 좋겠음. 말그대로 보스 패턴인거지. 나중에 유저들이 익숙해지면 빨리 깰 수도 있는거고(후다닥 미리 그어놓는다던가)
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
        
        return IO_Rand(IO_level);
    }
    
    private string IO_Rand(int IO_level) //여기서 랜덤으로 고르고 난 뒤에, 플레이어가 가진 위즈와 동일한게 있는지 확인해서, 없는걸로 골라야함 (또는 그냥 역산 시스템 쓰면 위즈 시전 봉인되는걸로 하던가)
    {
        int usingCircle = 0; // 사용할 성(점) 개수
        int startDot = 0; // 시작점
        string startNwizCode = null;  // 시작점과 위즈코드 예: 100016 시작점이 id 1이며, num 1 num6 인 선으로 구성된 패턴

        int[] Rcircles = new int[6]; //사용한 점들 순서대로
        int[] RlineNum = new int[5]; // 점 순서대로 NumberDetecting
        for (int i = 0; i < 5; i++)
        {
            RlineNum[i] = 0;
        } // RlineNum 초기화

        if (IO_level == 1)
        {
            usingCircle = 2; //2성
        }
        if (IO_level == 2)
        {
            usingCircle = UnityEngine.Random.Range(2, 4); //2성 ~ 3성  
        }
        if (IO_level == 3)
        {
            usingCircle = UnityEngine.Random.Range(3, 5);  //3성  ~4성
        }
        if (IO_level == 4)
        {
            usingCircle = UnityEngine.Random.Range(4, 6);  //4성 ~5성  
        }
        if (IO_level == 5)
        {
            usingCircle = 5;  //5성 
        }

        //여기서 이제. 시작점 랜덤으로 지정하고, (그 점에서 다른 점 선택하고,) 를 usingDot 만큼 반복하고, 마지막으로 usingDot이 3 이상일 때 처음 점으로 돌아갈지 말지 (시작점과 끝점을 이을건지 말건지) 결정하는 부분까지 추가해서 circles를 구성하고,
        //numberDetecting으로 RlineNum을 만들고, startNwizCode로 보내버리면 완성.
        startDot = UnityEngine.Random.Range(1, 6); // 시작점 정하기
        Rcircles[0] = startDot;
        for (int i = 1; i < usingCircle; i++)
        {
            Rcircles[i] = UnityEngine.Random.Range(1,6);
            for (int j =0; j < i;j++)
            {
                if (Rcircles[i] == Rcircles[j])
                {
                    i--;
                    break;
                }
            }
        }

        #region NumberDetecting
        int a, b;
        for (int i = 0; i < 5; i++)
        {
            a = Rcircles[i];
            b = Rcircles[i + 1];

            if (a > b)
            {
                int temp;
                temp = a;
                a = b;
                b = temp;
            }

            switch (a)
            {
                case 1:
                    RlineNum[i] = b - a;
                    break;

                case 2:
                    RlineNum[i] = b - a + 4;
                    break;

                case 3:
                    RlineNum[i] = b - a + 7;
                    break;

                case 4:
                    RlineNum[i] = 10;
                    break;

                default:
                    break;
            }
        }
        #endregion
        Array.Sort(RlineNum);


        startNwizCode = startDot.ToString()+RlineNum;
        return startNwizCode;
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