using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RotateTween : MonoBehaviour
{
    private Vector3 Scale;
    private Vector3 velocity;
    private bool isFirst = true;

    private void Awake()
    {
        Scale = new Vector3(-1, 1, 1);
    }

    public event Action MidEvent;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, Scale, ref velocity, 0.5f);
        if(transform.localScale.x < 0 && isFirst)
        {
            MidEvent?.Invoke();
            isFirst = true;
        }
        if(transform.localScale.x < 0 && Vector3.Distance(transform.localScale, Scale) < 0.1f)
        {
            transform.localScale = Scale;

            YinshuaGame.Instance.StartCoroutine(YinshuaGame.Instance.Next(gameObject));
            Destroy(this);
        }
    }
}
