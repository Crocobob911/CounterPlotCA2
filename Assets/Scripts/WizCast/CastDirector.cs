using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastDirector : MonoBehaviour
{
    //CastUI에서 드로우가 끝나면, 그 점들의 값들을 받아와서 선의 값으로 바꾸는 일
    //바꾼 선에 값에 따른 위즈를 DB에서불러오는 일

    [SerializeField] private CastPattern castUI;

    private int[] lineNumbers = new int[5];
    private string wizCode;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        wizCode = null;
        for(int i=0; i<5; i++)
        {
            lineNumbers[i] = 0;
        }
    }

    public void ActiveWiz(int[] circles)
    {
        DetectLine(circles);
        DetectWiz(lineNumbers);

        Init();
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
        Array.Sort(lineNumbers);

        //Debug.Log("lineNumbers : "+ lineNumbers[0] + " " + lineNumbers[1] + " " + lineNumbers[2] + " " + lineNumbers[3] + " " + lineNumbers[4]);
    }

    private void DetectWiz(int[] lines)
    {
        for (int i = 0; i < 5; i++)
        {
            wizCode += lines[i];
        }
        Debug.Log("wizCode : "+wizCode);
    }
}
