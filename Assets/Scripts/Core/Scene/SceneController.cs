using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{ 
    public delegate void SceneLoadDelegate(SceneType _scene);
    public static SceneController instance;
    public bool debugEnabled;

    private PageController _menu;
    private SceneType _targetScene;
    private PageType _loadingPage;
    private SceneLoadDelegate _sceneLoadDelegate;
    private bool _sceneIsLoading;
    private PageController menu
    {
        get 
        {
            if(_menu == null && PageController.instance != null)
            {
                _menu = PageController.instance;
            }
            else
            {
                LogWarning("You are trying to access the PageController, but no instance was found.");
            }
            return _menu;
        }
    }
    private string currentSceneName
    {
        get
        {
            return SceneManager.GetActiveScene().name;
        }
    }

#region Unity Functions
    private void Awake() 
    {
        if(!instance)
        {
            Configure();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnDisable() 
    {
        Dispose();
    }
#endregion

#region Public Functions
    public void Load(SceneType _scene, SceneLoadDelegate _sceneLoadDelegate=null, bool _reload=false, PageType _loadingPage=PageType.None)
    {
        if((_loadingPage != PageType.None && !menu) || !SceneCanBeLoaded(_scene,_reload))
        {
            return;
        }

        _sceneIsLoading = true;
        this._targetScene = _scene;
        this._loadingPage = _loadingPage;
        this._sceneLoadDelegate = _sceneLoadDelegate;
        StartCoroutine("LoadScene");

    }
#endregion

#region Private Functions
    private void Configure()
    {
        instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Dispose()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private async void OnSceneLoaded(UnityEngine.SceneManagement.Scene _scene, LoadSceneMode _mode)
    {
        if(_targetScene == SceneType.NONE)
        {
            return;
        }

        SceneType _sceneType = StringToSceneType(_scene.name);
        if(_targetScene != _sceneType)
        {
            return;
        }

        if(_sceneLoadDelegate != null)
        {
            try
            {
                _sceneLoadDelegate(_sceneType);
            } 
            catch (System.Exception)
            {
                LogWarning("Unable to respond with sceneLoadDelegate after scene ["+_sceneType+"] loaded.");
            }
        }

        if(_loadingPage != null)
        {
            menu.TurnPageOff(_loadingPage);
        }
    }

    private IEnumerator LoadScene()
    {
        if (_loadingPage != PageType.None)
        {
            menu.TurnPageOn(_loadingPage);
            while (!menu.PageIsOn(_loadingPage))
            {
                yield return null;
            }
        }

        string _targetSceneName = SceneTypeToString(_targetScene);
        SceneManager.LoadScene(_targetSceneName);
    }

    private bool SceneCanBeLoaded(SceneType _scene, bool _reload)
    {
        string _targetSceneName = SceneTypeToString(_scene);
        if(currentSceneName == _targetSceneName && !_reload)
        {
            LogWarning("You are trying to load a scene["+_scene+"] which is already active.");
            return false;
        }
        else if(_targetSceneName == string.Empty)
        {
            LogWarning("The scene you are trying to load["+_scene+"] is not valid.");
            return false;
        }
        else if(_sceneIsLoading)
        {
            LogWarning("Unable to load scene ["+_scene+"]. Another scene ["+_targetScene+"] is already loading.");
            return false;
        }
        return true;
    }

    private string SceneTypeToString(SceneType _scene)
    {
        switch (_scene)
        {
            case SceneType.GAME: return "Game";
            case SceneType.MENU: return "Menu";
            default:
                LogWarning("Scene ["+_scene+"] does not contain a string for a valid scene.");
                return string.Empty;
        }
    }

    private SceneType StringToSceneType(string _scene)
    {
        switch (_scene)
        {
            case "Game": return SceneType.GAME;
            case "Menu": return SceneType.MENU;
            default:
                LogWarning("Scene ["+_scene+"] does not contain a type for a valid scene.");
                return SceneType.NONE;
        }
    }

    private void Log( string _msg)
    {
        if(!debugEnabled)
            return;
        Debug.Log("[Scene Controller]:"+_msg);
    }

    private void LogWarning(string _msg)
    {
        if(!debugEnabled)
            return;
        Debug.LogWarning("[Scene Controller]:"+_msg);
    }
#endregion

}
