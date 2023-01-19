using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public TextMeshProUGUI countdownDisplay;

    public static CountdownController instance;

    public int countdownTime = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //when starting, the countdown begins instantly
        StartCoroutine(CountdownToStart());
    }
    public void CountdownUpdate(int n)
    {
        countdownTime = n;
    }
    IEnumerator CountdownToStart()
    {
        //while the timer is above 0 it updates every second to display next number in countdown
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }
        //once 0 is reached go is displayed on screen for 1 second and then it is disabled (not shown on screen anymore)
        countdownDisplay.text = "GO!";

        yield return new WaitForSeconds(1f);

        FindObjectOfType<TextMeshProUGUI>().enabled = false;
    }
}
