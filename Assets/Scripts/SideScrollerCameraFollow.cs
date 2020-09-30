using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerCameraFollow : MonoBehaviour
{
    [SerializeField] float smoothTime = 0.3F;
    [SerializeField] Vector3 offset = new Vector3(0, 7, -50);
    [SerializeField] Vector3 velocity = Vector3.zero;
    [SerializeField] GameObject target;
    Transform targetTransform;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetTransform = target.transform;
    }

    void Update()
    {
        Vector3 targetPosition = targetTransform.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
