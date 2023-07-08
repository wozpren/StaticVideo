using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritePlayer : MonoBehaviour
{
    public Sprite[] sprites;
    public Image Image;

    public int Speed;
    private float playTime;
    private float switchTime;
    public int index;

    private void Awake()
    {
        Image = GetComponent<Image>();
        switchTime = (float)1 / Speed;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
        if (playTime > switchTime)
        {
            playTime = 0;
            Image.sprite = sprites[index];
            index = index + 1;
            if(index >= sprites.Length)
            {
                index = 0;
            }
        }

    }
}
