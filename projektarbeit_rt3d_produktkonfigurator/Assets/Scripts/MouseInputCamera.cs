using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseInputCamera : MonoBehaviour
{

    [SerializeField] CinemachineFreeLook freeLookCamera;
    [SerializeField] string mouseXAxisName = "Mouse X";
    [SerializeField] string mouseYAxisName = "Mouse Y";
    [SerializeField] KeyCode activationKey = KeyCode.Mouse1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(activationKey))
        {
            freeLookCamera.m_XAxis.m_InputAxisName = mouseXAxisName;
            freeLookCamera.m_YAxis.m_InputAxisName = mouseYAxisName;
        }
        else
        {
            // Disable input when the mouse button is not pressed
            freeLookCamera.m_XAxis.m_InputAxisName = "";
            freeLookCamera.m_YAxis.m_InputAxisName = "";

            freeLookCamera.m_XAxis.m_InputAxisValue = 0f;
            freeLookCamera.m_YAxis.m_InputAxisValue = 0f;
        }
        
    }
}
