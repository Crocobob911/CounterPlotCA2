using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastPattern : MonoBehaviour
{
    [SerializeField] private LinePool linePool;

    private Dictionary<int, CircleId> circles = new Dictionary<int, CircleId>();
    private List<CircleId> pooledLines = new List<CircleId>();
    [SerializeField] private List<int> drawLines = new List<int>(); //선이 무슨 점에서 시작했느냐

    [SerializeField] private Canvas canvas;
    private bool isDrawing;
    private GameObject lineOnEdit;
    private RectTransform lineOnEditRcTs;
    private CircleId circleOnEdit;

    private Vector3 mousePos = new Vector3();

    void Start()
    {
        //CastArea의 Circle 들을 딕셔너리에 저장하는 과정
        for(int i=0; i<5; i++)
        {
            circles.Add(i, transform.GetChild(i + 1).GetComponent<CircleId>());
            circles[i].id = i;
        }
        Init();
    }

    private void Update()
    {
        if (isDrawing)
        {
            mousePos = canvas.transform.InverseTransformPoint(Input.mousePosition);

            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x,
                Vector3.Distance(mousePos, circleOnEdit.transform.position));
        }
    }

    private void Init()
    {
        isDrawing = false;
        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;
    }

    private void StopDraw() //드로잉이 끝났을 때 변수들 초기화
    { //이거 나중에 보고 그냥 MouseUp에 적어두거나 하자, 굳이 함수로 구별말고
        Init();
        foreach (var line in pooledLines)
        {
            linePool.ReturnObject(line.gameObject);
        }
        pooledLines.Clear();
    }

    public void OnMouseDownCircle(CircleId circleID)
    {
        //Debug.Log("Down : " + circleID.id);
        isDrawing = true;
        SetLine(circleID);
    }

    public void OnMouseEnterCircle(CircleId circleID)
    {
        //Debug.Log("Enter : " + circleID.id);
        if(isDrawing == true)
        {
            SetLine(circleID);
        }
    }

    public void OnMouseUpCircle(CircleId circleID)
    {
        //Debug.Log("Up : " + circleID.id);
        StopDraw();
    }

    void SetLine(CircleId circle)
    {
        if (drawLines != null)
        {
            foreach (var line in drawLines)
            {
                if (line == circle.id)
                        return;
            }
        }

        var pooledLine = linePool.GetLine(circle.transform.localPosition, circle.id);

        lineOnEdit = pooledLine.gameObject;
        lineOnEditRcTs = pooledLine.gameObject.GetComponent<RectTransform>();
        circleOnEdit = circle;

        pooledLines.Add(pooledLine);
        drawLines.Add(circle.id);
    }
}