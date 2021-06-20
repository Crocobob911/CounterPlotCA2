using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawnNDeath : MonoBehaviour
{
    private SlimePoolScript slimePoolScript;

    private void Awake()
    {
        slimePoolScript = GetComponent<SlimePoolScript>();
    }
    public void MakeSlime()
    {
        slimePoolScript.GetSlime(new Vector2( Random.Range(-10,10), Random.Range(-10,10)));
    }
    public void SlimeDeath()
    {
        //slimePoolScript.ReturnObject(gameObject);
    }
    void Update()
    {
        
    }
}
