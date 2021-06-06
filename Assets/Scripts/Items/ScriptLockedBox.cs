using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLockedBox : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (figuresNItem.isColliderPlayer(collision.collider)){
            if (figuresNItem.LockedBoxOpen(transform.position))
                Destroy(gameObject);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (figuresNItem.isColliderPlayer(collider))
        {
            if (figuresNItem.LockedBoxOpen(transform.position))
                Destroy(gameObject);
        }
    }*/
    void Start()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
    }
    
}
