using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{
    //Determines the speed you enter and what direction the user wants to move via 3D vector
    [SerializeField] private float speed;
    private Vector3 _moveDir;

    // Start is called before the first frame update
    void Start()
    {
        //Starting the game in GameMode
        Inputs.Init(this);
        Inputs.GameMode();

    }

    // Update is called once per frame
    void Update()
    {
        //Allows the Cube to move via how fast its moving
        transform.position += (speed * Time.deltaTime * _moveDir);

    }

    //Creating a Function to show the program where to go
    public void SetMoveDirection(Vector3 NewDirection)
    {
        _moveDir = NewDirection;
    }
}
