using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptETCitem : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    private int id = 000;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        figuresNItem.ApplyETCitem(id);
        Destroy(gameObject);
    }
    void Awake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>(); ;
        id = figuresNItem.RandETCitem(GetComponent<SpriteRenderer>());
    }
}
