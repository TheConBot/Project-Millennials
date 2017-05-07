using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour {

    public float speed = 5;
    public float zThreshhold = -25;
    public bool resetOnThreshold;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, zThreshhold), Time.deltaTime * speed);
        if(transform.position.z <= zThreshhold)
        {
            if (!resetOnThreshold)
            {
                gameObject.SetActive(false);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
        }
    }
}
