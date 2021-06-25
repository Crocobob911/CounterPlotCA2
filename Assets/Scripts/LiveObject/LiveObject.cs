using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LiveObject : MonoBehaviour
{
    protected float hp;
    public float HP { get { return hp; } set { if (value < 0) hp = 0; else if (value > maxHp) hp = maxHp; else hp = value; } }
    
    protected float maxHp;
    public float MaxHP { get { return maxHp; } set { if (value < 0) maxHp = 0; else maxHp = value; } }
    
    protected float mp;
    public float MP { get { return mp; } set { if (value < 0) mp = 0; else if (value > maxMp) mp = maxMp; else mp = value; } }
    
    protected float maxMp;
    public float MaxMP { get { return maxMp; } set { if (value < 0) maxMp = 0; else maxMp = value; } }
    
    protected float attackDamage;
    public float AttackDamage { get { return attackDamage; } set { if (value < 0) attackDamage = 0; else attackDamage = value; } }
    
    protected float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { if (value < 0) moveSpeed = 0; else moveSpeed = value; } }
    
    public void Move(Vector3 rot)
    {
        transform.Translate(rot * MoveSpeed * Time.deltaTime);
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
        Debug.Log(gameObject.name + " get Damaged : " + damage + " -> " + HP);
    }

    public void GetHeal(float heal)
    {
        HP += heal;
        Debug.Log(gameObject.name + " get Healed : " + heal + " -> " + HP);
    }

    public IEnumerator GetStun(float time)
    {
        Debug.Log(gameObject.name + " get Stuned : " + time + " second");
        float temp = MoveSpeed;
        MoveSpeed = 0;

        yield return new WaitForSeconds(time);
        Debug.Log("UnStuned");
        MoveSpeed = temp;

        yield return null;
        //이거 스턴된 동안 이동속도가 바뀌는거 어떻게 해야겠는데
    }

    public IEnumerator GetSlow(float rate, float time)
    {
        Debug.Log(gameObject.name + " get Slowed : " + rate + "%, " + time + " second");
        float moveSpeed = (100 - rate) / 100;
        MoveSpeed *= moveSpeed;

        yield return new WaitForSeconds(time);
        Debug.Log("UnSlow");
        MoveSpeed /= moveSpeed;

        yield return null;
    }

    public void GetBurn(float time)
    {

    }

    public void GetPoison(float time)
    {

    }

    public void GetBound(float time)
    {

    }

    public void GetAirborne(float time)
    {

    }

    public void GetSleep(float time)
    {

    }

    public void GetBlind(float time)
    {

    }

    public void GetScared(float time)
    {

    }

    public void GetCharmed(float time)
    {

    }

    public void GetProvoked(float time)
    {

    }
}
