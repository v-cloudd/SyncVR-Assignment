using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Touch playerTouch;

    public float mouseSensitivity = 100f;
    public float touchSensitivityX = 3f;
    public float touchSensitivityY = 2f;

    public Transform player;

    float rotationX = 0f;

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 dragDistance = Vector2.zero;

        if (Input.touchCount > 0)
        {
            playerTouch = Input.GetTouch(0);
            dragDistance.x = playerTouch.deltaPosition.x * touchSensitivityX * Time.deltaTime;
            dragDistance.y = playerTouch.deltaPosition.y * touchSensitivityY * Time.deltaTime;
            Debug.Log(dragDistance);
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (dragDistance != Vector2.zero)
        {
            rotationX -= dragDistance.y;

            player.Rotate(Vector3.up * dragDistance.x);
        }
        if (mouseX != 0 || mouseY != 0)
        {
            rotationX -= mouseY;
            
            player.Rotate(Vector3.up * mouseX);
        }

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

    }
}
