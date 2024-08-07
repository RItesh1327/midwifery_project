//using UnityEngine;
//using TMPro;
//using System.Linq;
//using UnityEngine.UI;
//using System;

//public class TileGameplay : MonoBehaviour
//{
//    public GameObject[] hexagonalTiles;
//    public TextMeshProUGUI questionText;
//    private string currentAnswer = "";
//    private GameObject[] selectedTiles;
//    public bool isAnswerCorrect;
//    private void Start()
//    {
//        selectedTiles = new GameObject[0];
//        foreach (GameObject tile in hexagonalTiles)
//        {
//            Button tileButton = tile.GetComponent<Button>();
//            tileButton.onClick.AddListener(() => OnTileClicked(tile));
//        }
//    }

//    public void OnTileClicked(GameObject selectedTile)
//    {
//        // Get the letter on the selected tile
//        TextMeshProUGUI letterText = selectedTile.GetComponentInChildren<TextMeshProUGUI>();
//        string selectedLetter = letterText.text;

//        // Check if the tile is already selected
//        int index = Array.IndexOf(selectedTiles, selectedTile);
//        if (index != -1)
//        {
//            // Remove the letter and deselect the tile
//            currentAnswer = currentAnswer.Remove(index, 1);
//            selectedTile.GetComponent<UnityEngine.UI.Image>().color = Color.white;
//            selectedTiles = selectedTiles.Where((val, idx) => idx != index).ToArray();
//        }
//        else
//        {
//            currentAnswer += selectedLetter;
//            //Highlight the selected tile
//            selectedTile.GetComponent<UnityEngine.UI.Image>().color = new Color(1.0f, 0.5f, 0.0f);
//            // Keep track of all selected tiles
//            Array.Resize(ref selectedTiles, selectedTiles.Length + 1);
//            selectedTiles[selectedTiles.Length - 1] = selectedTile;
//            Debug.Log("Current Answer: " + currentAnswer);

//            // Check if the current answer matches the correct answer
//            if (currentAnswer == GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[GameManager.instance.currentQuestionIndex].correctAnswer)
//            {
//                // If correct, show the explanation panel and update the correct answers count
//                GameManager.instance.continueButton.onClick.AddListener(() => GameManager.instance.OnCorrectAnswer());
//                Debug.Log("correct tiles selected");
//                Debug.Log("Correct Answer: " + GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[GameManager.instance.currentQuestionIndex].correctAnswer);
//                GameManager.instance.tileBasedQuestionPanel.SetActive(false);
//                GameManager.instance.explanationText.text = GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[GameManager.instance.currentQuestionIndex].explanation;
//                ResetTileColors();
//                GameManager.instance.answerExplanationPanel.SetActive(true);
//            }
//        }

//    }
//    public void SetNewQuestion(int currentQuestionIndex)
//    {
//        questionText.text = GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[currentQuestionIndex].question;
//        for (int i = 0; i < hexagonalTiles.Length; i++)
//        {
//            TMP_Text letterText = hexagonalTiles[i].GetComponentInChildren<TMP_Text>();
//            letterText.text = GameManager.instance.questionAnswerSets[GameManager.instance.currentCategoryIndex].questionAnswers[currentQuestionIndex].letters[i];
//        }
//    }

//    public void ResetTileColors()
//    {
//        currentAnswer = "";
//        if (selectedTiles != null)
//        {
//            for (int i = 0; i < selectedTiles.Length; i++)
//            {
//                if (selectedTiles[i] != null)
//                {
//                    selectedTiles[i].GetComponent<UnityEngine.UI.Image>().color = Color.white;
//                }
//            }
//        }
//        selectedTiles = new GameObject[0];
//    }






//}
