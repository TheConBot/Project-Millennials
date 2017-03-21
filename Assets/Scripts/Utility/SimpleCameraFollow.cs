using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SimpleCameraFollow : MonoBehaviour {

    public Transform target;
    

	private void Update () {
        transform.position = target.position;
	}
}
