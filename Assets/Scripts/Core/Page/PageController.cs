using System.Collections;
using UnityEngine;

public class PageController : MonoBehaviour
{

    public static PageController instance;
    public PageType EntryPage;
    public Page[] Pages;

#if UNITY_EDITOR
    public bool debugEnabled = true;
#else
    public bool debugEnabled = false;
#endif

    private Hashtable _pages;

#region Unity Functions
    private void Awake() 
    {
        if(!instance)
        {
            instance = this;
            _pages = new Hashtable();
            RegisterAllPages();
            
            if(EntryPage != PageType.NONE)
            {
                TurnPageOn(EntryPage);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
#endregion

#region Public Functions
    public void TurnPageOn(PageType _type)
    {
        if(_type == PageType.NONE)
            return;

        if(!PageExists(_type))
        {
            LogWarning("You are trying to turn a page on ["+_type+"] that has not been registerd.");
            return;
        }

        Page _page = GetPage(_type);
        _page.gameObject.SetActive(true);
        _page.Animate(true);
    }

    public void TurnPageOff(PageType _typeOff, PageType _typeOn=PageType.NONE, bool _waitForExit=false)
    {
        if(_typeOff == PageType.NONE)
            return;

        if(!PageExists(_typeOff))
        {
            LogWarning("You are trying to turn a page off ["+_typeOff+"] that has not been registerd.");
            return;
        } 

        Page _offPage = GetPage(_typeOff);
        if(_offPage.gameObject.activeSelf)
        {
            _offPage.Animate(false);
        }

        if(_typeOn == PageType.NONE)
        {
            return;
        }
        else if(!PageExists(_typeOff))
        {
            LogWarning("You are trying to turn a page on ["+_typeOn+"] that has not been registerd.");
            return;
        } 

        if(_waitForExit)
        {
            Page _onPage = GetPage(_typeOn);
            StartCoroutine(WaitForPageExit(_onPage,_offPage));
        }
        else
        {
            TurnPageOn(_typeOn);
        }
    }

    public bool PageIsOn(PageType _type)
    {
        if(!PageExists(_type))
        {
            LogWarning("You are trying to detect if a page is on ["+_type+"], but it has not been registerd.");
            return false;
        } 

        return GetPage(_type).isOn;
    }
#endregion

#region Private Functions
    private IEnumerator WaitForPageExit(Page _pageOn, Page _pageOff)
    {
        while(_pageOff.targetState != Page.PageState.IDLE)   
            yield return null;
        TurnPageOn(_pageOn.type);
    }

    private void RegisterAllPages()
    {
        foreach (Page _page in Pages)
        {
            RegisterPage(_page);
        }
    }

    private void RegisterPage(Page _page)
    {
        if(PageExists(_page.type))
        {
            LogWarning("You are trying to register a page ["+_page.type+"] that has already been registered: "+_page.gameObject.name);
            return;
        }

        _pages.Add(_page.type,_page);
        Log("Registered new page ["+_page.type+"].");
    }

    private Page GetPage(PageType _type)
    {
        if(!PageExists(_type))
        {
            LogWarning("You are trying to get a page ["+_type+"] that has not been registerd.");
            return null;
        }

        return (Page)_pages[_type];
    }

    private bool PageExists(PageType _type)
    {
        return _pages.ContainsKey(_type);
    }

    private void Log( string _msg)
    {
        if(!debugEnabled)
            return;
        Debug.Log("[Page Controller]:"+_msg);
    }

    private void LogWarning(string _msg)
    {
        if(!debugEnabled)
            return;
        Debug.LogWarning("[Page Controller]:"+_msg);
    }
#endregion

}
