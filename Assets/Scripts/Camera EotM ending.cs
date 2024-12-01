using UnityEngine;

public class CameraEotMending : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float maxRotation = 10f;
    private float currentRotation = 0f;

    void Update()
    {
        if (currentRotation < maxRotation)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationStep, 0);
            currentRotation += rotationStep;
        }
    }
}
