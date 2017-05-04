using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TriggerVolume : MonoBehaviour
{

    public enum Action
    {
        StartConversation,
        LoadScene
    }
    public Action action;
    [Tooltip("The argument needed to trigger an action. Example: Scene1 as the ActionData with LoadScene selected as the Action. When triggered Scene1 will load.")]
    public List<string> actionData;

    private Animator anim;
    private int actionIndex = 0;

    private void Awake()
    {
        if (transform.root.GetComponent<Animator>() != null)
        {
            anim = transform.root.GetComponent<Animator>();
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isTalking", false);
        }
        else
        {
            Debug.LogWarning("No Animator Detected on Object: " + transform.root.name);
        }
    }

    public void TriggerAction()
    {
        if (actionData.Count == 0)
        {
            Debug.LogError("Trigger is missing Action Data.");
            return;
        }
        switch (action)
        {
            case Action.LoadScene:
                LoadScene(actionData[actionIndex]);
                break;
            case Action.StartConversation:
                StartConversation(actionData[actionIndex]);
                break;
        }
    }

    public void ResetActor()
    {
        anim.SetBool("isTalking", false);
        anim.SetBool("isIdle", true);
    }

    private void LoadScene(string sceneIndex)
    {
        UI.Instance.LoadSceneRemote(sceneIndex);
    }

    private void StartConversation(string inkTag)
    {
        //If getting an error here check the Action Data to make sure the ink tag is correct
        UI.Instance.StartConversation(inkTag);
        if (transform.root.GetComponent<Animator>() != null)
        {
            Animator anim = transform.root.GetComponent<Animator>();
            anim.SetBool("isTalking", true);
            anim.SetBool("isIdle", false);
        }
    }
}
