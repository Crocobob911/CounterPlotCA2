using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArtifact : ArtiScroInherit
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (isOn && figuresNItem.isColliderPlayer(collider))
        {
            figuresNItem.ApplyArtifact2Player(id);
            figuresNItem.ReturnArtifact(gameObject);
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
