using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class HorizontalPager : MonoBehaviour {

    public bool wrapAround;
    public UpdateEvent onChange;
    public Text activeItemDisplay;
    [HideInInspector]
    private int currentIndex = 0;
    [HideInInspector]
    public string activeItem;
    private List<string> _items;
    public List<string> items
    {
        get
        {
            return _items;
        }
        set
        {
            _items = value;
            currentIndex = 0;
            ChangeValue(0);
        }
    }

    [System.Serializable]
    public class UpdateEvent : UnityEvent<string> { }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LeftPress()
    {
        ChangeValue(-1);        
    }

    public void RightPress()
    {
        ChangeValue(1);
    }

    private void ChangeValue(int steps)
    {
        currentIndex += steps;
        activeItem = _items[currentIndex];
        onChange.Invoke(activeItem);
    }



}
