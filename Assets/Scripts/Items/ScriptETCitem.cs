using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptETCitem : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private FiguresNItem figuresNItem;
    public int id = 000;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (figuresNItem.isColliderPlayer(collision.collider))
        {
            figuresNItem.ApplyETCitem(id);
            figuresNItem.ReturnETCItem(gameObject);
        }
    }
    private void GravityOff()
    {
        rigidbody2D.gravityScale = 0;
    }

    void Awake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>(); ;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        int randNumx = Random.Range(-10 , 11);
        int randNumy = Random.Range(-2 , 3);
        rigidbody2D.AddForce((new Vector2(randNumx, randNumy).normalized)*2, ForceMode2D.Impulse );
        rigidbody2D.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        rigidbody2D.gravityScale = 1;
        Invoke("GravityOff", 0.6f);
    }
}
