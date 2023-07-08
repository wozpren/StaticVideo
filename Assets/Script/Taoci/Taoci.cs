using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Taoci : MonoBehaviour, IPointerClickHandler
{
    private Material material;

    private bool isSelect = false;

    public void Awake()
    {
        //get material
    }



    public void SetDetailTexture(Texture2D text)
    {
        GetComponent<MeshRenderer>().material.SetTexture("_DetailAlbedoMap", text);
        
    }
    internal void SetColor(Color color)
    {
        var mar = GetComponent<MeshRenderer>().material;
        mar.SetColor("_Color", color);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isSelect)
            TaociManager.Intance.SelectTaoci(gameObject);
    }

    internal void Close()
    {
        var mar = GetComponent<MeshRenderer>().material;
        mar.SetFloat("_Glossiness", 0.609f);
        mar.SetColor("_Color", new Color(0.806f, 0.806f, 0.806f));

        isSelect = true;
    }


}
