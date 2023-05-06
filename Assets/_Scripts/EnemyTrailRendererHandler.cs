using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrailRendererHandler : MonoBehaviour
{
    // Components
    private VehicleMovement _vehicle;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        // Get the player vehicle controller
        _vehicle = GetComponentInParent<VehicleMovement>();
        
        // Get the trail renderer component
        _trailRenderer = GetComponent<TrailRenderer>();
        
        // Set the trail renderer to not emit in the start
        _trailRenderer.emitting = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the car tires are screeching, then we'll emit a trail
        if (_vehicle.IsTireScreeching(out float lateralVelocity, out bool isBraking))
            _trailRenderer.emitting = true;
        else _trailRenderer.emitting = false;
    }
}
