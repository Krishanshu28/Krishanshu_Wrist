using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knife : MonoBehaviour
{
    public float speed = 5.0f;
    bool isPressed = false;
    bool isPressedD = false;

    void FixedUpdate()
    {
        if(isPressed == true) 
        {
            print("yo1");
            if(transform.rotation.z >= -0.3706644)
            {
                transform.Rotate(0f, 0f, speed * Time.deltaTime);
            }
            
            
        }

        if (isPressedD == true)
        {
            if (transform.rotation.z <= -0.15)
                transform.Rotate(0f, 0f, -speed * Time.deltaTime);
        }
    }
    public void OnPressUp(bool _isPressed)
    {
        
        isPressed = _isPressed; 
    }
    public void OnPressDown(bool _isPressedD)
    {
        
        isPressedD = _isPressedD;
    }

}
