using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETCItemMove : MonoBehaviour
{
    private Rigidbody2D r, rr;

    void Awake()
    {
        r = GetComponent<Rigidbody2D>();
        rr = transform.GetChild(0).GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        int randNumx = Random.Range(-4, 4);
        r.AddForce(new Vector2(randNumx, 0), ForceMode2D.Impulse);
        rr.AddForce(new Vector2(randNumx, 0), ForceMode2D.Impulse); 
    }
    
}
