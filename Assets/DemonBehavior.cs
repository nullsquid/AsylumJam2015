using UnityEngine;
using System.Collections;
using Fungus;
public class DemonBehavior : MonoBehaviour {
    public DemonStats stats;
    public Flowchart behaviors;

    private bool isInteractable;
    void Start() {
        stats = gameObject.GetComponent<DemonStats>();
        stats.tempMalice = 0.4f;
        LevelUp(1, stats._malice, 1, 1, 1, 1);
    }

    void Idle() {

    }


    public void Complain() {

    }

    void Kill (GameObject target) {


    }

    void Devour(GameObject target) {

    }

    void ThrowTantrum() {

    }

    public void Poop() {


    }

    void Sleep() {


    }

    void Pout() {


    }

    void Terrorize() {


    }

    void PlayWith(GameObject target) {

    }

    void LevelUp(float curBrutality, float curMalice, float curGuile, float curVigor, float curObscenity, float curCunning) {
        Debug.Log(stats._malice);
        curBrutality += stats.tempBrutality;
        curMalice += stats.tempMalice;
        curGuile += stats.tempGuile;

        stats._brutality = curBrutality;
        stats._guile = curGuile;
        stats._malice = curMalice;
        stats._vigor = curVigor;
        stats._cunning = curCunning;
        stats._obscenity = curObscenity;

        stats.tempBrutality = 0;
        stats.tempGuile = 0;
        stats.tempMalice = 0;
        stats.tempVigor = 0;
        stats.tempCunning = 0;
        stats.tempObscenity = 0;
    }

    public float IncreaseFury(float curFury, float increaseBy) {
        float furyMaxThreshold = 100;

        if (curFury >= furyMaxThreshold) {
            ThrowTantrum();
        }
        else if (curFury == (furyMaxThreshold * .25f) || curFury == (furyMaxThreshold * .5f) || curFury == (furyMaxThreshold * .75)){
            Complain();
        }
        return curFury += increaseBy;
    }

    public float DecreaseFury(float curFury, float decreasedBy) {

        return curFury -= decreasedBy;
    }

    public void GrowToNextStage() {

    }

    public void Update() {

    }
}
