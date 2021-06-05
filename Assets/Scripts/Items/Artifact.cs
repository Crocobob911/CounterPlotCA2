using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    private FiguresNItem figuresNItem;
    private int id = 000;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        figuresNItem.ApplyArtifact2Player(id); //캐릭터(rigidbody2D를 가진 애)가 먹으면 게임매니저에게 값 전달(id)
        Destroy(gameObject); //게임 오브젝트 소멸
    }
    void Awake()
    {
        figuresNItem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FiguresNItem>();
        id = figuresNItem.RandArti(GetComponent<SpriteRenderer>());// 1. 등급과 아티팩트 id 정하는 함수 호출 및 저장 (얘가 스프라이트 적용까지 함)
    }
}
