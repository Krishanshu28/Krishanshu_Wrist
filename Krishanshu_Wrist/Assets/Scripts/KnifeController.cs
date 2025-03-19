using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    private float minRotation = -45f; 
    private float maxRotation = 15f;  

    void Update()
    {
        HandleRotation();
    }

    void HandleRotation()
    {
        
        float input = Input.GetAxis("Vertical");

       
        float newRotation = transform.localEulerAngles.z - input * rotationSpeed * Time.deltaTime;

        
        if (newRotation > 180) 
            newRotation -= 360;

        newRotation = Mathf.Clamp(newRotation, minRotation, maxRotation);
        transform.localEulerAngles = new Vector3(0, 90f, newRotation);
    }
}
