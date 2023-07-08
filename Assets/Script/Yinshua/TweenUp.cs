using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenUp : MonoBehaviour
{
    public bool IsTweening;
    public Vector3 WalkPath;

    private Vector3 InitPosition;
    private Vector3 velocity;

    private void OnEnable()
    {
        IsTweening = true;
        InitPosition = transform.position;
        transform.position = transform.position - WalkPath;
    }


    // Update is called once per frame
    void Update()
    {
        if (IsTweening)
        {
            transform.position = Vector3.SmoothDamp(transform.position, InitPosition, ref velocity, 0.5f);
            if(Vector3.Distance(InitPosition, transform.position) < 1f)
            {
                IsTweening = false;
                transform.position = InitPosition;
                Destroy(this);
            }
        }
    }
}
