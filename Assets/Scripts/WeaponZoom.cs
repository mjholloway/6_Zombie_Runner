using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomFov = 30f;
    [SerializeField] float zoomSensitivity = 1f;

    float noZoomFov = 60f;
    float noZoomSensitivity = 2f;
    bool zoomed = false;
    Camera mainCamera;
    RigidbodyFirstPersonController fpsController;

    private void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (zoomed) { ZoomOut(); }
            else { ZoomIn(); }
        }
    }

    private void ZoomIn()
    {
        mainCamera.fieldOfView = zoomFov;
        fpsController.mouseLook.XSensitivity = zoomSensitivity;
        fpsController.mouseLook.YSensitivity = zoomSensitivity;
        zoomed = true;
    }

    private void ZoomOut()
    {
        mainCamera.fieldOfView = noZoomFov;
        fpsController.mouseLook.XSensitivity = noZoomSensitivity;
        fpsController.mouseLook.YSensitivity = noZoomSensitivity;
        zoomed = false;
    }

}
