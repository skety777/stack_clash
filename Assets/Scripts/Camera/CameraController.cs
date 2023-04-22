using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ball;
    public Vector3 offset;
    public float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
       // offset = transform.position - ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, ball.transform.position.y, transform.position.z);
        if (ball.transform.position.y > 7) {
            transform.position = newPos;
        }
    }
}
