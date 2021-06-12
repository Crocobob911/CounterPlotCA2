using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManage : MonoBehaviour
{
    [SerializeField] private GameObject GO_figuresUI;
    [SerializeField] private GameObject GO_HPbar;
    [SerializeField] private GameObject GO_MPbar;

    private Text text;
    private Slider HP_s, MP_s;
    private RectTransform HP_rt, MP_rt;


    public void FiguresSend(int mHealth, 
                            int pHealth,
                            int mMana, 
                            float pMana, 
                            int offenPoint,
                            int defenPoint,
                            int pGold,
                            int pWizstone)
    {
        text.text = "Max_HP    = " + mHealth + "\n" +
                 "Pre_HP    = " + pHealth + "\n" +
                 "Max_MP    = " + mMana + "\n" +
                 "Pre_MP    = " + pMana + "\n" +
                 "OP        = " + offenPoint + "\n" +
                 "DP        = " + defenPoint + "\n" +
                 "Gold      = " + pGold+ "\n" +
                 "WizStone  = " + pWizstone + "\n";
    }
    public void HPbar_SizeChange(int mHealth)
    {
        float x = HP_rt.position.x, y = HP_rt.position.y;
        HP_rt.position = new Vector2(x+(2f * (mHealth) - HP_rt.sizeDelta.x) / 2,y);
        HP_rt.sizeDelta = new Vector2(2f*(mHealth), 100);

    }
    public void HPbar_Synchro(int mHealth, int pHealth)
    {
        HP_s.value = pHealth / (float)mHealth;
    }
    public void MPbar_SizeChange(int mMana)
    {
        float x = MP_rt.position.x, y = MP_rt.position.y;
        MP_rt.position = new Vector2(x + (2f * (mMana) - MP_rt.sizeDelta.x) / 2, y);
        MP_rt.sizeDelta = new Vector2(2f * (mMana), 100);

    }
    public void MPbar_Synchro(int mMana, float pMana)
    {
       float a = mMana / pMana;
        MP_s.value = 1 / a;
    }
    void Awake()
    {
        text = GO_figuresUI.GetComponent<Text>();

        HP_s = GO_HPbar.GetComponent<Slider>();
        HP_s.value = 0f;
        HP_rt = GO_HPbar.GetComponent<RectTransform>();

        MP_s = GO_MPbar.GetComponent<Slider>();
        MP_s.value = 0f;
        MP_rt = GO_MPbar.GetComponent<RectTransform>();
    }
    
    void Update()
    {
    }
}
