using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Stick : MonoBehaviour
{
	public GameObject Placer;


	private Material material;
    private new Rigidbody rigidbody;
    private Vector3 initialPosition;

	public bool isMerge;
    public bool isDrag;

	public enum Plane
    {
        x,y,z
    }

    public Plane SPlane;




    // Start is called before the first frame update
    void Awake()
    {
        Placer.GetComponent<Button>().onClick.AddListener(Show);
        Placer.gameObject.SetActive(false);
        initialPosition = transform.position;
		material = GetComponent<Renderer>().material;
        rigidbody = GetComponent<Rigidbody>();
        switch (SPlane)
        {
            case Plane.x:
                rigidbody.constraints |= RigidbodyConstraints.FreezePositionX;
                break;
            case Plane.y:
                rigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
                break;
            case Plane.z:
                rigidbody.constraints |= RigidbodyConstraints.FreezePositionZ;
                break;
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
        Placer.gameObject.SetActive(false);
    }

    public void Update()
	{
		if(!isDrag)
        {
			var dis = Vector3.Distance(transform.position, initialPosition);
			if (isMerge)
            {
				if (dis < 0.01f)
				{
					transform.position = initialPosition;
                    return;
				}
				if (dis < 0.5f)
				{
                    transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * 2);
				}
                if(dis < 1.5f)
                {
                    isMerge = false;
                }
            }
            else
            {
                if(dis > 1.5)
                {
                    Game.Instance.AddStick();
					Placer.gameObject.SetActive(true);
                    gameObject.SetActive(false);
					isMerge = true;
				}
            }
        }
	}


	public void AddForce(Vector3 force)
    {
        rigidbody.AddForce(force, ForceMode.Force);
    }

    public void OnClick()
    {
        material.color = Color.yellow;
        rigidbody.isKinematic = false;
		isDrag = true;

	}

    public void OnUnclick()
    {
        material.color = Color.white;
        rigidbody.isKinematic = true;
		isDrag = false;

	}

	internal void GReset()
	{
        transform.position = initialPosition;
        Placer.gameObject.SetActive(false);
        gameObject.SetActive(true);
        isMerge = false;
	}
}
