using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerInput : MonoBehaviour
{

    private NavMeshAgent agent;
    private GameObject cameraPivot;
    private TriggerVolume lastClickedTrigger;
    private SpriteRenderer pointerSprite;

    public float cameraSwivelSpeed = 3;
    public GameObject pointer;

    private void Start()
    {
        pointerSprite = pointer.GetComponentInChildren<SpriteRenderer>();
        pointerSprite.enabled = false;
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
                        pointerSprite.color = Color.red;
                        pointer.transform.position = new Vector3(hit.collider.bounds.center.x, hit.collider.bounds.max.y, hit.collider.bounds.center.z);
                        lastClickedTrigger = hit.transform.GetComponent<TriggerVolume>();
                    }
                    else
                    {
                        pointerSprite.color = Color.white;
                        pointer.transform.position = hit.point;
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
        pointerSprite.enabled = (agent.velocity.magnitude != 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TriggerVolume>() == lastClickedTrigger)
        {
            agent.destination = transform.position;
            lastClickedTrigger.TriggerAction();
        }
    }

}

