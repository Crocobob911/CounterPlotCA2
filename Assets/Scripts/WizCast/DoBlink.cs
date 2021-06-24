using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoBlink : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private MoveStickArea moveStickUI;

    public void Blink(){
        player.Translate(moveStickUI.MoveVec * moveStickUI.MoveDis / 50);
    }
}
