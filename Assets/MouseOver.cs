using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {
    public GameObject tooltip;
	// Use this for initialization
	void OnMouseEnter() {
        if (gameObject.name == "RITUALS") {
            tooltip.GetComponent<MouseDetectRituals>().ShowText("RITUALS");
        }
        else if (gameObject.name == "ACTIONS") {
            tooltip.GetComponent<MouseDetectRituals>().ShowText("ACTIONS");
        }
    }
    void OnMouseExit() {
        tooltip.GetComponent<MouseDetectRituals>().DeleteText();

    }
}
