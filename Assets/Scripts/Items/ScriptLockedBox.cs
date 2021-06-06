using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLockedBox : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (figuresNItem.LockedBoxOpen(transform.position))
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
    }
    
}
