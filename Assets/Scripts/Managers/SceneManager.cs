using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Dungeoneer.Managers
{
    public class SceneChangingManager : IInitializable
    {

        public enum Scene
        {
            MainMenu,
            Loading,
            SampleScene
        }

        private Scene _currentScene;

        public class ChangeSceneSignal
        {
            public string Name { get; set; }
        }

        public void Initialize()
        {
            _currentScene = (Scene)Enum.Parse(typeof(Scene), SceneManager.GetActiveScene().name);
        }


    }

}
