using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
public class BirdController : MonoBehaviour
{
    public float jumpForce = 5f;
    public Rigidbody rb;
    public int playerScore ;
    public int winScore;
    public AudioClip flapSound;
    private AudioSource audioSource;
    private VideoPlayer videoPlayer;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        videoPlayer = GetComponent<VideoPlayer>();
        UpdateScoreText();
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.up * jumpForce;
            if (audioSource != null && flapSound != null)
            {
                audioSource.PlayOneShot(flapSound);
            }
        }
        rb.AddForce(Vector3.forward * playerScore);
    }

    public void UpdateScoreText()
        {
            scoreText.text = $"{playerScore} / 11";
        }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            playerScore++;
            UpdateScoreText();
        }
        if (other.CompareTag("Dead"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (other.CompareTag("Ending"))
        {
            SceneManager.LoadScene("Ending");
        }
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene when the video ends
        SceneManager.LoadScene("NextScene");
    }

}