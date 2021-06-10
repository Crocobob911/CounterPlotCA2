using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptETCitem : ArtiScroInherit
{
    private Rigidbody2D r;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (figuresNItem.isColliderPlayer(collider))
        {
            figuresNItem.ApplyETCitem(id);
            figuresNItem.ReturnETCItem(gameObject);
        }
    }
    private void GravityOff()
    {
        r.gravityScale = 0;
    }

    void Awake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
        r = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        int randNumx = Random.Range(-10 , 11);
        int randNumy = Random.Range(-2 , 3);
        r.AddForce((new Vector2(randNumx, randNumy).normalized)*2, ForceMode2D.Impulse );
        r.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        r.gravityScale = 1;
        Invoke("GravityOff", 0.6f);
    }
}
