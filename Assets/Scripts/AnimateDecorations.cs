using DG.Tweening;
using UnityEngine;

public class AnimateDecorations : MonoBehaviour
{
    private Vector3 rotationVector = new Vector3(0f, 180f, 0f);
    private float rotationSpeed = 25f;
    private float duration = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DORotate(rotationVector, rotationSpeed, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);

        duration = duration - Random.Range(0.0f, 1f); // Add some randomness to the duration for a more natural effect

        transform.DOLocalMoveY(1f, duration).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
