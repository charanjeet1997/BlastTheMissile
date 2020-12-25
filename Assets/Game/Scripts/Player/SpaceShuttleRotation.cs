using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShuttleRotation : MonoBehaviour
{
    [SerializeField] Vector3 initPosition;
    [SerializeField] Vector3 dragPosition;
    public Camera mainCamera;
    public float rotationSpeed;
    Touch[] touches;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        PlayerRotation();
    }

    private void PlayerRotation()
    {
        if (Input.touchCount > 0)
        {
            touches = Input.touches;
            SetTouch(Array.Find(touches, x => x.position.x > Screen.width / 2.5f));
        }
        // if (Input.mousePosition.x > Screen.width / 2)
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         initPosition = ScreenToWorldPoint(Input.mousePosition);
        //     }
        //     if (Input.GetMouseButton(0))
        //     {
        //         dragPosition = ScreenToWorldPoint(Input.mousePosition);
        //         Vector3 initToDragDir = dragPosition - initPosition;
        //         float angle = Vector3.SignedAngle(initPosition, initToDragDir, Vector3.forward);
        //         transform.Rotate(0, 0, angle * rotationSpeed);
        //         initPosition = dragPosition;
        //     }
        // }
    }

    private void SetTouch(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            initPosition = ScreenToWorldPoint(touch.position);
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            dragPosition = ScreenToWorldPoint(touch.position);
            Vector3 initToDragDir = dragPosition - initPosition;
            float angle = Vector3.SignedAngle(initPosition, initToDragDir, Vector3.forward);
            transform.Rotate(0, 0, angle * rotationSpeed);
            initPosition = dragPosition;
        }
    }

    public Vector3 ScreenToWorldPoint(Vector3 screenPosition)
    {
        return mainCamera.ScreenToWorldPoint(screenPosition);
    }
}
