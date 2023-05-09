using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 1f;
    public GameObject playerObject;

    // Update is called once per frame
    void Update()
    {
        Vector2 targetDirection = playerObject.transform.position - transform.position;

        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        //Vector2 newDirection = Vector3.RotateTowards(transform.up, targetDirection, singleStep, 0.0f);
        
        //transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, playerObject.transform.rotation, 0.0f);
    }
}
