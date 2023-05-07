using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Components
    private VehicleMovement _vehicle;
    
    // Local Variables
    private Vector3 targetPosition = Vector3.zero;
    private Transform targetTransform = null;

    private void Awake()
    {
        _vehicle = GetComponent<VehicleMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = Vector2.zero;

        FollowPlayer();

        inputVector.x = TurnTowardsTarget();
        inputVector.y = 1.0f;
        //inputVector.y = ApplyThrottleOrBrake(inputVector.x);
        
        _vehicle.SetInputVector(inputVector);
    }

    private void FollowPlayer()
    {
        if (targetTransform == null)
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (targetTransform != null)
        {
            targetPosition = targetTransform.position;
        }
    }

    float TurnTowardsTarget()
    {
        Vector2 vectorToTarget = targetPosition - transform.position;
        vectorToTarget.Normalize();

        float angleToTarget = Vector2.SignedAngle(transform.up, vectorToTarget);
        angleToTarget *= -1;

        float steerAmount = angleToTarget / 45.0f;

        steerAmount = Mathf.Clamp(steerAmount, -1.0f, 1.0f);

        return steerAmount;
    }

    float ApplyThrottleOrBrake(float inputX)
    {
        // Apply throttle forward based upon how much the car wants to turn. If it's a sharp turn, this will cause the car to apply less speed forward.
        return 1.05f - Mathf.Abs(inputX) / 1.0f;
    }
}
