using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastPattern : MonoBehaviour
{
    #region Singleton
    public static CastPattern instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform canvasRcTs;
    [SerializeField] private CastDirector castDirector;
    [SerializeField] private Image castBack;
    [SerializeField] private LinePool linePool;
    private List<CircleId> circles = new List<CircleId>();

    private List<CircleId> pooledLines = new List<CircleId>();
    private int[] drawLines = new int[6]; //선이 무슨 점에서 시작했느냐
    private bool isDrawing;
    private bool isStopDrawing;
    [SerializeField] private bool isDrawCanceling;
    private bool isCastBackRed;
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
            circles.Add(transform.GetChild(i).GetComponent<CircleId>());
            circles[i-1].id = i;
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

            //드로우중에 선이 마우스를 따라감
            mousePos = canvas.transform.InverseTransformPoint(Input.mousePosition);

            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x,
                Vector3.Distance(mousePos - transform.localPosition, circleOnEdit.transform.localPosition));

            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                mousePos - transform.localPosition - circleOnEdit.transform.localPosition).normalized;

            //드로우 취소 판정
            if (lineOnEditRcTs.sizeDelta.y > canvasRcTs.sizeDelta.x * 0.2f)
            {
                if(isCastBackRed == false)
                {
                    isDrawCanceling = true;
                    isCastBackRed = true;
                    castBack.color = new Color(1, 0, 0);
                }
            }
            else //드로우취소 취소판정
            {
                if (isCastBackRed == true)
                {
                    isDrawCanceling = false;
                    isCastBackRed = false;
                    castBack.color = new Color(1, 1, 1);
                }
            }
        }
    }

    private void Init()
    {
        isDrawing = false;
        isStopDrawing = false;
        isDrawCanceling = false;
        isCastBackRed = false;
        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;
        mousePos = Vector3.zero;
        castBack.color = new Color(1, 1, 1);

        for(int i =0; i<6; i++)
        {
            drawLines[i] = 0;
            if(i!=5)
                circles[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
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

        Debug.Log("MouseDown");
        isDrawing = true;
        SetLine(circleID);
    }

    public void OnMouseEnterCircle(CircleId circleID)
    {
        //Debug.Log("Enter : " + circleID.id);

        if (isDrawing == true && isStopDrawing == false && drawLines != null)
        {
            for (int i = 0; i < drawLines.Length; i++)
            {
                if (drawLines[i] == circleID.id)
                {
                    if (drawLines[0] == circleID.id && drawLines[2] != 0)
                    {
                        isStopDrawing = true;
                        continue;
                    }
                    return;
                }
            }

            //마우스를 따라가던 선을 점에 연결함
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x,
                Vector3.Distance(lineOnEdit.transform.localPosition, circleID.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(Vector3.up,
                circleID.transform.localPosition - lineOnEdit.transform.localPosition).normalized;

            //새로운 선 만들어냄
            SetLine(circleID);
        }
    }

    public void OnMouseUpCircle(CircleId circleID)
    {
        //Debug.Log("Up : " + circleID.id);

        if (!isDrawCanceling) //드로잉 취소가 아닐 때
        {
            castDirector.PatternComplete(drawLines);
        }
        else //드로잉 취소일 때
        {
            Debug.Log("Draw Canceled");
        }

        Init();
    }


    void SetLine(CircleId circle)
    {
        circle.gameObject.transform.GetChild(0).gameObject.SetActive(true);

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