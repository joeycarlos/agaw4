using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector3 moveVector;

    // Update is called once per frame
    void Update() {
        transform.Translate(moveVector * Time.deltaTime);
    }

    public void InitArrow(Vector3 newVector, float projectileSpeed) {
        // calculate the movement vector of fire projectile per update frame
        moveVector = newVector;
        moveVector.z = 0;
        moveVector = Vector3.Normalize(newVector);
        moveVector *= projectileSpeed;
    }
}
