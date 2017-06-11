using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Selector : MonoBehaviour {

    public SpawnableObject spawnable;
    public UnityEvent leftPress;
    public UnityEvent rightPress;
    public UnityEvent upPress;
    public UnityEvent downPress;
    public float stickThreshold = 0.5f;
    public float xRepeatDelay = 0.25f;
    public float yRepeatDelay = 0.1f;
    public bool xRepeatScaled = false;
    public bool yRepeatScaled = false;

    float xAxisPrev = 0f;
    float yAxisPrev = 0f;

    float xCooldown = 0f;   
    float yCooldown = 0f;

    Vector2 pad;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pad = spawnable.thumbPad;

        float thresh = yRepeatScaled ? 0.15f : stickThreshold;

        if (Mathf.Abs(pad.x) >= thresh)
        {
            float cd = Mathf.Max(0.03f, (xRepeatScaled ? xRepeatDelay * (1 - Mathf.Sqrt(Mathf.Abs(pad.x))) : xRepeatDelay));
            xCooldown = Mathf.Min(xCooldown, Time.time + cd);
            if (Mathf.Abs(xAxisPrev) + 0.02 < thresh || Time.time > xCooldown)
            {
                if (pad.x < 0) leftPress.Invoke();
                else rightPress.Invoke();
                xCooldown = Time.time + cd;
            }
        }


        if (Mathf.Abs(pad.y) >= thresh)
        {
            float cd = Mathf.Max(0.03f, (yRepeatScaled ? yRepeatDelay * (1 - Mathf.Sqrt(Mathf.Abs(pad.y))) : yRepeatDelay));
            yCooldown = Mathf.Min(yCooldown, Time.time + cd);
            if (Mathf.Abs(yAxisPrev) + 0.02 < thresh || Time.time > yCooldown)
            {
                if (pad.y < 0) downPress.Invoke();
                else upPress.Invoke();
                yCooldown = Time.time + cd;
            }
        }

        xAxisPrev = pad.x;
        yAxisPrev = pad.y;

    }
}
