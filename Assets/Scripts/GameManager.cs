using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused = false;
    public GameObject pauseMenuUi;
    public TextMeshProUGUI applesCollectedText;
    public int applesCollected = 0;
    private List<AudioSource> audioSources = new List<AudioSource>();
    public List<AudioSource> excludedAudioSources = new List<AudioSource>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        applesCollectedText.text = "Apples Collected: 0";
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void CollectApples()
    {
        applesCollected++;
        applesCollectedText.text = "Apples Collected: " + applesCollected;
        Debug.Log("Apples Collected: " + applesCollected);
    }
    public void Resume()
    {
        isPaused = false;
        pauseMenuUi.SetActive(false);
        ResumeAudio();
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenuUi.SetActive(true);
        PauseAudio();
        Time.timeScale = 0f;
    }
    public void PauseAudio()
    {
        // AudioListener.pause = true;

        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            if (audio.isPlaying && !excludedAudioSources.Contains(audio))
            {
                audio.Pause();
                audioSources.Add(audio);
            }
        }
    }

    public void ResumeAudio()
    {
        // AudioListener.pause = false;
        for (int i = audioSources.Count - 1; i >= 0; i--)
        {
            if (audioSources[i])
            {
                audioSources[i].UnPause();
                audioSources.RemoveAt(i);
            }
        }
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
