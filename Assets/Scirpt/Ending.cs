using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip audioClip; // Assign your audio clip in the Inspector
    public string nextSceneName; // Name of the next scene to load

    void Start()
    {
        audioSource.clip = audioClip;

        // Play the audio clip
        audioSource.Play();
    }

    void Update()
    {
        // Check if the audio clip has finished playing
        if (!audioSource.isPlaying)
        {
            // If the audio has finished, transition to the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
