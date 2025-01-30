using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeSubject : MonoBehaviour
{

    [SerializeField] CinemachineFreeLook finLookCamera;

    bool mouseOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseOverFunction();
        
    }

    void OnMouseOver()
	{
        mouseOver = true;
	}

    void OnMouseExit()
	{
        mouseOver = false;
	}

    void MouseOverFunction()
    {
        if (mouseOver && Input.GetMouseButtonDown(0))
        {
            finLookCamera.m_Priority = 20;
        }
        else if (!mouseOver && Input.GetMouseButtonDown(0))
        {
            finLookCamera.m_Priority = 0;
        }
    }

}
