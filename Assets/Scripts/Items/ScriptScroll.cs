using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScroll : ArtiScroInherit
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (isOn && figuresNItem.isColliderPlayer(collider))
        {
            figuresNItem.ApplyScroll2Player(id);
            figuresNItem.ReturnScro(gameObject);
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
