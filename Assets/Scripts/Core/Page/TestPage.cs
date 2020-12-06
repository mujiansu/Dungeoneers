using System.Collections;
using System.Collections.Generic;
using Dugeoneer.Players.Characters;
using UnityEngine;

public class TestPage : MonoBehaviour
{
    public PlayerInput userInput;
    public PageController pageController;

    void Update()
    {
        if (userInput.Keystroke.triggered)
        {
            Debug.Log("Key was pressed");
            if (!pageController.PageIsOn(PageType.MENU))
            {
                pageController.TurnPageOn(PageType.MENU);
            }
            else
            {
                pageController.TurnPageOff(PageType.MENU);
            }
        }
    }
}
