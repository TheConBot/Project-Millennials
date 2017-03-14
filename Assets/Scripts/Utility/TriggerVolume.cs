using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerVolume : MonoBehaviour {

	public enum Action
    {
        LoadScene,
        StartConversation
    }

    public Action action;
    [Tooltip("The argument needed to trigger an action. Example: Scene1 with LoadScene selected as the Action. When triggered Scene1 will load.")]
    public string actionData;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch (action)
            {
                case Action.LoadScene:
                    LoadScene(actionData);
                    break;
                case Action.StartConversation:
                    StartConversation(actionData);
                    break;
            }
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
        UI.Instance.StartConversation(inkTag);
    }
}
