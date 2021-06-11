using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastPattern : MonoBehaviour
{
    [SerializeField] private LinePool linePool;
    [SerializeField] private Canvas canvas;
    [SerializeField] private CastDirector castDirector;
    private Dictionary<int, CircleId> circles = new Dictionary<int, CircleId>();

    private List<CircleId> pooledLines = new List<CircleId>();
    private int[] drawLines = new int[6]; //선이 무슨 점에서 시작했느냐
    private bool isDrawing;
    private bool stopDrawing;
    private GameObject lineOnEdit;
    private RectTransform lineOnEditRcTs;
    private CircleId circleOnEdit;
    private Vector3 mousePos;

    //private Touch touch;

    void Start()
    {
        //CastArea의 Circle 들을 딕셔너리에 저장하는 과정
        for (int i = 1; i <= 5; i++)
        {
            circles.Add(i, transform.GetChild(i).GetComponent<CircleId>());
            circles[i].id = i;
        }
        Init();
    }

    private void Update()
    {
        if (isDrawing)
        {
            /*
            Debug.Log(touch.position);
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x,
                Vector3.Distance(touch.position, circleOnEdit.transform.localPosition));
            */

            mousePos = canvas.transform.InverseTransformPoint(Input.mousePosition);

            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x,
                Vector3.Distance(mousePos - transform.localPosition, circleOnEdit.transform.localPosition));

            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                mousePos - transform.localPosition - circleOnEdit.transform.localPosition).normalized;
        }
    }

    private void Init()
    {
        isDrawing = false;
        stopDrawing = false;
        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;
        mousePos = Vector3.zero;

        for(int i =0; i<6; i++)
        {
            drawLines[i] = 0;
        }

        for(int i =0; i<pooledLines.Count; i++)
        {
            linePool.ReturnObject(pooledLines[i].gameObject);
        }

        pooledLines.Clear();
    }

    public void OnMouseDownCircle(CircleId circleID)
    {
        //Debug.Log("Down : " + circleID.id);

        //touch = Input.GetTouch(Input.touchCount - 1); 터치로 바꿀 때
        //Debug.Log("Touch Pos : " + touch.position);

        isDrawing = true;
        SetLine(circleID);
    }

    public void OnMouseEnterCircle(CircleId circleID)
    {
        //Debug.Log("Enter : " + circleID.id);

        if (isDrawing == true && stopDrawing == false && drawLines != null)
        {
            for (int i = 0; i < drawLines.Length; i++)
            {
                if (drawLines[i] == circleID.id)
                {
                    if (drawLines[0] == circleID.id && drawLines[2] != 0)
                    {
                        stopDrawing = true;
                        continue;
                    }
                    return;
                }
            }
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x,
                Vector3.Distance(lineOnEdit.transform.localPosition, circleID.transform.localPosition));

            lineOnEditRcTs.rotation = Quaternion.FromToRotation(Vector3.up,
                circleID.transform.localPosition - lineOnEdit.transform.localPosition).normalized;

            SetLine(circleID);
        }
    }

    public void OnMouseUpCircle(CircleId circleID)
    {
        //Debug.Log("Up : " + circleID.id);
        castDirector.ActiveWiz(drawLines);
        Init();
    }


    void SetLine(CircleId circle)
    {
        var pooledLine = linePool.GetLine(circle.transform.localPosition, circle.id);

        lineOnEdit = pooledLine.gameObject;
        //Debug.Log("lineOnEdit : " + pooledLine.gameObject.name);
        lineOnEditRcTs = lineOnEdit.GetComponent<RectTransform>();
        //Debug.Log("lineOnEditRcTs Checked");
        circleOnEdit = circle;

        pooledLines.Add(pooledLine);
        drawLines[pooledLines.Count - 1] = circle.id;
    }
}