using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePool : ObjectPool
{
    #region Singleton
    public static LinePool instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public CircleId GetLine(Vector3 pos, int id)
    {
        var obj = GetObject().GetComponent<CircleId>();
        //Debug.Log(obj);
        obj.gameObject.transform.localPosition = pos;
        obj.id = id;
        return obj;
    }
}
