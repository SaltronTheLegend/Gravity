using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float sensitivity = 5f;

    private float currentX = 0f;
    private float currentY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        currentY = Mathf.Clamp(currentY, -90f, 90f);

        Vector3 direction = new Vector3(0f, 0f, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
        Vector3 position = rotation * direction + target.position + new Vector3(0f, height, 0f);

        transform.rotation = rotation;
        transform.position = position;
    }
}