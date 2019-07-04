using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    public float speed;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        float newposition = Mathf.Repeat(Time.time * speed, transform.localScale.y);
        transform.position = startPosition + Vector3.back * newposition;
    }
}
