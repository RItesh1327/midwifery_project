using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject getStartedPanel;
    public GameObject onboardingPanel1;
    public GameObject onboardingPanel2;
    public GameObject onboardingPanel3;
    public GameObject loginPanel;
    public GameObject HomePanel;
    public GameObject TrivialORPanel;
    public GameObject ChooseagamePanel;
    public GameObject ProfilePanel;
    public GameObject LeaderboardPanel;

    void Start()
    {
        ShowPanelWithAnimation(getStartedPanel);
    }

    public void ShowPanelWithAnimation(GameObject panel)
    {
        Debug.Log("animation is playing");
        // Deactivate all panels
        getStartedPanel.SetActive(false);
        onboardingPanel1.SetActive(false);
        onboardingPanel2.SetActive(false);
        onboardingPanel3.SetActive(false);
        loginPanel.SetActive(false);
        HomePanel.SetActive(false);
        TrivialORPanel.SetActive(false);
        ChooseagamePanel.SetActive(false);
        ProfilePanel.SetActive(false);
        LeaderboardPanel.SetActive(false);

        panel.transform.localPosition = new Vector3(0, panel.transform.localPosition.y, panel.transform.localPosition.z);
        // Move the selected panel off screen
        panel.transform.DOLocalMoveX(1000, 0.2f).SetEase(Ease.InBack).OnComplete(() =>
        {
            // Set the selected panel to active
            panel.SetActive(true);

            // Move the selected panel back to the center of the screen
            panel.transform.DOLocalMoveX(-214, 0.35f).SetEase(Ease.OutBack);
        });
    }


    public void on1()
    {
        Debug.Log("nohtis");
    }
}
