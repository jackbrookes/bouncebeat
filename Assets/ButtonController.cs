using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour {

    public float cooldown = 0.2f;
    public string buttonText;
    public Button button;
    public Text buttonTextScript;
    public UnityEvent onPress;
    static float refTime = 0f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (Time.time > refTime)
        {
            button.onClick.Invoke();
            onPress.Invoke();
            refTime = Time.time + cooldown;
        }
    }
    
    [ContextMenu("Update button")]
    void UpdateButton()
    {
        buttonTextScript.text = buttonText;
    }
}
