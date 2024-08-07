//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//using TMPro;

//public enum QuestionType
//{
//    MultipleChoice,
//    TileBased
//}

//public class GameManager : MonoBehaviour
//{
//    public GameObject multipleChoiceQuestionPanel;
//    public GameObject tileBasedQuestionPanel;
//    public GameObject categorySelectionPanel;
//    public GameObject answerExplanationPanel;

//    public TextMeshProUGUI answerResultText;
//    public TextMeshProUGUI explanationText;
//    public QuestionAnswerSet[] questionAnswerSets;
//    public Button continueButton;
//    public int currentQuestionIndex;
//    public int currentCategoryIndex;
//    public static GameManager instance; public GameObject winPanel;
//    public TextMeshProUGUI correctAnswersText;
//    public TextMeshProUGUI wrongAnswersText;
//    public Button tryAgainButton;
//    public Button homeButton;

//    private int correctAnswers;
//    private int wrongAnswers;
//    private bool isAnswerCorrect;
   
//    private void Awake()
//    {
//        instance = this;
//        // Instantiate the "questionAnswerSets" array
//        questionAnswerSets = new QuestionAnswerSet[1];

//        // Populate the "questionAnswerSets" array with questions and choices
//        questionAnswerSets[0] = new QuestionAnswerSet();
//        questionAnswerSets[0].questionAnswers = new QuestionAnswer[3];

//        // Question 1
//        questionAnswerSets[0].questionAnswers[0] = new QuestionAnswer();
//        questionAnswerSets[0].questionAnswers[0].question = "What is the capital of France?";
//        questionAnswerSets[0].questionAnswers[0].choices = new string[] { "Paris", "London", "Madrid","kkkk" };
//        questionAnswerSets[0].questionAnswers[0].correctAnswer = "Paris";
//        questionAnswerSets[0].questionAnswers[0].explanation = "Paris is the capital of France.";

//        // Question 2
//        questionAnswerSets[0].questionAnswers[1] = new QuestionAnswer();

//        questionAnswerSets[0].questionAnswers[1].question = "What is the tallest mammal?";
//        questionAnswerSets[0].questionAnswers[1].choices = new string[] { "Giraffe", "Elephant", "Hippopotamus" };
//        questionAnswerSets[0].questionAnswers[1].correctAnswer = "Giraffe";
//        questionAnswerSets[0].questionAnswers[1].explanation = "Giraffe is the tallest mammal in the world.";

//        // Question 3
//        questionAnswerSets[0].questionAnswers[2] = new QuestionAnswer();
//        questionAnswerSets[0].questionAnswers[2].question = "Which planet is closest to the sun?";
//        questionAnswerSets[0].questionAnswers[2].choices = new string[] { "Mercury", "Venus", "Mars" };
//        questionAnswerSets[0].questionAnswers[2].correctAnswer = "Mercury";
//        questionAnswerSets[0].questionAnswers[2].explanation = "Mercury is the closest planet to the sun.";
//    }

    

//    void Start()
//    {
//        //  ShowCategorySelection();
//        currentQuestionIndex = 0;
//    }

//    public void OnCategorySelected(int index)
//    {
//        currentCategoryIndex = index;
//        currentQuestionIndex = 0;
//        categorySelectionPanel.SetActive(false);
//        ShowNextQuestion();
//    }

//    public void ShowNextQuestion()
//    {
//        if (currentQuestionIndex < questionAnswerSets[currentCategoryIndex].questionAnswers.Length)
//        {
//            // First, turn off all the question panels
//            multipleChoiceQuestionPanel.SetActive(false);
//            tileBasedQuestionPanel.SetActive(false);

//            // Check the current question's index and display the corresponding question
//            if (currentQuestionIndex % 2 == 0)
//            {
//                if (questionAnswerSets[currentCategoryIndex].questionAnswers[currentQuestionIndex].questionType == QuestionType.MultipleChoice)
//                {
//                    multipleChoiceQuestionPanel.SetActive(true);
//                    multipleChoiceQuestionPanel.GetComponent<MultipleChoiceQuestion>().SetNewQuestion(currentQuestionIndex);
//                }
//                else
//                {
//                    tileBasedQuestionPanel.SetActive(true);
//                    tileBasedQuestionPanel.GetComponent<TileGameplay>().SetNewQuestion(currentQuestionIndex);
//                }
//            }
//            else
//            {
//                if (questionAnswerSets[currentCategoryIndex].questionAnswers[currentQuestionIndex].questionType == QuestionType.TileBased)
//                {
//                    tileBasedQuestionPanel.SetActive(true);
//                    tileBasedQuestionPanel.GetComponent<TileGameplay>().SetNewQuestion(currentQuestionIndex);
//                }
//                else
//                {
//                    multipleChoiceQuestionPanel.SetActive(true);
//                    multipleChoiceQuestionPanel.GetComponent<MultipleChoiceQuestion>().SetNewQuestion(currentQuestionIndex);
//                }
//            }
//            currentQuestionIndex++;
//        }
//    }



//    public void clickOnCirculatory()
//    {

//    }

//    public void login()
//    {

//    }

//    public void ShowCategorySelection()
//    {
//        categorySelectionPanel.SetActive(true);
//        multipleChoiceQuestionPanel.SetActive(false);
//        tileBasedQuestionPanel.SetActive(false);
//    }

//    public void OnCorrectAnswer()
//    {
//        answerExplanationPanel.SetActive(false);
//        multipleChoiceQuestionPanel.GetComponent<MultipleChoiceQuestion>().ResetChoiceColors();
//        currentQuestionIndex++;
//        if (currentQuestionIndex == questionAnswerSets[currentCategoryIndex].questionAnswers.Length)
//        {
//            ShowWinPanel();
//        }
//        else if (currentQuestionIndex < questionAnswerSets[currentCategoryIndex].questionAnswers.Length)
//        {
//            ShowNextQuestion();
//        }
//    }

//    public void OnIncorrectAnswer()
//    {
//        answerExplanationPanel.SetActive(false);
//        multipleChoiceQuestionPanel.GetComponent<MultipleChoiceQuestion>().ResetChoiceColors();
//        wrongAnswers++;
//        currentQuestionIndex++;
//        if (currentQuestionIndex == questionAnswerSets[currentCategoryIndex].questionAnswers.Length)
//        {
//            ShowWinPanel();
//        }
//        else if (currentQuestionIndex < questionAnswerSets[currentCategoryIndex].questionAnswers.Length)
//        {
//            ShowNextQuestion();
//        }
//    }

//    public void ShowWinPanel()
//    {
//        winPanel.SetActive(true);
//        correctAnswersText.text = correctAnswers.ToString();
//        wrongAnswersText.text = wrongAnswers.ToString();
//        tryAgainButton.onClick.AddListener(TryAgain);
//        homeButton.onClick.AddListener(GoToHome);
//    }
//    private void TryAgain()
//    {
//        // Restart the game
//        correctAnswers = 0;
//        wrongAnswers = 0;
//        currentQuestionIndex = 0;
//        ShowNextQuestion();
//    }

//    private void GoToHome()
//    {

//    }
//}