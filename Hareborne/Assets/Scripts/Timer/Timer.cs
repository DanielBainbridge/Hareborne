using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text m_timerText;
    private float m_startTime;

    // Start is called before the first frame update
    void Start()
    {
        m_startTime = Time.time;
        m_timerText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time - m_startTime;
        string minutes = ((int)currentTime / 60).ToString();
        string seconds = (currentTime % 60).ToString("f2");

        m_timerText.text = minutes + " : " + seconds;

    }
    // Add function get current time
}