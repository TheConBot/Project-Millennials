using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PointAndClickMovement : MonoBehaviour {

    private NavMeshAgent agent;
    public GameObject cameraPivot;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UI.Instance.inConversation)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
            {
                agent.destination = hit.point;
            }
            else
            {
                Debug.LogError("Could not walk to selected destinaion.");
            }
        }

        if (Input.GetMouseButton(1))
        {
            Debug.Log(Input.GetAxis("Mouse X"));
            float yAxis = cameraPivot.transform.eulerAngles.y; 
            yAxis += -Input.GetAxis("Mouse X");
            cameraPivot.transform.rotation = Quaternion.Euler(cameraPivot.transform.eulerAngles.x, yAxis, cameraPivot.transform.eulerAngles.z);
        }
    }
}
