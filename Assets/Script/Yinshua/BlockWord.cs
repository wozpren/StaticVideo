using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockWord : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 InitPosition;
    private Transform InitParent;
    private bool inPlane;
    public string word;

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        var color = text.color;
        color.a = 0.6f;
        text.color = color;

        InitPosition = transform.localPosition;
        InitParent = transform.parent;
    }

    public void Init(char word)
    {
        this.word = word.ToString();
        GetComponentInChildren<Text>().text = this.word;

    }


    public void ResetWorld()
    {
        inPlane = false;
        transform.parent = InitParent;
        transform.localScale = Vector3.one;
        transform.localPosition = InitPosition;

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (inPlane)
        {
            Remove();
        }
        else
        {
            inPlane = true;
            YinshuaGame.Instance.AddPanel(this);

        }
    }

    public void Remove()
    {
        if (YinshuaGame.Instance.Remove(this))
        {
            inPlane = false;
        }
    }

    private bool isBrunsh;

    public bool Brunsh()
    {
        if (!isBrunsh)
        {
            var color = text.color;
            color.a = 1f;
            text.color = color;
            isBrunsh = true;
            return true;
        }
        return false;

    }
    private bool isMoveToPaper;

    public bool MoveToPaper(Transform t)
    {
        if (!isMoveToPaper)
        {
            text.transform.parent = t;
            var color = text.color;
            color.a = 0.5f;
            text.color = color;
            isMoveToPaper = true;
            return true;
        }
        return false;
    }

    public void ResetColor()
    {
        var color = text.color;
        color.a = 1f;
        text.color = color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
