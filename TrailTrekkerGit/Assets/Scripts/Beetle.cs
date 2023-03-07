using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    public float speed = 5.0f;
    public float radius = 1.0f;
    public float angle = 0.0f;
    public float randomness = 0.5f;

    private Vector2 center;

    void Start()
    {
        center = transform.position;
    }

    void Update()
    {
        angle += speed * Time.deltaTime;
        float randomRadius = radius + Random.Range(-radius * randomness, radius * randomness);
        float x = center.x + randomRadius * Mathf.Cos(angle);
        float y = center.y + randomRadius * Mathf.Sin(angle);
        transform.position = new Vector2(x, y);
        FaceDirection();
    }

    void FaceDirection()
    {
        float angleRad = angle * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
