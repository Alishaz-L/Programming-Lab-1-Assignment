using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Inputs
{
    private static Control _Control;
    public static void Init(Players Cube)
    { 
        //Creates Controller
        _Control = new Control();
        //Detects when button is pressed and how much the object moves
        _Control.Game.Movement.performed += ctx =>
        {

            Cube.SetMoveDirection(ctx.ReadValue<Vector3>());
        };

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
