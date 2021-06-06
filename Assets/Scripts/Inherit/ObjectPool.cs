using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //wergia.tistory.com/203  모르면 여기로

    [SerializeField] protected GameObject poolObjPrefab;
    [SerializeField] protected int poolLength;

    protected Queue<GameObject> poolObjs = new Queue<GameObject>();

    protected void Start()
    {
        MakePool(poolLength);
    }

    protected void MakePool(int objectCount)
    {
        for(int i = 0; i<objectCount; i++)
        {
            poolObjs.Enqueue(CreateNewObject());
        }
    }

    protected GameObject CreateNewObject()
    {
        var newObj = Instantiate(poolObjPrefab, transform);
        newObj.SetActive(false);

        return newObj;
    }

    public virtual GameObject GetObject()
    {
        var obj = poolObjs.Dequeue();
        obj.gameObject.SetActive(true);

        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        poolObjs.Enqueue(obj);
    }
}
