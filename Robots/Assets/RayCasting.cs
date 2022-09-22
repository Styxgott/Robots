using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RayCasting : MonoBehaviour
{
    public float length = 3.0f;

    private LineRenderer lineRenderer;

    private string indicator;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Ray ray;

    Vector3 CalculateEnd()
    {
        Vector3 endPoint = transform.position + (transform.forward * length);
        RaycastHit hit;
        ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, 4f);
        if (hit.collider)
        {
            endPoint = hit.point;
        }

        return endPoint;
    }
    public Transform getPosition()
    {
        return transform;
    }
     public Vector3 getDirectionFromRay()
        {
            return ray.direction;
        }
}