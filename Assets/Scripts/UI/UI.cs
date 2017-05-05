using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ink.Runtime;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }

    public enum FadeType
    {
        Out,
        In
    }

    [SerializeField, Header("INK File")]
    private TextAsset inkJSONAsset;
    private Story story;
    [SerializeField, Header("UI Elements")]
    private Text bodyText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameObject conversationPanel, fadeToBlack;
    [SerializeField]
    private GameObject choicesPanel;
    [SerializeField]
    private Button[] choicesButtons;
    [SerializeField]
    private Image characterImage, decorationSquare, continueImage;
    [SerializeField]
    private Sprite[] expressionSprites;
    [Header("UI Variables"), SerializeField]
    private float fadeSpeed = 1;
    [SerializeField]
    private float normalCharacterWriteDelay = 0.2f;
    [SerializeField]
    private float quickCharacterWriteMultiplier = 0.1f;
    private float characterWriteDelay;
    [SerializeField]
    private Color halleColor, kayColor, vanyaColor;
    private CanvasGroup conversationCanvasGroup;
    private CanvasGroup fadeToBlackCanvasGroup;

    public bool inConversation
    {
        get
        {
            return conversationPanel.activeSelf;
        }
    }

    public bool choicesAvailable
    {
        get
        {
            return story.currentChoices.Count > 0 && !choicesPanel.activeSelf;
        }
    }
    private bool isWritingText;
    private readonly char[] delimiterChars = { ':' };

    private void Awake()
    {
        //Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Everything else
        InitializeInk();
        InitializeUI();
    }

    public void UpdateText()
    {
        if (isWritingText)
        {
            if(characterWriteDelay == normalCharacterWriteDelay)
            {
                characterWriteDelay *= quickCharacterWriteMultiplier;
            }
            return;
        }
        else if (!story.canContinue && story.currentChoices.Count == 0)
        {
            EndConversation();
            return;
        }
        else if (!story.canContinue)
        {
            return;
        }
        string nextLine = story.Continue().Trim();
        string[] splitLine = nextLine.Split(delimiterChars);

        if (story.currentTags.Count > 0)
        {
            if (story.currentTags[0].StartsWith("scene:"))
            {
                string sceneIndex = story.currentTags[0].Substring(story.currentTags[0].IndexOf(delimiterChars[0]) + 1).Trim();
                int index;
                if (!int.TryParse(sceneIndex, out index))
                {
                    Debug.LogError("Could not convert Ink Tag string to int. Defaulting to next scene in build index...");
                    index = SceneManager.GetActiveScene().buildIndex + 1;
                }
                StartCoroutine(LoadScene(index));
                return;
            }
            characterImage.sprite = GetCharacterImage();
        }

        nameText.text = splitLine[0].Trim();
        if (splitLine.Length > 1) StartCoroutine(CharacterWrite(splitLine[1].Trim()));
        else bodyText.text = "";
    }

    private void InitializeInk()
    {
        story = new Story(inkJSONAsset.text);
    }

    private void InitializeUI()
    {
        conversationCanvasGroup = conversationPanel.GetComponent<CanvasGroup>();
        fadeToBlackCanvasGroup = fadeToBlack.GetComponent<CanvasGroup>();
        conversationCanvasGroup.alpha = 0;
        conversationPanel.SetActive(false);
        fadeToBlackCanvasGroup.alpha = 1;
        fadeToBlack.SetActive(true);
        StartCoroutine(FadeCanvasGroup(FadeType.Out, fadeToBlackCanvasGroup));
    }

    public void LoadSceneRemote(int sceneIndex, bool isMinigame)
    {
        if (!isMinigame)
        {
            var canLoad = (int)story.variablesState["loadScene"];
            if (canLoad == 0)
            {
                Debug.LogWarning("Story will not allow you to load the scene.");
                return;
            }
        }
        StartCoroutine(LoadScene(sceneIndex));
    }

    private IEnumerator LoadScene(int sceneIndex)
    {
        EndConversation();
        StartCoroutine(FadeCanvasGroup(FadeType.In, fadeToBlackCanvasGroup));
        AsyncOperation aSync = SceneManager.LoadSceneAsync(sceneIndex);
        aSync.allowSceneActivation = false;
        while (fadeToBlackCanvasGroup.alpha != 0 && aSync.isDone)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 1;
        aSync.allowSceneActivation = true;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeCanvasGroup(FadeType.Out, fadeToBlackCanvasGroup));
        yield return null;
    }

    //TODO: Refactor this, there has to be a better way. Use a fucking dictionary.
    private Sprite GetCharacterImage(Sprite charSprite = null)
    {
        string tag = story.currentTags[0];
        for (int i = 0; i < expressionSprites.Length; i++)
        {
            if (tag == expressionSprites[i].name)
            {
                charSprite = expressionSprites[i];
                break;
            }
        }

        if (charSprite == null)
        {
            Debug.LogWarning("Something went wrong with updating the character expression. Ink Tag: " + tag);
            charSprite = expressionSprites[expressionSprites.Length - 1];
        }
        else
        {
            if (charSprite.name.StartsWith("halle"))
            {
                decorationSquare.color = halleColor;
            }
            else if (charSprite.name.StartsWith("kay"))
            {
                decorationSquare.color = kayColor;
            }
            else if (charSprite.name.StartsWith("vanya"))
            {
                decorationSquare.color = vanyaColor;
            }
            else
            {
                decorationSquare.color = Color.white;
            }
        }
        Debug.Log("Character Sprite: " + charSprite.name);
        return charSprite;
    }

    public void StartConversation(string tag)
    {
        story.ChoosePathString(tag);
        UpdateText();
        StartCoroutine(FadeCanvasGroup(FadeType.In, conversationCanvasGroup));
    }

    private void EndConversation()
    {
        Debug.Log("End of conversation.");
        StartCoroutine(FadeCanvasGroup(FadeType.Out, conversationCanvasGroup));
    }

    private IEnumerator FadeCanvasGroup(FadeType fadeType, CanvasGroup canvasGroup)
    {
        int targetAlpha = (int)fadeType;

        if (fadeType == FadeType.In)
        {
            canvasGroup.gameObject.SetActive(true);
        }

        while (canvasGroup.alpha != targetAlpha)
        {
            if (canvasGroup.alpha < targetAlpha)
            {
                canvasGroup.alpha += Time.smoothDeltaTime * fadeSpeed;
            }
            else
            {
                canvasGroup.alpha -= Time.smoothDeltaTime * fadeSpeed;
            }
            yield return new WaitForEndOfFrame();
        }

        if (fadeType == FadeType.Out)
        {
            canvasGroup.gameObject.SetActive(false);
        }
    }

    private IEnumerator CharacterWrite(string line)
    {
        bodyText.text = "";
        continueImage.enabled = false;
        isWritingText = true;
        characterWriteDelay = normalCharacterWriteDelay;
        char[] lineChars = line.ToCharArray();
        for (int i = 0; i < lineChars.Length; i++)
        {
            bodyText.text += lineChars[i];
            yield return new WaitForSeconds(characterWriteDelay);
        }
        isWritingText = false;
        continueImage.enabled = true;
        yield return null;
    }

    public void GenerateChoices()
    {
        choicesPanel.SetActive(true);
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            if (i >= choicesButtons.Length)
            {
                Debug.LogError("Exceeded max number of choices.");
                return;
            }
            choicesButtons[i].GetComponentInChildren<Text>().text = story.currentChoices[i].text.Trim();
            choicesButtons[i].gameObject.SetActive(true);
        }
    }

    public void OnChoiceClick(int i)
    {
        choicesPanel.SetActive(false);
        foreach (Button button in choicesButtons)
        {
            button.gameObject.SetActive(false);
        }
        Debug.Log("Choice Picked: " + story.currentChoices[i].text);
        story.ChooseChoiceIndex(i);
        UpdateText();
    }
}
