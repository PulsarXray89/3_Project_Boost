using UnityEngine;

public class SideScrollerCameraFollow : MonoBehaviour
{
    [SerializeField] float smoothSpeed = 10f;
    [SerializeField] Vector3 offset = new Vector3(0, 7, -50);
    [SerializeField] Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
