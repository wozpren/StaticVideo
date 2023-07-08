using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YinshuaGame : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject KnowPanel;
    public GameObject GamePanel;



    public static YinshuaGame Instance { get; private set; }

    public string[] QuestionBank;
    public string[] curQuestion;

    public Transform BlockPlace;
    public Transform BlockGroup;

    private string[] wordList = new string[4];
    private Stack<BlockWord> bwStack = new Stack<BlockWord>();


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Init();
        if(MainPanel)
        GoMainPanel();
    }

    public void GoMainPanel()
    {
        MainPanel.SetActive(true);
        KnowPanel.SetActive(false);
        GamePanel.SetActive(false);
    }

    public void GoKnowPanel()
    {
        KnowPanel.SetActive(true);
        GamePanel.SetActive(false);
        MainPanel.SetActive(false);
    }

    public void GoGamePanel()
    {
        SceneManager.LoadScene(1);
    }

    public void BackMain()
    {
        SceneManager.LoadScene(0);
    }



    public void Init()
    {
        curQuestion = new string[4];
        var ii = 0;
        for (int i = 0; i < 4; i++)
        {
            if(ii + (GlobaData.Instance.Level * 4) >= QuestionBank.Length)
            {
                ii = 0;
                GlobaData.Instance.Level = 0;
            }
            curQuestion[i] = QuestionBank[ii + (GlobaData.Instance.Level * 4)];
            ii++;
        }
        var bs = GameObject.FindObjectsByType<BlockWord>(FindObjectsSortMode.InstanceID);
        int widx = 0;
        int cidx = 0;
        foreach (var word in bs)
        {
            word.Init(curQuestion[widx][cidx]);
            cidx++;
            if(cidx >= 4)
            {
                cidx = 0;
                widx++;
            }
        }
    }


    public void AddPanel(BlockWord bw)
    {
        bw.transform.parent = BlockPlace;
        bw.transform.SetSiblingIndex(BlockPlace.childCount - 2);
        bw.transform.localScale = new Vector3 (-1, 1, 1);
        bwStack.Push(bw);

        if(bwStack.Count % 4 == 0 )
        {
            if (!Check())
            {
                RemoveAll();
                return;
            }
            else
            {
                bwStack.Clear();
            }
        }
        if(BlockPlace.childCount > 16)
        {
            StartCoroutine(ZhanMo());
            BlockPlace.GetChild(16).gameObject.SetActive(false);
        }
    }


    public bool Remove(BlockWord bw)
    {
        if(bwStack.Peek() == bw)
        {
            bwStack.Pop();
            bw.ResetWorld();
            return true;
        }
        return false;
    }


    public void RemoveAll()
    {
        while(bwStack.Count > 0)
        {
            var bw = bwStack.Peek();
            bw.Remove();
        }
    }


    public bool Check()
    {
        string answer = "";
        foreach(BlockWord bw in bwStack)
        {
            answer += bw.word;
        }

        answer = Reversal(answer);

        foreach (string cq in curQuestion)
        {
            if(cq == answer)
            {
                return true;
            }
        }
        return false;
    }
    public string Reversal(string input)
    {
        string result = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            result += input[i];
        }
        return result;
    }

    public GameObject MoObj;
    public GameObject TaObj;
    public GameObject NextObj;


    internal IEnumerator ZhanMo()
    {
        yield return new WaitForSeconds(0.2f);
        MoObj.SetActive(true);
        TaObj.SetActive(false);
    }

    internal IEnumerator TaYin()
    {
        yield return new WaitForSeconds(0.2f);

        MoObj.SetActive(false);
        TaObj.SetActive(true);
    }

    internal IEnumerator Next(GameObject obj)
    {
        yield return new WaitForSeconds(0.3f);

        var pa = NextObj.transform.Find("Paper");
        obj.transform.SetParent(pa, false);

        NextObj.SetActive(true);
        TaObj.SetActive(false);

    }


    public void NextLevel()
    {
        GlobaData.Instance.Level++;
        SceneManager.LoadScene(1);
    }
}
