using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBlockConditionCheck : MonoBehaviour
{
    public Transform collidedObject;

    public bool collided = false;

    public float distance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidedObject = collision.transform;
        collided = true;

        distance = transform.position.x - collidedObject.position.x;
        
    }
}
