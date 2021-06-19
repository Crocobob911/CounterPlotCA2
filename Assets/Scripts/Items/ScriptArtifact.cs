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
            figuresNItem.ReturnArtifact(transform.parent.gameObject);
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
    private void Update()
    {
        gameObject.transform.Translate(new Vector3(0, y, 0));
    }
}
