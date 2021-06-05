using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastPattern : MonoBehaviour
{
    private List<CircleId> circles;
    private List<CircleId> drawLines; //선이 무슨 점에서 시작했느냐

    [SerializeField] private GameObject drawLinePrafab;
    //[SerializeField] private Canvas can; //drawLinePrafab이 자식으로 들어갈 오브젝트.
    private bool isDrawing;

    void Start()
    {
        circles = new List<CircleId>();
        for(int i=0; i<5; i++)
        {
            circles.Add(transform.GetChild(i + 1).GetComponent<CircleId>());
            circles[i].id = i;
        }

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {

    }

    private void StopDraw()
    {
        isDrawing = false;
        //나중에 drawLinePrefab을 풀링하면서, 여기서 오브젝트들을 모두 꺼주자.
    }

    public void OnMouseDownCircle(CircleId circleID)
    {
        Debug.Log(circleID.id);
        isDrawing = true;
        CreateLine(circleID.transform.localPosition, circleID.id);
    }

    public void OnMouseEnterCircle(CircleId circleID)
    {
        Debug.Log(circleID.id);
    }
    public void OnMouseExitCircle(CircleId circleID)
    {
        Debug.Log(circleID.id);
    }
    public void OnMouseUpCircle(CircleId circleID)
    {
        Debug.Log(circleID.id);
        StopDraw();
    }

    void CreateLine(Vector3 pos, int id)
    {
        var line = GameObject.Instantiate(drawLinePrafab, transform);
        line.transform.localPosition = pos;
        //drawLinePrefab 풀링을 구현하자. 하면서 거기 CircleID를 컴포넌트로 넣어두자.

    }
}
