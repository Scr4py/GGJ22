using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void SceneSwitch();
    public static event SceneSwitch sceneSwitch;


    public static void F_SwitchEvent()
    {
        sceneSwitch();
    }
}
