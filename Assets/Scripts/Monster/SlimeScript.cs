using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    private Transform t;
    private SlimePoolScript s;
    
    private int health = 0; public void delta_Health(int d) { health += d; }
    private int damage = 20;
    public float y;

    private void init()
    {
        y = 0.0f;
        health = 125;
    }
    private void OnEnable()
    {
        init();
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
        s = gameObject.transform.parent.parent.GetComponent<SlimePoolScript>();
        t = gameObject.transform.parent.GetComponent<Transform>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (figuresNItem.isColliderPlayer(collision))
        {
            //플레이어에게 damage 만큼 피해 주기
            figuresNItem.Delta_pHealth(-damage);
            health -= 100;
            if (health < 0)
            {
                s.ReturnObject(gameObject.transform.parent.gameObject);
            }
        }
    }
    private void Update()
    {
        Jump();
    }
    private void Jump()
    {
        gameObject.transform.localPosition = new Vector2(0, y);
    }
}
