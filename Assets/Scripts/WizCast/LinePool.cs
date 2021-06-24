using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePool : ObjectPool
{
    public CircleId GetLine(Vector3 pos, int id)
    {
        var obj = GetObject().GetComponent<CircleId>();
        obj.gameObject.transform.localPosition = pos;
        obj.id = id;
        //Debug.Log("LinePool : " + id + " line on");
        return obj;
    }
}
