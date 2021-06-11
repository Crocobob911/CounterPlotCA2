using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBox : ArtiScroInherit
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (isOn && figuresNItem.isColliderPlayer(collider))
        {
            if (figuresNItem.BoxOpen(id, transform.position))
                figuresNItem.ReturnBox(gameObject);
        }
    }
    private void Awake()
    {
        PlayAwake();
    }
    private void OnEnable()
    {
        PlayOnEnable();
    }
}
