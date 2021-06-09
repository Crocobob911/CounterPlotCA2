using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBox : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    public int id;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (figuresNItem.isColliderPlayer(collision.collider))
        {
            if (figuresNItem.BoxOpen(id, transform.position))
                figuresNItem.ReturnBox(gameObject);
        }
    }
    void Start()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
    }
    
}
