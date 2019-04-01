using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject {
    //Story Text
   [TextArea(10,14)] [SerializeField] string storyText;
    public string GetStateStory()
    {
        return storyText;
    }
    //First Option
   [TextArea(3, 5)] [SerializeField] string optionOne;
    public string GetOptionOne()
    {
        return optionOne;
    }
    //Second Option
    [TextArea(3, 5)] [SerializeField] string optionTwo;
    public string GetOptionTwo()
    {
        return optionTwo;
    }
    //Last Option
    [TextArea(3, 5)] [SerializeField] string optionThree;
    public string GetOptionThree()
    {
        return optionThree;
    }
    [SerializeField] State[] nextStates;
    //These are the states that are available from this state
    public State[] GetNextStates ()
    {
        return nextStates;
    }

}
