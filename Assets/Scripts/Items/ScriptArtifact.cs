using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArtifact : ArtiScroInherit
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (figuresNItem.isColliderPlayer(collider))
        {
            figuresNItem.ApplyArtifact2Player(id);
            figuresNItem.ReturnArtifact(gameObject);
        }
    }
}
