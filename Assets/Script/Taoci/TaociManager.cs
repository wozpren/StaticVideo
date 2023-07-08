using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TaociManager : MonoBehaviour
{
    public static TaociManager Intance;

    public VideoHelp VideoPlayer;
    public GameObject StartPanel;
    public GameObject KnowPanel;
    public GameObject GamePanel;

    public GameObject TaociPanel;
    public GameObject TexturePanel;

    public GameObject PPBox;


    public GameObject TaociModel;
    public GameObject SelectLight;

    private GameObject TaociObj;



    private void Awake()
    {
        Intance = this;



    }

    private void Start()
    {
        Main();
    }


    public void Main()
    {
        StartPanel.SetActive(true);
        KnowPanel.SetActive(false);
        GamePanel.SetActive(false);

    }

    public void Restart()
    {
        var cur = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(cur);
    }

    public void Konw()
    {
        StartPanel.SetActive(false);
        KnowPanel.SetActive(true);
        GamePanel.SetActive(false);
    }

    public void Game()
    {
        StartPanel.SetActive(false);
        KnowPanel.SetActive(false);
        GamePanel.SetActive(true);

        VideoPlayer.PlayVideo("1", GameCallback);
    }

    public void GameCallback()
    {
        Taoci();
        TaociModel.SetActive(true);
    }


    public void Taoci()
    {
        TaociPanel.SetActive(true);
        TexturePanel.SetActive(false);
    }

    public void Texture()
    {
        TaociPanel.SetActive(false);
        TexturePanel.SetActive(true);
        var pos = GameObject.Find("Center").transform;
        TaociObj.transform.SetParent(pos, false);
        TaociObj.transform.localPosition = Vector3.zero;

        PPBox.SetActive(false);
    }

    public void Fire()
    {
        VideoPlayer.PlayVideo("2", () =>
        {
            TaociModel.SetActive(false);
            var pos = PPBox.transform.Find("Center");
            Destroy(TaociObj.transform.GetChild(0).gameObject);
            TaociObj.GetComponent<Taoci>().Close();

            TaociObj.transform.SetParent(pos, false);
            TaociObj.transform.localPosition = Vector3.zero;


            PPBox.SetActive(true);
        });
    }

    public void SetColor(string color)
    {
        var cs = color.Split(',');
        var r = float.Parse(cs[0]);
        var g = float.Parse(cs[1]);
        var b = float.Parse(cs[2]);
        var mcolor = new Color(r, g, b);
        TaociObj.GetComponent<Taoci>().SetColor(mcolor);
    }


    public void SelectTaoci(GameObject gameObject)
    {
        TaociObj = gameObject;
        SelectLight.SetActive(true);
        SelectLight.transform.SetParent(gameObject.transform, false);
    }

    public void SetTexture(Texture2D texture)
    {
        TaociObj.GetComponent<Taoci>().SetDetailTexture(texture);
    }

    public void End()
    {
        VideoPlayer.PlayVideo("3", () =>
        {
            TexturePanel.SetActive(false);
            TaociObj.AddComponent<Around>();
        });

    }
}
