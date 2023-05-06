using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleHandler : MonoBehaviour
{
    // Local variables
    private float _particleEmissionRate = 0;
    
    // Components
    private VehicleMovement _vehicle;

    private ParticleSystem _particleSystemSmoke;
    private ParticleSystem.EmissionModule _particleSystemEmissionModule;

    private void Awake()
    {
        // Get the car controller
        _vehicle = GetComponentInParent<VehicleMovement>();
        
        // Get the particle system
        _particleSystemSmoke = GetComponent<ParticleSystem>();
        
        // Get the emission component
        _particleSystemEmissionModule = _particleSystemSmoke.emission;
        
        // Set it to zero emission
        _particleSystemEmissionModule.rateOverTime = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce the particles over time
        _particleEmissionRate = Mathf.Lerp(_particleEmissionRate, 0, Time.deltaTime * 5);
        _particleSystemEmissionModule.rateOverTime = _particleEmissionRate;

        if (_vehicle.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            // If the car tires are screeching then we'll emit smoke. If the player is braking then emit a lot of smoke
            if (isBraking)
                _particleEmissionRate = 30;
            // If the player is drifting we'll emit smoke based on how much the player is drifting
            else _particleEmissionRate = Mathf.Abs(lateralVelocity) * 2;
        }
    }
}
