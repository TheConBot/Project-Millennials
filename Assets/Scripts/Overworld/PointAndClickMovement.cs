using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PointAndClickMovement : MonoBehaviour {

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
            {
                agent.destination = hit.point;
            }
        }

        if (Input.GetMouseButton(1))
        {
            Debug.Log(Input.GetAxis("Mouse X"));
            float yAxis = Camera.main.transform.eulerAngles.y; 
            yAxis += -Input.GetAxis("Mouse X");
            Camera.main.transform.rotation = Quaternion.Euler(Camera.main.transform.eulerAngles.x, yAxis, Camera.main.transform.eulerAngles.z);
        }
    }
}
