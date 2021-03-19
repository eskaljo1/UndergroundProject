using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
class BuildSettings
{
    static BuildSettings()
    {
        //WebGL
        PlayerSettings.WebGL.memorySize = 1024;
    }
}