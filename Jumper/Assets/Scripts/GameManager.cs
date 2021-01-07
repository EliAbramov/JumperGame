using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Text timerText;
    private int timerCount;

    private void Awake()
    {
        MakeSingalton();
    }
    void Start()
    {
        StartCoroutine(CountTime());
        timerText = GameObject.Find("Timer").GetComponent <Text>();
    }

    void MakeSingalton()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void RestartGame() 
    {
        StartCoroutine(RestartGameDelay());
    }

    IEnumerator RestartGameDelay()  
    {
        yield return new WaitForSecondsRealtime(2.5f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void TimerReset()
    {
        timerCount = 0;
        Time.timeScale = 1f;
    }

    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1f);

        timerCount++;

        timerText.text = "Time: " + timerCount;

        StartCoroutine(CountTime());
    }
}
