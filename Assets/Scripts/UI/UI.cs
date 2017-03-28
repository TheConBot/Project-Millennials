using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private GameObject conversationPanel;
    [SerializeField]
    private GameObject choicesPanel;
    [SerializeField]
    private Button[] choicesButtons;
    [SerializeField]
    private Image characterImage;
    [SerializeField]
    private Sprite[] expressionSprites;
    [Header("UI Variables"), SerializeField]
    private float fadeSpeed = 1;

    private CanvasGroup conversationCanvasGroup;

    public bool inConversation {
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

    private readonly char[] delimiterChars = { ':' };
    private readonly string[] characterImageNames = { "halle", "kay", "vanya" };
    private readonly string[] characterImageExpressions = { "_angry", "_happy", "_neutral", "_sad", "_sarcastic", "_special" };

    private void Awake()
    {
        //Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Everything else
        InitializeInk();
        InitializeUI();
    }

    public void UpdateText()
    {
        if (!story.canContinue && story.currentChoices.Count == 0)
        {
            EndConversation();
            return;
        }
        else if (!story.canContinue)
        {
            return;
        }
        string nextLine = story.Continue().Trim();
        Debug.Log(nextLine);
        string[] splitLine = nextLine.Split(delimiterChars);

        if (story.currentTags.Count > 0)
        {
            characterImage.sprite = GetCharacterImage();
        }

        nameText.text = splitLine[0].Trim();
        if (splitLine.Length > 1) bodyText.text = splitLine[1].Trim();
        else bodyText.text = "";
    }

    private void InitializeInk()
    {
        story = new Story(inkJSONAsset.text);
    }

    private void InitializeUI()
    {
        conversationCanvasGroup = conversationPanel.GetComponent<CanvasGroup>();
        conversationCanvasGroup.alpha = 0;
        conversationPanel.SetActive(false);
    }

    //TODO: Refactor this, there has to be a better way. Use a fucking dictionary.
    private Sprite GetCharacterImage(Sprite temp = null)
    {
        string tag = story.currentTags[0];
        if (tag == "none")
        {
            temp = expressionSprites[expressionSprites.Length - 1];
        }
        else
        {
            for (int i = 0; i < characterImageNames.Length; i++)
            {
                if (tag.StartsWith(characterImageNames[i]))
                {
                    for (int j = 0; j < characterImageExpressions.Length; j++)
                    {
                        if (tag.EndsWith(characterImageExpressions[j]))
                        {
                            temp = expressionSprites[i * j];
                            break;
                        }
                    }
                }
            }
        }

        if (temp == null)
        {
            Debug.LogWarning("Something may have went wrong with updating the character expression.");
        }
        return temp;
    }

    public void StartConversation(string tag)
    {
        story.ChoosePathString(tag);
        UpdateText();
        StartCoroutine(FadeCanvasGroup(FadeType.In));
    }

    private void EndConversation()
    {
        Debug.Log("End of conversation.");
        StartCoroutine(FadeCanvasGroup(FadeType.Out));
    }

    private IEnumerator FadeCanvasGroup(FadeType fadeType)
    {
        int targetAlpha = (int)fadeType;

        if(fadeType == FadeType.In)
        {
            conversationPanel.SetActive(true);
        }

        while(conversationCanvasGroup.alpha != targetAlpha)
        {
            if (conversationCanvasGroup.alpha < targetAlpha)
            {
                conversationCanvasGroup.alpha += Time.smoothDeltaTime * fadeSpeed;
            }
            else
            {
                conversationCanvasGroup.alpha -= Time.smoothDeltaTime * fadeSpeed;
            }
            yield return new WaitForEndOfFrame();
        }

        if(fadeType == FadeType.Out)
        {
            conversationPanel.SetActive(false);
        }
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
        Debug.Log(i);
        story.ChooseChoiceIndex(i);
        UpdateText();
    }
}
