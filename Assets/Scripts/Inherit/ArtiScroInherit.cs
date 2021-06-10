using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtiScroInherit : MonoBehaviour
{
    public FiguresNItem figuresNItem;
    private CircleCollider2D circleCollider2D;
    public int id = 000;
    private void TriggerOn()
    {
        circleCollider2D.isTrigger = true;
    }
    private void OnEnable()
    {
        circleCollider2D.isTrigger = false;
        Invoke("TriggerOn", 1);
    }
    /*private void OnDisable()
    {
        circleCollider2D.isTrigger = false;
    }*/ //굳이 안써도 되는 부분일거 같긴 한데 명시하기 위해 적어야하나? 생각해서 일단 주석처리
    void Awake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
}
