using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private GameObject freePlayModeUI;

    [Header("Spatial Pulls")]
    [SerializeField] private GameObject spatialPulls;

    [Header("Game Mode Script")]
    [SerializeField] private ScaleSequence scaleSequence;
    [SerializeField] private GameObject coachingCard;

    [Header("Coaching Cards (in order)")]
    [SerializeField] private GameObject[] coachingCards;

    [Header("Platonic Solids")]
    [SerializeField] public GameObject platonicSolids;

    private int currentCardIndex = 0;

    private void Start()
    {
        DeactivateAll();
    }

    public void ActivateGameModeAorB()
    {
        DeactivateAll();

        spatialPulls.SetActive(true);
        
        scaleSequence.enabled = true;

        if (tutorialUI != null && tutorialUI.activeInHierarchy)
        {
            scaleSequence.isTutorial = true;

            if (coachingCard != null)
            {
                coachingCard.SetActive(false);
            }
        }

        if (freePlayModeUI != null && freePlayModeUI.activeInHierarchy)
        {
            scaleSequence.isTutorial = false;

            if (coachingCard != null)
            {
                coachingCard.SetActive(false);
            }

            if (platonicSolids != null)
            {
                platonicSolids.SetActive(true);
            }
        }
    }

    private void DeactivateAll()
    {
        scaleSequence.ResetState();
        spatialPulls.SetActive(false);
        scaleSequence.enabled = false;

        if (platonicSolids != null)
        {
            platonicSolids.SetActive(false);
        }
    }

    public void NextCoachingCard()
    {
        if (coachingCards == null || coachingCards.Length == 0) return;

        coachingCards[currentCardIndex].SetActive(false);
        currentCardIndex = (currentCardIndex + 1) % coachingCards.Length;
        coachingCards[currentCardIndex].SetActive(true);
    }

    public void ReturnToCoachingCard()
    {
        DeactivateAll();

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