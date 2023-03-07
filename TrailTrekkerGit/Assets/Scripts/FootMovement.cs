using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMovement : MonoBehaviour
{
    
    
    public Transform transform1;
    public Transform transform2;
    public float lerpSpeed = 5.0f;
    public LayerMask layerMask;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 targetPosition = hit.point;
                targetPosition.z = 0;
                StartLerp(transform2, targetPosition);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 targetPosition = hit.point;
                targetPosition.z = 0;
                StartLerp(transform1, targetPosition);
            }
        }
    }

    void StartLerp(Transform transform, Vector3 targetPosition)
    {
        StartCoroutine(LerpToPosition(transform, targetPosition));
    }

    IEnumerator LerpToPosition(Transform transform, Vector3 targetPosition)
    {
        float t = 0.0f;
        Vector3 startPosition = transform.position;
        startPosition.z = 0;
        targetPosition.z = 0;

        while (t < 1.0f)
        {
            t += Time.deltaTime * lerpSpeed;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        transform.position = targetPosition;
    }
}




