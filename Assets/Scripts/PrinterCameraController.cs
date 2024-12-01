using UnityEngine;

public class PrinterCameraController : MonoBehaviour
{

    [SerializeField] private float sensitivity;
    [SerializeField] private float maxY;
    [SerializeField] private GameObject printer;
    [SerializeField] private Vector2 currentRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRotation.x = 0; currentRotation.y = 0;
        printer.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire2") >= .9)
        {
            currentRotation.y += Input.GetAxisRaw("Mouse X") * -sensitivity;
            currentRotation.x += Input.GetAxisRaw("Mouse Y") * -sensitivity;
            if (currentRotation.x > maxY)
                currentRotation.x = maxY;
            else if (currentRotation.x < -maxY)
                currentRotation.x = -maxY;

            printer.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
        }
    }
}
