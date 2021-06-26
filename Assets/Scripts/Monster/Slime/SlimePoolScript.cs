using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePoolScript : ObjectPool
{
    public void GetSlime(Vector2 pos)
    {
        var obj = GetObject();
        obj.transform.localPosition = pos;
        return;
    }
}
