using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float moveSpeed = 1f;
    
    public float offset;
    
    public Vector3 startPosition;
    
    public float newXposition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newXposition = Mathf.Repeat(Time.time * -moveSpeed, offset);

        transform.position = startPosition + Vector3.right * newXposition;
    }
}
