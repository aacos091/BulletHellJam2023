using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    // Components
    private PlayerVehicleMovement playerVehicle;

    private void Awake()
    {
        playerVehicle = GetComponent<PlayerVehicleMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        
        playerVehicle.SetInputVector(inputVector);
    }
}
