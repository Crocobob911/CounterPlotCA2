using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScroll : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    public int id = 000;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (figuresNItem.isColliderPlayer(collider))
        {
            figuresNItem.ApplyScroll2Player(id);
            figuresNItem.ReturnScro(gameObject);
        }
    }
    void Awake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
    }
}
