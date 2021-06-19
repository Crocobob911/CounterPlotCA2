using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LiveObject
{
    private void Awake()
    {
        _awake();
    }
    private void Start()
    {
        moveSpeed = 0.4f;
    }
    private void Update()
    {

    }
}
