using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smooth;
    GameObject character;

    [SerializeField] private float sensitivity = 5f;
    [SerializeField] private float smoothing = 2f;

    private float maxRot = 60f;
    private float minRot = -60f;
    private bool cursorLocked;

    private void Start()
    {
        character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;
    }

    private void Update()
    {
        MouseLook();
        //LimitRotation();
        CursorState();
    }
    private void CursorState()
    {
        if (Input.GetButtonDown("CursorState") && cursorLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            cursorLocked = false;
        }
        else if (Input.GetButtonDown("CursorState") && !cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            cursorLocked = true;
        }
    }

    private void MouseLook()
    {
        var mouseOrientation = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        mouseOrientation = Vector2.Scale(mouseOrientation, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smooth.x = Mathf.Lerp(smooth.x, mouseOrientation.x, 1f / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, mouseOrientation.x, 1f / smoothing);
        mouseLook += smooth;
        mouseLook += mouseOrientation;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }

    private void LimitRotation()
    {
        if (mouseLook.y > maxRot) { mouseLook.y = maxRot; }
        else if (mouseLook.y < minRot) { mouseLook.y = minRot; }
    }
}
