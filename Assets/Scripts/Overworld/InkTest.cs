using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkTest : MonoBehaviour {

    [SerializeField]
    private TextAsset inkJSONAsset;
    private Story story;
    [SerializeField]
    private Text textField;
    [SerializeField]
    private GameObject choicesPanel;
    [SerializeField]
    private Button[] choicesButtons;
    [SerializeField]
    private Sprite[] kayExpressions;
    [SerializeField]
    private Image textBoxImage;

    private void Awake()
    {
        story = new Story(inkJSONAsset.text);
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
        textField.text = story.Continue().Trim();
        if(story.currentTags.Count > 0)
        {
            Sprite temp = null;
            foreach (string i in story.currentTags)
            {
                if (i.StartsWith("kay"))
                {
                    switch (i)
                    {
                        case "kay_happy":
                            temp = kayExpressions[0];
                            break;
                        case "kay_sad":
                            temp = kayExpressions[1];
                            break;

                    }
                }
            }
            if(temp == null)
            {
                Debug.LogError("Something went wrong with updating the character expression");
                return;
            }
            textBoxImage.sprite = temp;
        }
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
