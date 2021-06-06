using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBox : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (figuresNItem.isColliderPlayer(collision.collider)){
            figuresNItem.BoxOpen(transform.position);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
    }
    
}
