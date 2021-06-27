using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastDirector : MonoBehaviour
{
    //CastUI에서 드로우가 끝나면, 그 점들의 값들을 받아와서 선의 값으로 바꾸는 일
    //바꾼 선에 값에 따른 위즈를 DB에서불러오는 일

    #region Singleton
    public static CastDirector instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    private IO iO;

    private int[] lineNumbers = new int[5];
    private string wizCode;
    public string Get_wizCode() { return wizCode; }

    private int EndCircle;
    public int Get_EndCircle() { return EndCircle; }


    private void Start()
    {
        iO = gameObject.transform.parent.transform.GetChild(2).GetComponent<IO>();
        Init();
    }

    private void Init()
    {
        wizCode = null;
        for(int i=0; i<5; i++)
        {
            lineNumbers[i] = 0;
        }
        EndCircle = 0;
    }


    public void PatternComplete(int[] circles)
    {
        DetectLine(circles);
        DetectWiz(lineNumbers);
        if (iO.IsOnIO == 0)
        {
            ActiveWiz();
        }
        else
        {
            iO.Set_wizCodeNendCircle(wizCode,EndCircle);
        }
        Init();
    }

    public void ActiveWiz()
    {
    }

    private void DetectLine(int[] circles)
    {
        //Debug.Log("circles : "+circles[0] + " " + circles[1] + " " + circles[2] + " " + circles[3] + " " + circles[4] + " " + circles[5]);
        
        #region NumberDetecting
        int a, b;
        for(int i = 0; i<5; i++)
        {
            a = circles[i];
            b = circles[i + 1];

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
                    lineNumbers[i] = b - a;
                    break;

                case 2:
                    lineNumbers[i] = b - a + 4;
                    break;

                case 3:
                    lineNumbers[i] = b - a + 7;
                    break;

                case 4:
                    lineNumbers[i] = 10;
                    break;

                default:
                    break;
            }
        }
        #endregion

        for (int i=0; i<circles.Length ; i++)
        {
            if(circles[i] == 0)
            {
                EndCircle = circles[i - 1];
                break;
            }
        }

        Array.Sort(lineNumbers);

        //Debug.Log("lineNumbers : "+ lineNumbers[0] + " " + lineNumbers[1] + " " + lineNumbers[2] + " " + lineNumbers[3] + " " + lineNumbers[4]);
    } // 라인 정리하는 것

    private void DetectWiz(int[] lines)  
    {
        for (int i = 0; i < 5; i++)
        {
            wizCode += lines[i];
        }
        Debug.Log("wizCode : "+wizCode);
    }   // 코드 만드는 것
}
