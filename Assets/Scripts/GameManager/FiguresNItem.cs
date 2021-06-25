using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresNItem : MonoBehaviour
{
    [SerializeField] private GameObject GO_Player;
    [SerializeField] private GameObject GO_ArtifactPool;
    [SerializeField] private GameObject GO_ETCItemPool;
    [SerializeField] private GameObject GO_ScrollPool;
    [SerializeField] private GameObject GO_BoxPool;
    [SerializeField] private GameObject GO_MonsterPool;

    private ApplyArtifacts aa;
    private UIManage um;
    private ArtifactPoolScript artifactPoolScript;
    private ETCItemPoolScript eTCItemPoolScript;
    private ScrollPoolScript scrollPoolScript;
    private BoxPoolScript boxPoolScript;
    private SlimePoolScript slimePoolScript;

    private int mHealth = 125;
    private int pHealth = 1;
    private int mMana = 125;
    private float pMana = 0;
    private float manaResen =10;
    private int offenPoint = 125;
    private int defenPoint = 0;
    //private int evaPoint=0;
    //private float charSpeed=0.5f;
    //private float charSize=100;
    private int pGold = 5;
    private int goldDropRate = 10;         //max :20
    private int ThreeGoldDropRate = 10;
    private int pWizstone = 2;
    private int wizstoneDropRate = 5;    //max : 10
    private int chestAppearRate = 100;     //max : 10
    private int HPpotionDropRate = 5;    //max : 10
    private int BigHPotionDropRate = 10; //일단은 고정치
    private int MPpotionDropRate = 5;   //max : 10
    //private int castingNum=1;

    public void Delta_mHealth(int delta)    {  if (mHealth + delta < 1) { mHealth = 1; pHealth = 1; } else { mHealth += delta; pHealth += delta; } um.HPbar_SizeChange(mHealth); um.HPbar_Synchro(mHealth, pHealth); }
    public int Get_mHealth()                { return mHealth; }
    public void Delta_pHealth(int delta)    { if (pHealth + delta < 0) { pHealth = 0; PlayerDeath(); } else if (pHealth + delta > mHealth) { pHealth = mHealth; } else { pHealth += delta; } um.HPbar_Synchro(mHealth, pHealth); }
    public int Get_pHealth()                { return pHealth; }
    
    public void Delta_mMana(int delta)  { if (mMana + delta < 1) { mMana = 1; pMana = 1; } else { mMana += delta; pMana += delta; } um.MPbar_SizeChange(mMana); um.MPbar_Synchro(mMana, pMana); }
    public int Get_mMana()              { return mMana; }
    public bool Delta_pMana(float delta){ bool isGood = true;if (pMana + delta < 0) { isGood = false; return isGood; } else if (pMana + delta > mMana) { pMana = mMana;} else pMana += delta; um.MPbar_Synchro(mMana, pMana); return isGood;  }
    public float Get_pMana()            { return pMana; }

    public void Delta_manaResen(int delta) { if (manaResen + delta < 1) manaResen = 1; else if (manaResen + delta > 50) manaResen = 100; else manaResen += delta; }
    private void ResenerateMana()
    {
        Delta_pMana(manaResen/5);
    }
    private void Do_manaResen() 
    {
        InvokeRepeating("ResenerateMana", 0f, 0.2f);
    }
    /*private void Stop_manaResen()
    {
        CancelInvoke("ResenerateMana");
    }*/
    
    private void PlayerDeath()
    {
        //캐릭터 사망 (캐릭터 오브젝트 삭제)
        //UI 쪽 스크립트에서 관련 함수 호출
    }

    public void AppearArti(Vector2 position) //아티팩트 등장
    {
        int id = RandArti();
        artifactPoolScript.GetArti(position, id, ApplySprite(id));
    }
    public int RandArti()
    {
        int id = 0, rarity = 0, randInt=0;

        // 아티팩트 등급 결정 부분
        randInt = Random.Range(0, 100);
        if      (randInt < 55)  rarity = 0;  //일반 : 55%
        else if (randInt < 80)  rarity = 1;  //레어 : 25%
        else if (randInt < 95)  rarity = 2;  //에픽 : 15%
        else                    rarity = 3;  //전설 : 5%

        // 동일 등급 내, 아티팩트 id 결정 함수
        switch (rarity)
        {
            case 0:
                id = Random.Range(001,002);
                break;
            case 1:
                id = Random.Range(101, 104);
                break;
            case 2:
                id = Random.Range(201, 205);
                break;
            case 3:
                id = Random.Range(301, 302);
                break;
        }
        return id;
    }  //아티팩트 등장 시(상자, 상점, 유적 클리어 등) 등급과 아티팩트 id 결정부분
    public void ApplyArtifact2Player(int id)
    {
        string ArtiName = id.ToString();
        if (id < 10)
            ArtiName = '0'+ ArtiName;
        if (id < 100)
            ArtiName = "C0" + ArtiName;   // Common
        else if (id < 200)
            ArtiName = 'R' + ArtiName;    // Rare
        else if (id < 300)
            ArtiName = 'E' + ArtiName;    // Epic
        else if (id < 400)
            ArtiName = 'L' + ArtiName;    // Legendary

        aa.CallArti(ArtiName); // 아티팩트 효과 적용 부분
        
        // 인벤토리에 id 전달하면서 적용하라고 특정 함수 호출
    }
    public void ReturnArtifact(GameObject GO)
    {
        artifactPoolScript.ReturnObject(GO);
    }

    public void AppearScroll(Vector2 position) // 스크롤 등장
    {
        int id = RandScroll();
        scrollPoolScript.GetScro(position, id, ApplySprite(id));
    }
    public int RandScroll() //스크롤 등장 시(상점, 유적클리어 등) 등급과 위즈 id 결정부분
    {
        int id = 500;
        return id;
    }
    public void ApplyScroll2Player(int id) // 스크롤 획득 시 위즈 사용 가능으로 변경 및 인벤토리 이동
    {

    }
    public void ReturnScro(GameObject GO)
    {
        scrollPoolScript.ReturnObject(GO);
    }

    public void AppearETCitem(int monsterType, Vector2 position) // 0 일반몬스터 1 엘리트 몬스터  // 엘리트 몬스터면 꽝 확률 -20%
    {
        int randNum = Random.Range(0,100-(monsterType*20));
        if (randNum < goldDropRate + wizstoneDropRate + HPpotionDropRate + MPpotionDropRate)
        {
            int id = RandETCitem();
            eTCItemPoolScript.GetETCi(position, id, ApplySprite(id));
            return;
        }
        return ;
    }
    public int RandETCitem()
    {
        int id = 600, randNum = Random.Range(0, goldDropRate + wizstoneDropRate + HPpotionDropRate + MPpotionDropRate);
        if (randNum <= 0 + HPpotionDropRate) //체력포션
        { 
            if (Percent(BigHPotionDropRate)) id = 601;      //대형 체력포션 등장 601
            else id = 602;  //일반 체력포션 등장 602
        }
        else if (randNum <= HPpotionDropRate + MPpotionDropRate)
            id = 603;//마나포션 등장 603
        else if (randNum <= HPpotionDropRate + MPpotionDropRate + goldDropRate) //골드
        {
            if (Percent(ThreeGoldDropRate)) id = 604; //골드 묶음(3개) 등장  604
            else id = 605;//골드 1개 등장  605
        }
        else if (randNum <= HPpotionDropRate + MPpotionDropRate + goldDropRate + wizstoneDropRate)
            id = 606;//위즈스톤 1개 등장 606
        return id;
    } // 몬스터 사망 시, 상자 오픈 시(?)_일단은// 기타 아이템 등장 확률
    public void ApplyETCitem(int id)
    {
        switch (id)
        {
            case 601:
                Delta_pHealth(100); // 체력포션 (대)
                break;
            case 602:
                Delta_pHealth(50); // 체력포션 (소)
                break;
            case 603:
                Delta_pMana(100); // 마나포션 
                break;
            case 604:
                pGold += 3;    //골드 3개
                break;
            case 605:
                pGold += 1;     //골드 1개
                break;
            case 606:
                pWizstone++;      //위즈스톤 1개
                break;
        }
        return;
        //체력포션, 마나포션, 골드, 위즈스톤 적용
    } // 기타 아이템 획득 시 플레이어, 골드 개수 등 수치 변경
    public void ReturnETCItem(GameObject GO)
    {
        eTCItemPoolScript.ReturnObject(GO);
    }

    public void AppearBoxTest()
    {
        boxPoolScript.GetBox(new Vector2(0,0), 611, ApplySprite(611));
    }
    public void AppearBox(int AreaType, Vector2 position) //구역 클리어 시
    {
        int id = -1;
        id = DecisionBoxType(AreaType);
        if (id == -1)
            return;
        boxPoolScript.GetBox(position, id, ApplySprite(id));
    }
    public int DecisionBoxType(int AreaType)
    {
        int id = -1;  // 611= 상자 / 612= 잠긴상자 -1=없음
        if (AreaType == 0) //일반 구역 클리어(몬스터 처치)
        {
            if (Percent(chestAppearRate))
                return id = 611;
            return id = -1;
        }
        else if (AreaType == 1 || AreaType == 2 || AreaType == 3) // 숨겨진 구역 클리어(보스 및 몬스터 처치)
        {
            return id = 612;
        }
        return id;
    }
    public bool BoxOpen(int id, Vector2 position)
    {
        bool isOpen = false;
        if (id == 611) //일반상자 611
        {
            AppearArti(position);
            AppearETCitem(0, position);
            return isOpen = true;
        }
        if (id == 612 && pWizstone > 0) //닫힌상자 612
        {
            pWizstone--;
            AppearArti(position);
            AppearETCitem(0, position);
            isOpen = true;
        }
        return isOpen;
    }
    public void ReturnBox(GameObject GO)
    {
        boxPoolScript.ReturnObject(GO);
    }

    private Sprite ApplySprite(int id)
    {
        if (id / 100 == 0)
        {
            return Resources.Load<Sprite>("Sprites/Artifacts/Common/" + id);
        }
        if (id / 100 == 1)
        {
            return Resources.Load<Sprite>("Sprites/Artifacts/Rare/" + id);
        }
        if (id / 100 == 2)
        {
            return Resources.Load<Sprite>("Sprites/Artifacts/Epic/" + id);
        }
        if (id / 100 == 3)
        {
            return Resources.Load<Sprite>("Sprites/Artifacts/Legendary/" + id);
        }
        if (id / 100 == 5)
        {
            return Resources.Load<Sprite>("Sprites/Scrolls/" + id);
        }
        if (id / 100 == 6)
        {
            return Resources.Load<Sprite>("Sprites/ETCitems/"+id);
        }
        return Resources.Load<Sprite>("Sprites/Artifacts/0");
    } // 모든 아이템 등장 시 스프라이트 적용(필드에 등장 or 인벤에 표현
 
    public bool isColliderPlayer(Collider2D coll){
        bool isIt = false;
        if (coll.gameObject == GO_Player) isIt = true;
        return isIt;
    }

    private bool Percent(int r)
    {
        int randNum = Random.Range(0, 100);
        if(randNum < r)
            return true;
        return false;
    } //퍼센트 계산기
    
    void Awake()
    {
        aa = GetComponent<ApplyArtifacts>();
        um = gameObject.GetComponent<UIManage>();
        artifactPoolScript = GO_ArtifactPool.GetComponent<ArtifactPoolScript>();
        eTCItemPoolScript = GO_ETCItemPool.GetComponent<ETCItemPoolScript>();
        scrollPoolScript = GO_ScrollPool.GetComponent<ScrollPoolScript>();
        boxPoolScript = GO_BoxPool.GetComponent<BoxPoolScript>();
        slimePoolScript = GO_MonsterPool.GetComponent<SlimePoolScript>();
    }

    void Start()
    {
        slimePoolScript.GetSlime(new Vector2(-7, 7));
        AppearArti(new Vector2(-5, 5));
        AppearETCitem(3, new Vector2(3, 0));
        AppearETCitem(3, new Vector2(3, -3));
        AppearETCitem(3, new Vector2(-3, -3));
        AppearETCitem(3, new Vector2(3, 3));
        AppearScroll(new Vector2(4, 4));
        AppearBox(0, new Vector2(-4, -4));
        AppearBox(1, new Vector2(0, -4));
        AppearBox(2, new Vector2(4, -4));
        AppearBox(3, new Vector2(-4, 4));
        Do_manaResen();
        um.HPbar_Synchro(mHealth, pHealth);
        um.MPbar_Synchro(mMana, pMana);
    }

    void Update()
    {
        um.FiguresSend(mHealth,pHealth,mMana,pMana,offenPoint,defenPoint,pGold,pWizstone);
    }
}

