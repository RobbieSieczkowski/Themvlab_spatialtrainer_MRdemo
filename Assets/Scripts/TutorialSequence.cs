using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSequence : MonoBehaviour
{
    [SerializeField] private AudioClip mvgame_track1;

    private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
    }

        // Update is called once per frame
        void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.One) && !isPlaying)
        {
            // Play first voiceline
            SoundManager.instance.PlaySoundClip(mvgame_track1, transform, 1f);
            isPlaying = true;
        }
    }
}
