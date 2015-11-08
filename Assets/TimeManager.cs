using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using Fungus;
public class TimeManager : MonoBehaviour {
    public int daysPassed;
    public int savedDay;
    public int daysUntilEnd = 6;
    public int min;
    int hungerCounter;
    int poopCounter;
    int hungerThreshold;
    int poopThreshold = 1;

    public Text clock;
    public Flowchart UserInterface;
    public DemonBehavior behaviors;
    public DemonStats stats;
    //public int 
	// Use this for initialization
	void Start () {
        
        StartCoroutine(UpdateTime());
        StartCoroutine(Cycles());

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(min);
        //UserInterface.SetIntegerVariable("DayInMemory", savedDay);
        if (DateTime.Now.TimeOfDay.Minutes == min + 1) {
            //Debug.Log("Poop");
            min++;
            hungerCounter++;
            poopCounter++;
            if(hungerCounter >= hungerThreshold) {
                behaviors.Complain();
                behaviors.IncreaseFury(stats.Fury, 1);
            }
            if(poopCounter >= poopThreshold) {
                behaviors.Poop();
            }
            if(min >= 60) {
                min = 0;
            }

           
        }

    }
    IEnumerator UpdateTime() {
        int day = DateTime.Now.Day;
        
        if (savedDay == 0) {
            savedDay = day;
            
        }
        
        Debug.Log("Day = " + day);
        while (true) {
            DateTime now = System.DateTime.Now;
            TimeSpan time = now.TimeOfDay;
            clock.text = string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);
            
            yield return null;
        }
        
    }
    IEnumerator Cycles() {
        min = DateTime.Now.TimeOfDay.Minutes;
        
        yield return null;
    }
    void TimeUntilEnd(int curDay) {
        daysPassed = curDay - savedDay;
        if(daysPassed >= daysUntilEnd) {
            //Apocalypse
        }
    }
}
