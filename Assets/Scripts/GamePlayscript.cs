using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class GamePlayscript : MonoBehaviour
{
    public GameObject multipleChoicePanel;
    public TMP_Text questionText;
    public GameObject[] choiceButtons;
    public GameObject explanationPanel;
    public TMP_Text explanationText;
    public GameObject continueButton;
    public GameObject tilePanel;
    public TMP_Text tileQuestionText;
    public GameObject[] tiles;
    public TMP_Text[] tileTexts;
    public string correctWord;
    public GameObject Winpannel;
    public GameObject gamemode;
    private int currentQuestion = 1;
    private int currentTile = 0;
    private string selectedWord = "";
    private bool isTileQuestion = false;// Use this for initialization
    void Start()
    {

    }

    public void gameStart()
    {
        multipleChoicePanel.SetActive(true);
        tilePanel.SetActive(false);
        continueButton.SetActive(false);
        explanationPanel.SetActive(false);
        gamemode.SetActive(false);
        SetMultipleChoiceQuestion(currentQuestion);
    }
    // Update is called once per frame
    void Update()
    {

        
    }

    public void SetMultipleChoiceQuestion(int questionNumber)
    {
        questionText.text = "Question " + (questionNumber + 1) + ": What is the capital of France?";
        choiceButtons[0].GetComponentInChildren<TMP_Text>().text = "Paris";
        choiceButtons[1].GetComponentInChildren<TMP_Text>().text = "London";
        choiceButtons[2].GetComponentInChildren<TMP_Text>().text = "Berlin";
        choiceButtons[3].GetComponentInChildren<TMP_Text>().text = "Rome";
    }



    public void CheckMultipleChoiceAnswer(string answer)
    {
        if (answer == "Paris")
        {
            explanationText.text = "Correct! The capital of France is Paris.";
        }
        else
        {
            explanationText.text = "Incorrect. The correct answer is Paris.";
        }
        multipleChoicePanel.SetActive(false);
        explanationPanel.SetActive(true);
        continueButton.SetActive(true);
        explanationPanel.transform.DOLocalMoveY(0f, 0.5f).From();
    }



    public void SetTileQuestion(int questionNumber)
    {
        isTileQuestion = true;
        tileQuestionText.text = "Question " + (questionNumber + 1) + ": Form the word 'HELLO' by selecting the tiles in order.";
        correctWord = "HELLO";
    }

    public void SelectTile(int tileNumber)
    {
        Image tileImage = tiles[tileNumber].GetComponent<Image>();
        tileImage.color = Color.green;
        selectedWord += tileTexts[tileNumber].text;
        currentTile++;
        DebugTile(tileNumber);
        if (currentTile == 5)
        {
            CheckTileAnswer();
        }
    }

    void DebugTile(int tileNumber)
    {
        Debug.Log("Selected Tile: " + tileTexts[tileNumber].text);
    }

    public void CheckTileAnswer()
    {
        if (selectedWord == correctWord)
        {
            explanationText.text = "Correct! You formed the word '" + correctWord + "'.";
        }
        if (selectedWord != correctWord)
        {
            explanationText.text = "Incorrect. The correct word was '" + correctWord + "'.";
        }
        explanationPanel.SetActive(true);
        continueButton.SetActive(true);
        isTileQuestion = false;
        tilePanel.SetActive(false);
        explanationPanel.transform.DOLocalMoveY(0f, 0.5f).From();
    }

    public void Continue()
    {
        if (isTileQuestion)
        {
            ResetTiles();
        }
        currentQuestion++; //increment by 1 instead of 2
        if (currentQuestion == 3) // check if currentQuestion == 4 instead of 2 
        {
            gameFinish();
        }
        else
        {
            if (currentQuestion % 2 == 0)
            {
                SetTileQuestion(currentQuestion);
                tilePanel.SetActive(true);
                continueButton.SetActive(false);
                explanationPanel.SetActive(false);
                explanationPanel.transform.DOLocalMoveY(-1000f, 0.5f).From();
            }
            else
            {
                multipleChoicePanel.SetActive(true);
                SetMultipleChoiceQuestion(currentQuestion);
                continueButton.SetActive(false);
                explanationPanel.SetActive(false);
                explanationPanel.transform.DOLocalMoveY(-1000f, 0.5f).From();
            }
        }
    }

    public void ResetTiles()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            Image tileImage = tiles[i].GetComponent<Image>();
            tileImage.color = Color.white;
        }
        selectedWord = "";
        currentTile = 0;
    }

    public void gameFinish()
    {
        Winpannel.SetActive(true);
        multipleChoicePanel.SetActive(false);
        tilePanel.SetActive(false);
        continueButton.SetActive(false);
        explanationPanel.SetActive(false);
        explanationPanel.transform.DOLocalMoveY(-1000f, 0.5f).From();
    }
}
