using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public LayerMask RayLayer;
    private Stick stick;

    private Vector3 planeOffset;
    private Vector3 planeNormal;
    public float forceMuilt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit, 100, RayLayer))
            {
                stick = hit.collider.GetComponent<Stick>();
                if (stick != null)
                {
                    planeOffset = hit.point - stick.transform.position;

                    switch (stick.SPlane)
                    {
                        case Stick.Plane.x:
                            planeNormal = new Vector3(1, 0, 0);
                            break;
                        case Stick.Plane.y:
                            planeNormal = new Vector3(0, 1, 0);
                            break;
                        case Stick.Plane.z:
                            planeNormal = new Vector3(0, 0, 1);
                            break;
                    }
                    stick.OnClick();
                }
                else
                {
                    hit.collider.GetComponent<other>().OnPointerClick(null);

				}
            }

        }
        if(Input.GetMouseButton(0) && stick)
        {
            var mouse = Input.mousePosition;
            var mouseRay = Camera.main.ScreenPointToRay(mouse);
            IntersectWithLineAndPlane(mouseRay.origin, mouseRay.direction, planeNormal, stick.transform.position + planeOffset, out var intersection);

            var force = (intersection - (stick.transform.position + planeOffset));
            stick.AddForce(force * forceMuilt * 2);
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            if (stick)
            {
                stick.OnUnclick();
                stick = null;
            }
        }
    }

    public static bool IntersectWithLineAndPlane(Vector3 point, Vector3 direct, Vector3 planeNormal, Vector3 planePoint, out Vector3 intersection)
    {
        intersection = Vector3.zero;
        var denominator = Vector3.Dot(direct.normalized, planeNormal);
        if (denominator == 0)
        {
            return false;
        }
        float d = Vector3.Dot(planePoint - point, planeNormal) / denominator;
        intersection = d * direct.normalized + point;
        return true;
    }
}
