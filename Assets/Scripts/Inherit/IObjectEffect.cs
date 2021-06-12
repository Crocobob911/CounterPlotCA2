using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectEffect
{
    void GetDamage(float damage); //데미지 받음

    void GetHeal(float heal); //힐 받음

    IEnumerator GetStun(float time); //기절

    IEnumerator GetSlow(float rate, float time); //슬로우

    void GetBurn(float time); //불 탐

    void GetPoison(float time); //중독

    void GetBound(float time); //속박

    void GetAirborne(float time); //공중에 뜸

    void GetSleep(float time); //수면

    void GetBlind(float time); //실명

    void GetScared(float time); //공포

    void GetCharmed(float time); //매혹

    void GetProvoked(float time); //도발됨
}
