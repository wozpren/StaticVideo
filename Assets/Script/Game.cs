using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject StartPage;
    public GameObject KnowPage;
    public GameObject PerPage;

    public GameObject SitckBar;
    public GameObject ASitckBar;

    public GameObject FrontPage;
    public GameObject GamePage;
    public GameObject GamePlay;

    public Control control;
    public Stick[] Sticks;


    public static Game Instance;


    private void Awake()
    {
        Instance = this;
        StartPage.SetActive(true);
        FrontPage.SetActive(true);

        KnowPage.SetActive(false);
        PerPage.SetActive(false);
        GamePage.SetActive(false);
        GamePlay.SetActive(false);

        control = GetComponent<Control>();
    }

    private void Start()
    {
        control.enabled = false;
    }


    public GameObject LearnBtns;
    public GameObject LearnLBS;
    public GameObject WorkLBS;
    public void SetLearn()
    {
        LearnBtns.SetActive(true);
        LearnLBS.SetActive(true);
        WorkLBS.SetActive(false);
        SitckBar.SetActive(false);
        ASitckBar.SetActive(true);
    }

    public void SetWork()
    {
        LearnBtns.SetActive(false);
        LearnLBS.SetActive(false);
        WorkLBS.SetActive(true);
        SitckBar.SetActive(true);
        ASitckBar.SetActive(false);
        tom.SetActive(false);
        foreach (var st in Sticks)
        {
            st.GReset();
        }
    }

	public void Reset()
	{
        foreach (var st in Sticks)
        {
            st.GReset();
        }
	}


	public void EnterKnow()
    {
        StartPage.SetActive(false);
        KnowPage.SetActive(true);
    }

    public void EnterPer()
    {
        StartPage.SetActive(false);
        PerPage.SetActive(true);
    }

    public void SwitchAudio()
    {
        var audio = GetComponent<AudioSource>();
        audio.mute = !audio.mute;
    }

    public void EnterGame()
    {
        PerPage.SetActive(false);
        GamePage.SetActive(true);
        GamePlay.SetActive(true);

        control.enabled = true;
    }

    public void BackKnow()
    {
        StartPage.SetActive(true);
        KnowPage.SetActive(false);
    }

    public void BackGame()
    {
        SetWork();
        StartPage.SetActive(true);
        FrontPage.SetActive(true);

        KnowPage.SetActive(false);
        PerPage.SetActive(false);
        GamePlay.SetActive(false);
        GamePage.SetActive(false);
        control.enabled = false;
    }

    public AudioSource audioSource;
    public void SwitchBGM()
    {
		audioSource.enabled = !audioSource.enabled;

	}

    public int current;
    public GameObject tom;
    internal void AddStick()
    {
        current++;
        if(current >= 6)
        {
            tom.SetActive(true);
            current = 0;
        }
    }

    internal void Next()
    {
        throw new NotImplementedException();
    }
}
