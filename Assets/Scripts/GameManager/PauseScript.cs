using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPause = false;

    public void SetPause()
    {
        if (!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
        }
    }
    public void Continue()
    {
        if (isPause)
        {
            isPause = false;
            Time.timeScale = 1;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetPause();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            Continue();
        }
    }
}
