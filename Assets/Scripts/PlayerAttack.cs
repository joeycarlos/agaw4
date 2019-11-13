using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrow;

    public float fireRate = 1.0f;
    public float arrowSpeed = 10.0f;

    private Vector3 mousePos;
    private float timeSinceFire;

    void Update() {
        timeSinceFire -= Time.deltaTime;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey("mouse 0")) {
            if (timeSinceFire <= 0)
                ShootArrow();
        }
    }

    private void ShootArrow() {
        Vector3 direction;

        direction = mousePos - transform.position;
        direction.z = 0;

        GameObject iArrow;
        iArrow = Instantiate(arrow, transform.position, Quaternion.identity);
        iArrow.GetComponent<Arrow>().InitArrow(direction, arrowSpeed);

        timeSinceFire = fireRate;
    }


}
