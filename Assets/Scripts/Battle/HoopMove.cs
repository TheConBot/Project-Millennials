using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMove : MonoBehaviour {

    private int goal = 10;

	private void Start()
    {
        StartCoroutine(MoveHoop());
    }

    private IEnumerator MoveHoop()
    {
        while(transform.position.x != goal)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(goal, transform.position.y, transform.position.z), 0.1f);
            yield return new WaitForEndOfFrame();
        }
        goal = -goal;
        StartCoroutine(MoveHoop());
        yield return null;
    }
}
