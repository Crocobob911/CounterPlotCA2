using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScroll : ArtiScroInherit
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (figuresNItem.isColliderPlayer(collider))
        {
            figuresNItem.ApplyScroll2Player(id);
            figuresNItem.ReturnScro(gameObject);
        }
    }
}
