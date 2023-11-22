using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public static class Inputs
{
    private static Control _Control;
    public static void Init(Players Cube)
    { 
        

        //Creates Controller
        _Control = new Control();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Detects when button is pressed and how much the object moves
        _Control.Game.Movement.performed += ctx =>
        {

            Cube.SetMovementDirection(ctx.ReadValue<Vector3>());
        };


        _Control.Game.Look.performed += ctx =>
        {
            Cube.SetLookRotation(ctx.ReadValue<Vector2>());
        };

        _Control.Game.Shoot.performed += ctx =>
        {
            Cube.shoot();
        };

        _Control.Game.Reload.performed += ctx =>
        {
            Cube.Reload();
        };

        _Control.Permanent.Enable();
    }

    //While playing the game
    public static void GameMode()
    {
        _Control.Game.Enable();
        _Control.UI.Disable();
    }

    //While in the options menu
    public static void UIMode()
    {
        _Control.Game.Disable();
        _Control.UI.Enable();
    }


}
