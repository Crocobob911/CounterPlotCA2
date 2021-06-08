using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPoolScript : ObjectPool
{
    public void GetArti(Vector2 pos, int id, Sprite sp)
    {
        var obj = GetObject();
        var C_A = obj.GetComponent<ScriptArtifact>();
        var C_S = obj.GetComponent<SpriteRenderer>();
        obj.transform.localPosition = pos;
        C_A.id = id;
        C_S.sprite = sp;
        return;
    }
}
