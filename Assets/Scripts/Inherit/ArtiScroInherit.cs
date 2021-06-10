using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtiScroInherit : MonoBehaviour
{
    public FiguresNItem figuresNItem;
    public int id = 000;
    public bool isOn = false;
    private void TriggerOn()
    {
        isOn = true;
    }
    private void OnEnable()
    {
        isOn = false;
        Invoke("TriggerOn", 1);
    }
    void Awake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
    }
}
