using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStick : MonoBehaviour
{
    public bool Chai;
    public float DisapperDistance;
    public GameObject Other;

    private Vector3 InitPosition;
    private Vector3 DisPosition;

    private void Awake()
    {
        InitPosition = transform.position;
        Other.SetActive(false);
    }

    private void OnEnable()
    {
        Other.SetActive(false);
    }

    private void OnDisable()
    {
        Other.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        var dis = Vector3.Distance(transform.position, InitPosition);
        if(Chai && dis > DisapperDistance)
        {
            DisPosition = transform.position;
        }
        else if(Chai && dis < DisapperDistance - 0.05f)
        {
            transform.position = DisPosition;
            gameObject.SetActive(true);
        }
    }

    public void Combo()
    {
        Chai = false;
    }

    public void Split()
    {
        Chai = true;
    }
}
