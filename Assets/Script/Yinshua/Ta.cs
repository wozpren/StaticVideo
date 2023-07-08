using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ta : MonoBehaviour, IDragHandler
{
    public int brunshCount;
    public Transform Panel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Block"))
        {
            if(collision.GetComponent<BlockWord>().MoveToPaper(Panel))
            {
                brunshCount++;
                if (brunshCount >= 16)
                {
                    Panel.AddComponent<RotateTween>().MidEvent += Ta_MidEvent; ;
                }
            }

        }
    }

    private void Ta_MidEvent()
    {
        var bws = GameObject.FindObjectsOfType<BlockWord>();
        foreach (var block in bws)
        {
            block.ResetColor();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
