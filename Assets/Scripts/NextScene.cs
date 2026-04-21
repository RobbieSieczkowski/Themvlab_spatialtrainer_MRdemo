using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject scaffoldedModeUIButton;

    [Header("Spatial Pulls")]
    [SerializeField] private GameObject spatialPulls;

    [Header("Game Mode Script")]
    [SerializeField] private ScaleSequence scaleSequence;

    [SerializeField] private GameObject coachingCard;

    [Header("Coaching Cards (in order)")]
    [SerializeField] private GameObject[] coachingCards;
    private int currentCardIndex = 0;

    private void Start()
    {
        // Make sure everything starts off
        DeactivateAll();
    }

    public void ActivateGameModeAorB()
    {
        DeactivateAll();

        spatialPulls.SetActive(true);

        scaleSequence.enabled = true;

        if (scaffoldedModeUIButton.activeInHierarchy)
        {
            scaleSequence.isScaffoldedMode = true;
        }

    }

    private void DeactivateAll()
    {
        scaleSequence.ResetState();

        spatialPulls.SetActive(false);

        scaleSequence.enabled = false;
    }
    public void NextCoachingCard()
    {
        coachingCards[currentCardIndex].SetActive(false);

        currentCardIndex++;

        if (currentCardIndex >= coachingCards.Length)
        {
            currentCardIndex = coachingCards.Length - 1;
            return;
        }

        coachingCards[currentCardIndex].SetActive(true);
    }

    public void ReturnToCoachingCard()
    {
        DeactivateAll();

        // Bring the coaching card back
        if (coachingCard != null)
        {
            coachingCard.SetActive(true);
        }

        for (int i = 0; i < coachingCards.Length; i++)
            coachingCards[i].SetActive(i == 0);
        currentCardIndex = 0;
    }

    /**
    public void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    **/
}
