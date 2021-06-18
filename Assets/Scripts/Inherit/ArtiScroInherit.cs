using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtiScroInherit : MonoBehaviour
{
    public FiguresNItem figuresNItem;
    public int id = 000;
    public bool isOn = false;
    public float y = 0f;
    
    private void TriggerOn()
    {
        isOn = true;
    }
    public void PlayOnEnable()
    {
        isOn = false;
        Invoke("TriggerOn", 1);
        
    }
    public void PlayAwake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
    }
}
