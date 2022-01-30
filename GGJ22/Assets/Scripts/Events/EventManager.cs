using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum World { ArtWorld, ProggerWorld}


public static class EventManager
{
    public delegate void SceneSwitch();
    public static event SceneSwitch sceneSwitch;

    public delegate void UseButton();
    public static event UseButton useButton;

    public delegate void ChangeBackground(bool isArtist);
    public static event ChangeBackground changeBackground;

    public delegate void SwitchWorlds(World world);
    public static event SwitchWorlds switchWorlds;
    public static void F_SwitchEvent()
    {
        sceneSwitch();
    }

    public static void F_UseButton()
    {
        useButton();
    }

    public static void F_SwitchWorld(World world)
    {
        switchWorlds(world);
    }

    public static void F_SwitchBackground(bool isArtist)
    {
        changeBackground(isArtist);
    }
}
