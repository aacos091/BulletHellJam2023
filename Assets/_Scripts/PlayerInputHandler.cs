using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    // Components
    private PlayerVehicleMovement _vehicle;

    public TimeManager timeManager;

    private void Awake()
    {
        _vehicle = GetComponent<PlayerVehicleMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        
        _vehicle.SetInputVector(inputVector);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            timeManager.SlowMotion();
        }
    }
}
