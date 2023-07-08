using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class other : MonoBehaviour, IPointerClickHandler
{
	public GameObject GameObject;


	public void Get(GameObject o)
	{
		GameObject = o;
		gameObject.SetActive(false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		GameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
