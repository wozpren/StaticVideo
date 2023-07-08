using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobaData : MonoBehaviour
{
    public static GlobaData Instance;
    public int Level;


    private void Awake()
    {
        Instance= this;
        DontDestroyOnLoad(this);
    }
}
