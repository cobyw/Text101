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
    [SerializeField] Image image;

    State currentState;
    private IEnumerator coroutine;

    //adding a fade when selecting a choice
    private float targetAlpha;
    private float fadeRate;
    private float waitTime;

    // Use this for initialization
    void Start () {
        currentState = startingState;
        UpdateText();
        targetAlpha = 0;
        fadeRate = 10.0f;
        waitTime = .25f;
    }

    private void UpdateText()
    {
        textComponent.text = currentState.GetStateStory();
        option1.text = currentState.GetOptionOne();
        option2.text = currentState.GetOptionTwo();
        option3.text = currentState.GetOptionThree();
    }



    // Update is called once per frame
    void Update()
    {
        ManageState();
        Color curColor = image.color;
        float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            image.color = curColor;
        }
        //if the blocker is opaque enough set the target back to 0 and update the text
        if ( curColor.a >= 0.95f)
        {
            UpdateText();
            FadeOut();
        }
    }

    private void ManageState()
    {
        //using var because the function returns the specific type of variable so I don't have to tell C# what it is. Thats pretty cool.
        var nextStates = currentState.GetNextStates();
        //make sure there are enough states for the keypress
        for (int index=0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1+index))
            {
                currentState = nextStates[index];
                FadeIn();
                
            }
        }
    }
        private void FadeOut()
        {
            targetAlpha = 0.0f;
        }

        private void FadeIn()
        {
            targetAlpha = 1.0f;
        }
    }
