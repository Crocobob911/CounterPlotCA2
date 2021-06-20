using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceObjectState
{
    void ChangeMoveAnima(Vector3 rot);
    int DecideMoveState(Vector3 rot);
}