using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapsController : MonoBehaviour
{
    public static LapsController instance;   

    public TextMeshProUGUI lapCounter;

    TrackCheckpoints laps;
    GameController game;
    TimerController time;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        laps = TrackCheckpoints.instance;
        game = GameController.instance;
        time = TimerController.instance;
    }

    public void LapsBegin()
    {   

        StartCoroutine(LapsUpdate());
    }

    public IEnumerator LapsUpdate()
    {
        while(time.timerGoing)
        {
            string lapCounterStr = laps.Laps.ToString() + "/" + game.numberOfLaps.ToString();
            lapCounter.text = lapCounterStr;

            yield return null;
        }
    }        

}
