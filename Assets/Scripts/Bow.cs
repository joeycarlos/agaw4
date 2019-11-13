using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject player;

    private Transform parent;

    private Vector3 coordinates;
    private Camera cam;
    private float newAngle;

    void Start() {
        parent = transform.parent;
    }

    void Update() {
        UpdateTransform();
    }

    void OnGUI() {
            cam = Camera.main;
            coordinates = cam.ScreenToWorldPoint(Input.mousePosition);
            coordinates = coordinates - parent.transform.position;
            newAngle = convertCoordinatesToEuler(coordinates);
    }

    float convertCoordinatesToEuler(Vector3 ptCoordinates) {
        float angle = Mathf.Atan2(ptCoordinates.y, ptCoordinates.x);
        angle = angle * Mathf.Rad2Deg;

        if (angle < 0) {
            angle = 360 + angle;
        }

        return angle;
    }

    public void UpdateTransform() {
        if (parent == null) parent = transform.parent;
        parent.transform.position = player.transform.position;
        parent.transform.eulerAngles = new Vector3(0, 0, newAngle - 90);
    }
}
