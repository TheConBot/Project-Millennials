using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkTest : MonoBehaviour {

    [SerializeField, Header("INK File")]
    private TextAsset inkJSONAsset;
    private Story story;
    [SerializeField, Header("UI Elements")]
    private Text bodyText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameObject choicesPanel;
    [SerializeField]
    private Button[] choicesButtons;
    [SerializeField]
    private Image characterImage;
    [SerializeField]
    private Sprite[] expressionSprites;

    private readonly char[] delimiterChars = { ':' };
    private readonly string[] characterImageNames = { "halle", "kay", "vanya" };
    private readonly string[] characterImageExpressions = { "_angry", "_happy", "_neutral", "_sad", "_sarcastic", "_special" };

    private void Awake()
    {
        UI.Instance.expressionSprites = expressionSprites;
        story = new Story(inkJSONAsset.text);
        story.ChoosePathString("Kay_to_Vanya");
        UpdateText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && story.canContinue)
        {
            UpdateText();
        }
        else if(Input.GetMouseButtonDown(0) && !story.canContinue && story.currentChoices.Count == 0)
        {
            Debug.LogError("End of story!");
        }

        if(story.currentChoices.Count > 0 && !choicesPanel.activeSelf)
        {
            GenerateChoices();
        }
    }

    private void UpdateText()
    {
        string nextLine = story.Continue().Trim();
        string[] splitLine = nextLine.Split(delimiterChars);

        if(story.currentTags.Count > 0)
        {
            characterImage.sprite = GetCharacterImage();
        }

        nameText.text = splitLine[0].Trim();
        bodyText.text = splitLine[1].Trim();
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

    private void GenerateChoices()
    {
        choicesPanel.SetActive(true);
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            if(i >= choicesButtons.Length)
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
        foreach(Button button in choicesButtons)
        {
            button.gameObject.SetActive(false);
        }
        story.ChooseChoiceIndex(i);
        UpdateText();
    }
}
