using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Point : MonoBehaviour
{
    public PointParent parentObject;
    public PointData data;
    public GameObject questionPanel;
    public GameObject explanationPanel;
    public List<Button> choiceButtons = new List<Button>();

    private void Start()
    {
        Reset();
        parentObject.numPoints++;
        explanationPanel.GetComponent<CanvasGroup>().alpha = 0;
        explanationPanel.transform.Find("ContinueButton").GetComponent<Button>().onClick.AddListener(OnContinueButtonClick);
        for (int i = 0; i < choiceButtons.Count; i++)
        {
            int choice = i;
            choiceButtons[i].onClick.AddListener(() => OnChoiceButtonClick(choice));
        }
    }
    private void Update()
    {
        Debug.Log(parentObject.numPoints);
    }
    public void OnMouseDown()
    {
        Reset();
        questionPanel.SetActive(true);
        questionPanel.transform.DOLocalMoveY(-Screen.height, 0.5f).From();
        questionPanel.transform.Find("QuestionText").GetComponent<TMP_Text>().text = data.question;
        for (int i = 0; i < choiceButtons.Count; i++)
        {
            choiceButtons[i].transform.Find("ChoiceText").GetComponent<TMP_Text>().text = data.choices[i];
        }
    }

    public void OnChoiceButtonClick(int choice)
    {
        questionPanel.transform.DOLocalMoveY(-Screen.height, 0.5f).OnComplete(() => {
            questionPanel.SetActive(false);
            explanationPanel.SetActive(true);
            explanationPanel.GetComponent<CanvasGroup>().DOFade(1f, 0.5f);
        });
        if (choice == data.correctChoice)
        {
            explanationPanel.transform.Find("ExplanationText").GetComponent<TMP_Text>().text = "Correct!\n\n" + data.explanation;
        }
        else
        {
            explanationPanel.transform.Find("ExplanationText").GetComponent<TMP_Text>().text = "Wrong!\n\n" + data.explanation;
        }
    }



    public void OnContinueButtonClick()
    {
        parentObject.numPoints--;
        explanationPanel.transform.DOLocalMoveY(-Screen.height, 0.5f).OnComplete(() => { explanationPanel.SetActive(false); });
        Destroy(this.gameObject);
    }


    public void Reset()
    {
        explanationPanel.SetActive(false);
        questionPanel.SetActive(false);
        questionPanel.transform.Find("QuestionText").GetComponent<TMP_Text>().text = "";
        explanationPanel.transform.Find("ExplanationText").GetComponent<TMP_Text>().text = "";
        for (int i = 0; i < choiceButtons.Count; i++)
        {
            choiceButtons[i].transform.Find("ChoiceText").GetComponent<TMP_Text>().text = "";
        }
    }
}
