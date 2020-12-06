using System.Collections;
using System.Collections.Generic;
using Dugeoneer.Players.Characters;
using UnityEngine;

public class TestScene : MonoBehaviour
{

    public PlayerInput userInput;
    public SceneController sceneController;

    void Update()
    {
        if (userInput.Keystroke.ReadValue<float>() > 0f)
        {

        }
    }
}
