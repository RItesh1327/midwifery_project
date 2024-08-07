using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARScript : MonoBehaviour
{
    public GameObject heartModel;
    public GameObject questionPanel;
    public TMPro.TextMeshProUGUI questionText;
    public GameObject[] choiceButtons;
    public GameObject submitButton;
    public GameObject answerExplanationPanel;
 //   public TMPro.TextMeshProUGUI resultText;
    public TMPro.TextMeshProUGUI explanationText;
    public GameObject continueButton;

    public List<GameObject> points = new List<GameObject>();
    private int currentPoint = 0;
    private bool modelPlaced = false;
    private Transform modelTransform;
    private float rotationSensitivity = 0.1f; // Lower the sensitivity of rotation

    private Vector2 touchStartPos;

    void Start()
    {
        questionPanel.SetActive(false);
        answerExplanationPanel.SetActive(false);

        // Add Mesh Collider to heart model
        MeshCollider collider = heartModel.AddComponent<MeshCollider>();
        collider.convex = true;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (!modelPlaced)
            {
                // Place the heart model on the real-world plane
                modelTransform = Instantiate(heartModel, Vector3.zero, Quaternion.identity).transform;
                modelPlaced = true;
            }
            else if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Check if the touch is on the heart model
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("Heart"))
                    {
                        // Rotate the heart model based on swipe direction
                        Vector2 swipe = touch.position - touchStartPos;
                        modelTransform.Rotate(new Vector3(0, swipe.x * rotationSensitivity, 0));
                    }
                    else if (points.Contains(hit.transform.gameObject))
                    {
                        // Display the question panel for the touched point
                        PointData pointData = hit.transform.GetComponent<PointData>();
                        questionText.text = pointData.question;
                        questionPanel.SetActive(true);
                        for (int i = 0; i < pointData.choices.Length; i++)
                        {
                            choiceButtons[i].SetActive(true);
                            choiceButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = pointData.choices[i];
                        }
                    }
                }
            }
        }
    }
    public void OnSubmitButtonClicked(int choice)
    {
        PointData pointData = points[currentPoint].GetComponent<PointData>();
        if (choice == pointData.correctChoice)
        {
           // resultText.text = "Correct!";
        }
        else
        {//resultText.text = "Incorrect!";
        }
        submitButton.SetActive(false);
        currentPoint++;
        if (currentPoint >= points.Count)
        {
            currentPoint = 0;
        }
        answerExplanationPanel.SetActive(true);
        explanationText.text = pointData.explanation;
    }
    public void OnContinueButtonClicked()
    {
        answerExplanationPanel.SetActive(false);
        questionPanel.SetActive(true);

        
        // Add the code here to display the next question and choices
    PointData pointData = points[currentPoint].GetComponent<PointData>();
        questionText.text = pointData.question;
        for (int i = 0; i < pointData.choices.Length; i++)
        {
            choiceButtons[i].SetActive(true);
            choiceButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = pointData.choices[i];
        }
    }
}

