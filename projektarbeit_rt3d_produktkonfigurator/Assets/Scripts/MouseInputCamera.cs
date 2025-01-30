using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseInputCamera : MonoBehaviour
{

    [SerializeField] CinemachineFreeLook mainLookCamera;
    [SerializeField] CinemachineFreeLook finLookCamera;
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
            mainLookCamera.m_XAxis.m_InputAxisName = mouseXAxisName;
            mainLookCamera.m_YAxis.m_InputAxisName = mouseYAxisName;

            finLookCamera.m_XAxis.m_InputAxisName = mouseXAxisName;
            finLookCamera.m_YAxis.m_InputAxisName = mouseYAxisName;
        }
        else
        {
            // Disable input when the mouse button is not pressed
            mainLookCamera.m_XAxis.m_InputAxisName = "";
            mainLookCamera.m_YAxis.m_InputAxisName = "";

            mainLookCamera.m_XAxis.m_InputAxisValue = 0f;
            mainLookCamera.m_YAxis.m_InputAxisValue = 0f;

            finLookCamera.m_XAxis.m_InputAxisName = "";
            finLookCamera.m_YAxis.m_InputAxisName = "";

            finLookCamera.m_XAxis.m_InputAxisValue = 0f;
            finLookCamera.m_YAxis.m_InputAxisValue = 0f;
        }
        
    }
}
