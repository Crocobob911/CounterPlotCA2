using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : LiveObject
{
    protected int monsterID;
    public int MonsterID
    {
        get { return monsterID; }
        set { monsterID = value; }
    }

    protected int monsterState;
    public int MonsterState
    {
        get { return monsterState; }
        set { monsterState = value; }
    }


}
