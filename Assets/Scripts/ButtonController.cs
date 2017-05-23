using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour {

    public float cooldown = 0.2f;
    public string buttonText;
    Button button;
    Text buttonTextScript;
    static float refTime = 0f;

    // Use this for initialization
    void Start () {
        button = GetComponent<Button>();
        buttonTextScript = GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (Time.time > refTime)
        {
            button.onClick.Invoke();
            refTime = Time.time + cooldown;
        }
    }
    
    [ContextMenu("Update button")]
    void UpdateButton()
    {
        if (!buttonTextScript)
        {
            buttonTextScript = GetComponentInChildren<Text>();
        }
        buttonTextScript.text = buttonText;
    }
}
