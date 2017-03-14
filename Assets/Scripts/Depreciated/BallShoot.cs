using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour {

    public Vector3 ballForce;
    private bool inputEnabled = true;

	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inputEnabled)
        {
            Rigidbody body = GetComponent<Rigidbody>();
            body.isKinematic = false;
            body.AddForce(ballForce);
            inputEnabled = false;
        }
    }

    void OnTriggerEnter()
    {
        Debug.Log("Ya did it");
        gameObject.SetActive(false);
    }
}
