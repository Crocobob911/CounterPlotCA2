using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LiveObject : MonoBehaviour
{
    
    public float moveSpeed;

    public void Move(Vector3 rot)
    {
        transform.Translate(rot * moveSpeed * Time.deltaTime);
    }
}
