using UnityEngine;
using System.Collections;

public class MouseDetectRituals : MonoBehaviour {
    public string tooltipText;
    public GameObject target;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<TextMesh>().text = "";
        
	}
	
	public void ShowText(string text) {
        GetComponent<TextMesh>().text = text;

    }
    public void DeleteText() {
        this.GetComponent<TextMesh>().text = "";
    }
}
