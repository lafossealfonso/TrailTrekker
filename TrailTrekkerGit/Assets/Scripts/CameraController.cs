using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform transform1;
    public Transform transform2;
    public float followSpeed = 5.0f;

    private Transform targetTransform;

    void Update()
    {
        targetTransform = transform1.position.y > transform2.position.y ? transform1 : transform2;
    }

    void LateUpdate()
    {
        float targetY = targetTransform.position.y;
        float currentY = transform.position.y;
        float newY = Mathf.Lerp(currentY, targetY, followSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}