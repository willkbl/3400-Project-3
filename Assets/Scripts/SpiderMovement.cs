using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float speed = 3;
    public float distance = 5;

    public float lowerY = 0;
    public float upperY = 5;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y = Mathf.Clamp(startPos.y + Mathf.Sin(Time.time * speed) * distance, lowerY, upperY);

        transform.position = newPos;
    }
}
