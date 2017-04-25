using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TriggerVolume : MonoBehaviour {

	public enum Action
    {
        StartConversation,
        LoadScene
    }
    public Action action;
    [Tooltip("The argument needed to trigger an action. Example: Scene1 as the ActionData with LoadScene selected as the Action. When triggered Scene1 will load.")]
    public List<string> actionData;

    private int actionIndex = 0;

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

    private void LoadScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (!scene.IsValid())
        {
            Debug.LogError("Could not find scene. Check for spelling and make sure the scene is in the build settings.");
            return;
        }
        SceneManager.LoadScene(sceneName);
    }

    private void StartConversation(string inkTag)
    {
        //If getting an error here check the Action Data to make sure the ink tag is correct
        UI.Instance.StartConversation(inkTag);
    }
 }
