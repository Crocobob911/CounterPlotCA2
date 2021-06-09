using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPoolScript : ObjectPool
{
    public void GetScro(Vector2 pos, int id, Sprite sp)
    {
        var obj = GetObject();
        var C_A = obj.GetComponent<ScriptScroll>();
        var C_S = obj.GetComponent<SpriteRenderer>();
        obj.transform.localPosition = pos;
        C_A.id = id;
        C_S.sprite = sp;
        return;
    }
}
