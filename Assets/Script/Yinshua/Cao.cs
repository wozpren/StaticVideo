using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cao : MonoBehaviour, IDragHandler
{
    public int brunshCount;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.CompareTag("Block"))
        {
            if (collision.GetComponent<BlockWord>().Brunsh())
            {
                brunshCount++;
                if (brunshCount >= 16)
                {
                    StartCoroutine(YinshuaGame.Instance.TaYin());
                }
            }
        }
    }
}
