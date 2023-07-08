using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : MonoBehaviour
{
    public Animator animator;
    public AStick[] ASticks;
    public GameObject SUI;

    public void Do()
    {
        foreach (var item in ASticks)
        {
            item.Combo();
        }
        for (var i = 0; i < SUI.transform.childCount; i++)
        {
            SUI.transform.GetChild(i).gameObject.SetActive(true);

        }

        animator.SetFloat("Speed", -1);
        animator.Play("Lbs", 0, 0.99f);
    }

    public void Undo()
    {
        foreach (var item in ASticks)
        {
            item.Split();
        } 
        animator.SetTrigger("Work");
        animator.SetFloat("Speed", 1);

    }
}
