using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArtifact : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    private int id = 000;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (figuresNItem.isColliderPlayer(collider))
        {
            figuresNItem.ApplyArtifact2Player(id); //캐릭터(rigidbody2D를 가진 애)가 먹으면 게임매니저에게 값 전달(id)
            Destroy(gameObject); //게임 오브젝트 소멸
        }
    }
    void Awake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
        id = figuresNItem.RandArti(GetComponent<SpriteRenderer>());
    }
}
