using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManage : MonoBehaviour
{
    [SerializeField] private GameObject GO_figuresUI;
    private Text t;

    public void FiguresSend(int mHealth, 
                            int pHealth,
                            int mMana, 
                            float pMana, 
                            int offenPoint,
                            int defenPoint,
                            int pGold,
                            int pWizstone)
    {
        t.text = "Max_HP    = " + mHealth + "\n" +
                 "Pre_HP    = " + pHealth + "\n" +
                 "Max_MP    = " + mMana + "\n" +
                 "Pre_MP    = " + pMana + "\n" +
                 "OP        = " + offenPoint + "\n" +
                 "DP        = " + defenPoint + "\n" +
                 "Gold      = " + pGold+ "\n" +
                 "WizStone  = " + pWizstone + "\n";
    }


    void Start()
    {
        t = GO_figuresUI.GetComponent<Text>();
    }
    
    void Update()
    {
    }
}
