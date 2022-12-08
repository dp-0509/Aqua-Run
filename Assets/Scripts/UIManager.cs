using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public Text endText;
    public PlayerMovement player;
    public GameObject panel;
    public GameObject image;
    public int timer=60;
    public float highScore = 0;
    public GameObject instructions;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        StartCoroutine(Timer());
        endText.enabled = false;
        panel.SetActive(false);
        image.SetActive(true);  
        instructions.SetActive(false);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            image.SetActive(false);   
            Time.timeScale = 1f;
        }
        scoreText.text = "Score : " + player.score;
        endText.text = "Score : " + player.score;
        timerText.text = "" + timer;
        if (timer == 0)
        {
            Time.timeScale = 0f;
            highScore = player.score;
            endText.enabled = true;
            panel.SetActive(true);
        }
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        if (timer>0)
            timer -= 1;
        StartCoroutine(Timer());
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Instructions()
    {
        instructions.SetActive(true);
    }
}
