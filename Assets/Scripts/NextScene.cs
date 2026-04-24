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
    [SerializeField] private GameObject kinesphere;

    [Header("Game Mode Script")]
    [SerializeField] private ScaleSequence scaleSequence;
    [SerializeField] private GameObject coachingCard;

    [Header("Coaching Cards (in order)")]
    [SerializeField] private GameObject[] coachingCards;

    private int currentCardIndex = 0;

    [Header("Tutorial")]
    [SerializeField] private TutorialController tutorialController;

    private void Start()
    {
        DeactivateAll();
    }

    public void ActivateGameModeAorB()
    {
        DeactivateAll();

        if (tutorialUI != null && tutorialUI.activeInHierarchy)
        {
            scaleSequence.isTutorial = true;
            scaleSequence.enabled = false;

            if (coachingCard != null)
            {
                coachingCard.SetActive(false);
            }

            StartCoroutine(WaitThenDoSomething());

            if (tutorialController != null)
            {
                tutorialController.StartTutorial();
            }
        }

        if (freePlayModeUI != null && freePlayModeUI.activeInHierarchy)
        {
            scaleSequence.isTutorial = false;

            scaleSequence.enabled = true;

            kinesphere.SetActive(true);

            if (coachingCard != null)
            {
                coachingCard.SetActive(false);
            }

            scaleSequence.SelectScale(0);
        }
    }

    private void DeactivateAll()
    {
        scaleSequence.ResetState();
        kinesphere.SetActive(false);
        scaleSequence.enabled = false;

        if (scaleSequence.cube != null) scaleSequence.cube.SetActive(false);
        if (scaleSequence.octahedron != null) scaleSequence.octahedron.SetActive(false);
        if (scaleSequence.icosahedron != null) scaleSequence.icosahedron.SetActive(false);
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
        if (tutorialController != null)
        {
            tutorialController.StopTutorial();
        }

        SoundManager.instance.StopAllSounds();
        DeactivateAll();

        if (coachingCard != null)
        {
            coachingCard.SetActive(true);
        }

        for (int i = 0; i < coachingCards.Length; i++)
            coachingCards[i].SetActive(i == 0);

        currentCardIndex = 0;
    }

    IEnumerator WaitThenDoSomething()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(1f);
        Debug.Log("2 seconds later!");
    }

    /**
    public void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    **/
}