using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoController : MonoBehaviour {

    public float minTempo = 20f;
    public float maxTempo = 320f;
    public float bottomOffset = 100f;
    float maxHeight;
    RectTransform rt;
    public BeadSpawner beadSpawner;

    public Text bpmText;

    // Use this for initialization
    void Start () {
        rt = GetComponent<RectTransform>();
        maxHeight = rt.rect.height;
        ModifyTempo(0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ModifyTempo(float tempoOffset)
    {
        float bmp = beadSpawner.bpm + tempoOffset;
        beadSpawner.bpm = Mathf.Clamp(bmp, minTempo, maxTempo);
        bpmText.text = beadSpawner.bpm.ToString("0");

        float y = bottomOffset + (maxHeight - bottomOffset) * (beadSpawner.bpm - minTempo) / (maxTempo - minTempo) - maxHeight;
        rt.sizeDelta = new Vector2(-720f, y);
    }

}
