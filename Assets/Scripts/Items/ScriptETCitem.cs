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
            figuresNItem.ReturnETCItem(transform.parent.gameObject);
        }
    }

    private void Awake()
    {
        PlayAwake();
        r = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        PlayOnEnable();
    }
}
