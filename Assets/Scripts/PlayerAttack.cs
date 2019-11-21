using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrow;

    /* 
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
    */

    public float arrowSpeed = 10.0f;
    public float arrowDamageBase = 0.0f;

    private float currentChargeValue;
    private bool isCharging;

    private Vector3 mousePos;


    void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            isCharging = true;
        } else if (Input.GetKey(KeyCode.Mouse0)) {
            currentChargeValue += Time.deltaTime;
            currentChargeValue = Mathf.Clamp(currentChargeValue, 0.0f, 2.0f);
        } else if (Input.GetKeyUp(KeyCode.Mouse0)) {
            isCharging = false;
            ShootArrow();
            currentChargeValue = 0;
        }
    }

    private void ShootArrow() {
        Vector3 direction;

        direction = mousePos - transform.position;
        direction.z = 0;

        GameObject iArrow;
        iArrow = Instantiate(arrow, transform.position, Quaternion.identity);
        iArrow.GetComponent<Arrow>().InitArrow(direction, 5.0f + currentChargeValue * 10.0f, arrowDamageBase + currentChargeValue, 3.0f);

    }

}
