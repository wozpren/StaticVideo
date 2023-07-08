using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetTexture : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var img = GetComponent<Image>();
        TaociManager.Intance.SetTexture(img.sprite.texture);
    }
}
