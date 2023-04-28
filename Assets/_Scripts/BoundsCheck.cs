using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps a GameObject on screen.
/// This will only work with an orthographic Main Camera.
/// (Lifted from a tutorial, will put the link later)
/// </summary>

public class BoundsCheck : MonoBehaviour
{
    public enum eType
    {
        center,
        inset,
        outset
    }

    [Header("Inscribed")] 
    public eType boundsType = eType.center;
    public float radius = 1f;

    [Header("Dynamic")] 
    public float camWidth;
    public float camHeight;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        // Find the checkRadius that will enable center, inset, or outset
        float checkRadius = 0;
        if (boundsType == eType.inset) checkRadius = -radius;
        if (boundsType == eType.outset) checkRadius = radius;
        Vector2 pos = transform.position;
        
        // Restrict the X position to camWidth
        if (pos.x > camWidth + checkRadius)
        {
            pos.x = camWidth + checkRadius;
        }
        
        if (pos.x < -camWidth - checkRadius)
        {
            pos.x = -camWidth - checkRadius;
        }
        
        // Restrict the Y position to camHeight
        if (pos.y > camHeight + checkRadius)
        {
            pos.y = camHeight + checkRadius;
        }
        
        if (pos.y < -camHeight - checkRadius)
        {
            pos.y = -camHeight - checkRadius;
        }
        
        transform.position = pos;
    }
}
