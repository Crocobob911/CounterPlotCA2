using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBox : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        figuresNItem.BoxOpen(transform.position);
        Destroy(gameObject);
    }
    void Start()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
    }
    
}
