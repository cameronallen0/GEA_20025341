using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public CountdownController script;

    public int numberOfLaps = 0;

    public void EditorUpdate(int n)
    {
        numberOfLaps = n;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(script.countdownTime);

        TimerController.instance.BeginTimer(); 
        LapsController.instance.LapsBegin(); 
    }
}
