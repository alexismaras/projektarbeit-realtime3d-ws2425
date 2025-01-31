using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems; 

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
        if (!IsMouseOverUI())
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
        else
        {
            Debug.Log("Typehsit");
        }
    }

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

}
