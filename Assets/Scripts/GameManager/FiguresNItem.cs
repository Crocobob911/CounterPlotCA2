using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresNItem : MonoBehaviour
{
    [SerializeField] private GameObject GO_Player; // 아티팩트 적용 테스트 용도로 잠시 할당
    [SerializeField] private GameObject GO_Arti;
    [SerializeField] private GameObject GO_ETCi;
    [SerializeField] private GameObject GO_Scro;
    [SerializeField] private GameObject GO_Box;
    [SerializeField] private GameObject GO_LockedBox;
    [SerializeField] private GameObject GO_ArtifactPool;

    private UIManage um;
    private ArtifactPoolScript artifactPoolScript;

    private int mHealth = 125;
    private int pHealth = 125;
    private int mMana = 125;
    private float pMana = 125;
    //private float manaResen =25;
    private int offenPoint=125;
    private int defenPoint=0;
    //private int evaPoint=0;
    //private float charSpeed=0.5f;
    //private float charSize=100;
    private int pGold =5;
    private int goldDropRate = 10;         //max :20
    private int ThreeGoldDropRate = 10;
    private int pWizstone=2;
    private int wizstoneDropRate = 5;    //max : 10
    private int chestAppearRate = 100;     //max : 10
    private int HPpotionDropRate = 5;    //max : 10
    private int BigHPotionDropRate = 10; //일단은 고정치
    private int MPpotionDropRate = 5;   //max : 10
                                        //private int castingNum=1;

    public void ReturnArtifact(GameObject GO)
    {
        artifactPoolScript.ReturnObject(GO);
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

    public void AppearScroll(Vector2 position) // 스크롤 등장
    {
        Instantiate(GO_Scro, position, Quaternion.identity);
    }
    /*public int RandScroll(SpriteRenderer sp) //스크롤 등장 시(상점, 유적클리어 등) 등급과 위즈 id 결정부분
    {
        int id = 500;
        ApplySprite(id, sp);
        return id;
    }
    */
    public void AppearETCitem(int monsterType, Vector2 position) // 0 일반몬스터 1 엘리트 몬스터  // 엘리트 몬스터면 꽝 확률 -20%
    {
        int randNum = Random.Range(0,100-(monsterType*20));
        if (randNum < goldDropRate + wizstoneDropRate + HPpotionDropRate + MPpotionDropRate)
        {
            Instantiate(GO_ETCi, position, Quaternion.identity);
            return;
        }
        return ;
    } // 몬스터 사망 시, 상자 오픈 시(?)_일단은// 기타 아이템 등장 확률
    /*public int RandETCitem(SpriteRenderer sp)
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
        ApplySprite(id, sp);  // id에 해당하는 스프라이트 적용
        return id;
    } // 몬스터 사망 시, 상자 오픈 시(?)_일단은// 기타 아이템 등장 확률
    */
    public void AppearBox(int AreaType, Vector2 position) //구역 클리어 시
    {
        if (AreaType == 0) //일반 구역 클리어(몬스터 처치)
        {
            if (Percent(chestAppearRate))//상자 나올 확률은 chestAppearRate 수치에 따라 달라짐
            {
                Instantiate(GO_LockedBox, position, Quaternion.identity);
                return;
            }
            return;
        }
        else if(AreaType == 1 || AreaType == 2 || AreaType == 3) // 숨겨진 구역 클리어(보스 및 몬스터 처치)
        {
            Instantiate(GO_Box, position, Quaternion.identity);
            return;
        }
    }
    public void BoxOpen(Vector2 position)
    {
        AppearArti(position);
        AppearETCitem(0,position);
        return;
    }
    public bool LockedBoxOpen(Vector2 position)
    {
        bool isOpen = false;
        if (pWizstone > 0)
        {
            pWizstone--;
            AppearArti(position);
            AppearETCitem(0, position);
            isOpen = true;
        }
        return isOpen;
    }

    public Sprite ApplySprite(int id)
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
    public void ApplyArtifact2Player(int id)
    {
        switch (id)
        {
            case 1:
                //sampleitem()~
                GO_Player.GetComponent<Transform>().position = new Vector3(0, 0, 0);
                pHealth -= 100;
                pMana -= 100;
                break;
        }
        //id를 받아서, 캐릭터에게 적용시킴. 아이템별로 함수를 만들어서 여기에서 해당 함수 호출하면 될듯 (수치, 기능, 외형, 세트효과개수파악, 인벤토리스크립트에 아이템 ID 전달)
    } //아티팩트 획득 시 플레이어 수치 변경, 인벤토리 이동, 외형 변경부
    public void ApplyScroll2Player(int id) // 스크롤 획득 시 위즈 사용 가능으로 변경 및 인벤토리 이동
    {
        
    }
    public void ApplyETCitem(int id)
    {
       switch (id)
        {
            case 601 :
                HpMpRecover(true, 100);// 체력포션 (대)
                break;
            case 602 :
                HpMpRecover(true, 50); // 체력포션 (소)
                break;
            case 603 :
                HpMpRecover(false, 100); // 마나포션 
                break;
            case 604 :
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
    
    public bool isColliderPlayer(Collider2D coll){
        bool isIt = false;
        Debug.Log(coll);
        if (coll.gameObject == GO_Player) isIt = true;
        Debug.Log(isIt);
        return isIt;
    }

    private void HpMpRecover(bool isHealth, int recover)
    {
        if (isHealth)
        {
            if (mHealth < recover+pHealth){pHealth = mHealth; return;}
            else{pHealth += recover;return;}
        }else
        {
            if (mMana < recover + pMana){pMana = mMana;return;}
            else{pMana += recover;return;}
        }
    }

    private bool Percent(int r)
    {
        int randNum = Random.Range(0, 100);
        if(randNum < r)
            return true;
        return false;
    } //퍼센트 계산기
    
    private void Awake()
    {

    }
    void Start()
    {
        um = gameObject.GetComponent<UIManage>();
        artifactPoolScript = GO_ArtifactPool.GetComponent<ArtifactPoolScript>();

        AppearArti(new Vector2(-5, 5));
        /*AppearETCitem(3, new Vector2(3, 0));
        AppearETCitem(3, new Vector2(3, -3));
        AppearETCitem(3, new Vector2(-3, -3));
        AppearETCitem(3, new Vector2(3, 3));
        AppearScroll(new Vector2(4, 4));
        AppearBox(0, new Vector2(-4, -4));
        AppearBox(1, new Vector2(0, -4));
        AppearBox(2, new Vector2(4, -4));
        AppearBox(3, new Vector2(-4, 4));*/
    }

    void Update()
    {
       um.FiguresSend(mHealth,pHealth,mMana,pMana,offenPoint,defenPoint,pGold,pWizstone);
    }
}

