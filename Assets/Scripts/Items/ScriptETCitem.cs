using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptETCitem : ArtiScroInherit
{
    private Rigidbody2D r;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (isOn && figuresNItem.isColliderPlayer(collider))
        {
            figuresNItem.ApplyETCitem(id);
            figuresNItem.ReturnETCItem(gameObject);
        }
    }
    private void GravityOff()
    {
        r.gravityScale = 0;
    }

    private void Awake()
    {
        PlayAwake();
        r = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        PlayOnEnable();
        int randNumx = Random.Range(-10 , 11);
        int randNumy = Random.Range(-1 , 2); 
        r.AddForce((new Vector2(randNumx, randNumy).normalized)*2, ForceMode2D.Impulse );
        r.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        r.gravityScale = 1;
        Invoke("GravityOff", 0.6f);
    }
}
