using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScroll : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    private int id = 000;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (figuresNItem.isColliderPlayer(collider))
        {
            figuresNItem.ApplyScroll2Player(id);
            Destroy(gameObject);
        }
    }
    void Awake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
        //id = figuresNItem.RandScroll(GetComponent<SpriteRenderer>());
    }
}
