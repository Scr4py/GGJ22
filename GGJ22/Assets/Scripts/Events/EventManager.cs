using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void SceneSwitch();
    public static event SceneSwitch sceneSwitch;

    public delegate void UseButton();
    public static event UseButton useButton;


    public static void F_SwitchEvent()
    {
        sceneSwitch();
    }

    public static void F_UseButton()
    {
        useButton();
    }
}
