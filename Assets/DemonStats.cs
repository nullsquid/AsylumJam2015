using UnityEngine;
using System.Collections;

public class DemonStats : MonoBehaviour {


    private string _stageOfLife;
    private float _dispositionAmt;
    private float _health;
    private float _hunger;
    private float _poop;
    private float _sleepiness;
    private float _development;
    private float _energy = 50;
    private float _fury = 45;

    public float _brutality;
    public float _guile;
    public float _malice;

    public float _vigor;
    public float _cunning;
    public float _obscenity;

    public float tempBrutality;
    public float tempGuile;
    public float tempMalice;

    public float tempVigor;
    public float tempCunning;
    public float tempObscenity;


    public enum Mood {
        Happy,
        Sad,
        Angry,
        Afraid,
        Vengeful,
        Spiteful
    };
    public enum Type {
        Infernal,
        Deceptive,
        Corruptive,
        Sophic
    };


    public string StageOfLife { get; set; }
    public float DispositionAmt { get; set; }
    public float Health { get; set; }
    public float Hunget { get; set; }
    public float Poop { get; set; }
    public float Sleepiness { get; set; }
    public float Development { get; set; }
    
    public float Energy { get; set; }
    public float Fury { get; set; }


    public int AddPermanentStat(int curStat, int amount) {

        return curStat += amount;
        
    }

   
}