using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] Text option1;
    [SerializeField] Text option2;
    [SerializeField] Text option3;

    State currentState;

    // Use this for initialization
    void Start () {
        currentState = startingState;
        UpdateText();
	}

    private void UpdateText()
    {
        textComponent.text = currentState.GetStateStory();
        option1.text = currentState.GetOptionOne();
        option2.text = currentState.GetOptionTwo();
        option3.text = currentState.GetOptionThree();
    }



    // Update is called once per frame
    void Update () {
        ManageState();
	}

    private void ManageState()
    {
        //using var because the function returns the specific type of variable so I don't have to tell C# what it is. Thats pretty cool.
        var nextStates = currentState.GetNextStates();
        var length = nextStates.Length;
        if (Input.GetKeyDown(KeyCode.Alpha1) && length >= 1)
        {
            currentState = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && length >= 2)
        {
            currentState = nextStates[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && length >= 3)
        {
            currentState = nextStates[2];
        }
        UpdateText();
    }
}
