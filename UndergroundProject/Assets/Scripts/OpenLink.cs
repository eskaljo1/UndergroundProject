using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class OpenLink : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenNewTab(string url);

    public void openIt(string url)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             OpenNewTab(url);
#else 
        Application.OpenURL(url);
#endif
    }

    public string linkUrl;

    public void Open()
    {
        openIt("http://www." + linkUrl);
    }
}
