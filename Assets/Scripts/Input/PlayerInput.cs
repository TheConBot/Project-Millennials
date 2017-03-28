using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerInput : MonoBehaviour {

    private NavMeshAgent agent;
    private GameObject cameraPivot;
    private TriggerVolume lastClickedTrigger;

    public float cameraSwivelSpeed = 3;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cameraPivot = Camera.main.transform.root.gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Conversation Input
            if (UI.Instance.inConversation)
            {
                if (UI.Instance.choicesAvailable)
                {
                    UI.Instance.GenerateChoices();
                }
                else
                {
                    UI.Instance.UpdateText();
                }
            }
            //Player Movement Input
            else
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
                {
                    agent.destination = hit.point;
                    if (hit.transform.GetComponent<TriggerVolume>() != null)
                    {
                        lastClickedTrigger = hit.transform.GetComponent<TriggerVolume>();
                    }
                }
                else
                {
                    Debug.LogWarning("Could not walk to selected destinaion.");
                }
            }
        }
        else if (Input.GetMouseButton(1))
        {
            Debug.Log(Input.GetAxis("Mouse X"));
            float yAxis = cameraPivot.transform.eulerAngles.y * cameraSwivelSpeed; 
            yAxis += -Input.GetAxis("Mouse X");
            cameraPivot.transform.rotation = Quaternion.Euler(cameraPivot.transform.eulerAngles.x, yAxis, cameraPivot.transform.eulerAngles.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TriggerVolume>() == lastClickedTrigger)
        {
            lastClickedTrigger.TriggerAction();
        }
    }
}
