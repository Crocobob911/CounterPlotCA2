using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoBlink : MonoBehaviour
{
    [SerializeField] private GameObject GO_Player;
    [SerializeField] private GameObject GO_MoveStick;
    private Transform t;
    private MoveStickArea m;
    // Start is called before the first frame update
    void Awake()
    {
        t = GO_Player.GetComponent<Transform>();
        m = GO_MoveStick.GetComponent<MoveStickArea>();
    }
    public void Blink(){
        t.Translate(m.Get_moveVec() * m.Get_moveDis() / 50);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
