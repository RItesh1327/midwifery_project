//using UnityEngine;
//using UnityEngine.UI;
//using System.Linq;
//using TMPro;

//public class MultipleChoiceQuestion : MonoBehaviour
//{
//    public TextMeshProUGUI questionText;
//    public Button[] answerButtons;
//    public GameObject answerExplanationPanel;
//    public TextMeshProUGUI explanationText;
//    private void Start()
//    {
//        for (int i = 0; i < answerButtons.Length; i++)
//        {
//            int answerIndex = i;
//            answerButtons[i].onClick.AddListener(() => OnAnswerClicked(answerIndex));
//        }
//    }

//    public void OnAnswerClicked(int selectedAnswerIndex)
//    {
//        GameManager.instance.multipleChoiceQuestionPanel.SetActive(false);

//        Debug.Log("Choices array length: " + GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[GameManager.instance.currentQuestionIndex].choices.Length);

//        if (GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[GameManager.instance.currentQuestionIndex].choices[selectedAnswerIndex] == GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[GameManager.instance.currentQuestionIndex].correctAnswer)
//        {
//            GameManager.instance.OnCorrectAnswer();
//        }
//        else
//        {
//            GameManager.instance.OnIncorrectAnswer();
//        }
//        explanationText.text = GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[GameManager.instance.currentQuestionIndex].explanation;
//        answerExplanationPanel.SetActive(true);
//    }



//    public void SetNewQuestion(int currentQuestionIndex)
//    {
//        questionText.text = GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[currentQuestionIndex].question;
//        LogChoices();
//        for (int i = 0; i < answerButtons.Length; i++)
//        {
//            answerButtons[i].GetComponentInChildren<TMP_Text>().text = GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[currentQuestionIndex].choices[i];
//        }
//    }

//    public void LogChoices()
//    {
//        string choices = "";
//        for (int i = 0; i < GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[GameManager.instance.currentQuestionIndex].choices.Length; i++)
//        {
//            choices += GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[GameManager.instance.currentQuestionIndex].choices[i] + " ";
//        }
//        Debug.Log("Choices for question " + GameManager.instance.currentQuestionIndex + ": " + choices);
//    }

//    public void ResetChoiceColors()
//    {
//        for (int i = 0; i < answerButtons.Length; i++)
//        {
//            answerButtons[i].GetComponent<Image>().color = Color.white;
//        }
//    }
//}