using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerVehicleMovement : MonoBehaviour
{
    [Header("Car Settings")] 
    public float accelerationFactor = 30f;
    public float steeringFactor = 3.5f;
    public float driftingFactor = 0.95f;
    public float maxSpeed = 20;
    
    // Local Variables
    private float _accelerationInput = 0;
    private float _steeringInput = 0;

    private float _rotationAngle = 0;

    private float _velocityVsUp = 0;
    
    // Components
    private Rigidbody2D _carRb2D;

    private void Awake()
    {
        _carRb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Acceleration();
        
        KillOrthogonalVelocity();
        
        Steering();
    }

    void Acceleration()
    {
        // Calculate how much "forward" we are going in terms of the direction of our velocity
        _velocityVsUp = Vector2.Dot(transform.up, _carRb2D.velocity);
        
        // Limit so we cannot go faster than the maxSpeed in the "forward" direction
        if (_velocityVsUp > maxSpeed && _accelerationInput > 0)
            return;
        
        // Limit so we cannot go faster than 50% of the maxSpeed in the "reverse" direction
        if (_velocityVsUp < -maxSpeed * 0.5f && _accelerationInput < 0)
            return;
        
        // Limit so we cannot go faster in any direction while accelerating
        if (_carRb2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && _accelerationInput > 0)
            return;
        
        // Apply drag if there is no accelerationInput so the car stops when the player lets go of the accelerator
        if (_accelerationInput == 0)
            _carRb2D.drag = Mathf.Lerp(_carRb2D.drag, 3.0f, Time.fixedDeltaTime * 3);
        else _carRb2D.drag = 0;
        
        // Create a force for the engine
        Vector2 engineForceVector = transform.up * (_accelerationInput * accelerationFactor);
        
        // Apply force and pushes the car forward (or backward)
        _carRb2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void Steering()
    {
        // Limit the cars ability to turn when moving slowly
        float minSpeedBeforeAllowTurningFactor = (_carRb2D.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);
        
        // Update the rotation angle based on input
        _rotationAngle -= _steeringInput * steeringFactor * minSpeedBeforeAllowTurningFactor;
        
        // Apply steering by rotating the car object
        _carRb2D.MoveRotation(_rotationAngle);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(_carRb2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(_carRb2D.velocity, transform.right);

        _carRb2D.velocity = forwardVelocity + rightVelocity * driftingFactor;
    }

    float GetLateralVelocity()
    {
        // Returns how fast the car is moving sideways
        return Vector2.Dot(transform.right, _carRb2D.velocity);
    }

    public bool IsTireScreeching(out float lateralVelocity, out bool isBraking)
    {
        lateralVelocity = GetLateralVelocity();
        isBraking = false;
        
        // Check if we are moving forward and if the player is hitting the brakes. In that case the tires should screech.
        if (_accelerationInput < 0 && _velocityVsUp > 0)
        {
            isBraking = true;
            return true;
        }
        
        // If we have a lot of side movement then the tires should be screeching
        if (Mathf.Abs(GetLateralVelocity()) > 4.0f)
        {
            return true;
        }

        return false;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        _accelerationInput = inputVector.y;
        _steeringInput = inputVector.x;
    }

    public float GetVelocityMagnitude()
    {
        return _carRb2D.velocity.magnitude;
    }
}
