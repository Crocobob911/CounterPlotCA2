using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyArtifacts : MonoBehaviour  // 세트효과 카운트, 아티팩트 적용 함수
{
    [SerializeField] private GameObject GO_Player;
    private Transform t;
    private FiguresNItem fni;
    private Player p;

    private struct SetEffect
    {
        private string setName;
        private int setCount;
        private bool isApplied;

        public void Init(string _setName)
        {
            setName = _setName;
            isApplied = false;
            setCount = 0;
        }
        public string GetsetName()
        {
            return setName;
        }
        public void OnisApplied()
        {
            isApplied = true;
        }
        public bool GetisApplied()
        {
            return isApplied;
        }
        public void UpsetCount()
        {
            setCount++;
        }
        public int GetsetCount()
        {
            return setCount;
        }
    };

    private SetEffect Boaster,
                Genius,
                Coward,
                Grandmaster,
                Bugfriends,
                Guardian,
                Soldier,
                Animalfriends,
                Mysteriousthief,
                Lightmaster; 

    private void InitSetEffect()
    {
        Boaster.Init("Boaster");
        Genius.Init("Genius");
        Coward.Init("Coward");
        Grandmaster.Init("Grandmaster");
        Bugfriends.Init("Bugfriends");
        Guardian.Init("Guardian");
        Soldier.Init("Soldier");
        Animalfriends.Init("Animalfriends");
        Mysteriousthief.Init("Mysteriousthief");
        Lightmaster.Init("Lightmaster");
    }
    public void CallArti(string Arti)
    {
        Invoke(Arti, 0f);
    }
    private void CallSetEffect(SetEffect setEffect)
    {
        if (setEffect.GetsetCount() >= 3 &&  setEffect.GetisApplied() == false)
            Invoke("Apply"+setEffect.GetsetName(), 0f);
    }

    // Common
    private void C000()
    {

    }
    private void C001()
    {
        t.position = new Vector3(0, 0, 0);
        fni.Delta_pHealth(-50);
        fni.Delta_pMana(-50);
        fni.Delta_mHealth(100);
        fni.Delta_mMana(100);
        return;
    }
    private void C002()
    {

    }
    // Rare
    // Epic
    // Legendary

    // SetEffect 
    private void ApplyBoaster()
    {
        Boaster.OnisApplied();
    }
    private void ApplyGenius()
    {
        Genius.OnisApplied();
    }
    private void ApplyCoward()
    {
        Coward.OnisApplied();
    }
    private void ApplyGrandmaster()
    {
        Grandmaster.OnisApplied(); 
    }
    private void ApplyBugfriends()
    {
        Bugfriends.OnisApplied();
    }
    private void ApplyGuardian()
    {
        Guardian.OnisApplied();
    }
    private void ApplySoldier()
    {
        Soldier.OnisApplied();
    }
    private void ApplyAnimalfriends()
    {
        Animalfriends.OnisApplied();
    }
    private void ApplyMysteriousthief()
    {
        Mysteriousthief.OnisApplied();
    }
    private void ApplyLightmaster()
    {
        Lightmaster.OnisApplied();
    }

    void Awake()
    {
        fni = GetComponent<FiguresNItem>();
        p = GO_Player.GetComponent<Player>();
        t = GO_Player.GetComponent<Transform>();
    }
    private void Start()
    {
        InitSetEffect();
    }

}
