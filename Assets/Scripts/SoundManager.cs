using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource soundObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // Spawn in gameObject
        AudioSource audioSource = Instantiate(soundObject, spawnTransform.position, Quaternion.identity);

        // Assign the audioClip
        audioSource.clip = audioClip;

        // Assign volume
        audioSource.volume = volume;

        // Play sound
        audioSource.Play();

        // Get length of sound clip
        float clipLength = audioSource.clip.length;

        // Destroy the clip after it is done
        Destroy(audioSource.gameObject, clipLength);
    }

    public void StopAllSounds()
    {
        // Find every AudioSource spawned by this manager and destroy it.
        // The spawned prefab is named after the soundObject prefab ("Sound Object(Clone)" or similar).
        // Using the prefab name ensures we only stop OUR spawned sounds, not UI audio or other sources.
        string targetName = soundObject.name + "(Clone)";

        AudioSource[] allSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (AudioSource src in allSources)
        {
            if (src.gameObject.name == targetName)
            {
                Destroy(src.gameObject);
            }
        }
    }
}
