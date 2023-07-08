using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public Transform Target;


    // Start is called before the first frame update
    void Awake()
    {
        //Target = GameObject.Find("GamePlay/LBS").GetComponent<Transform>();
    }


    private void Update()
    {
        transform.LookAt(Target);

        //mouse move
        if (Input.GetMouseButton(1))
        {
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            //clamp angle
            if (transform.eulerAngles.x - v * 100 > 80 && transform.eulerAngles.x - v * 100 < 280)
            {
                v = 0;
            }

            transform.RotateAround(Target.position, Vector3.up, h * 5);
            transform.RotateAround(Target.position, transform.right, -v * 5);
        }
    }

}
