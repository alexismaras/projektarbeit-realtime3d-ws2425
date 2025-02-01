using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems; 

public class ChangeSubject : MonoBehaviour
{

    [SerializeField] CinemachineFreeLook finLookCamera;

    [SerializeField] GameObject finTargetVisual;

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
        if (mouseOver)
        {
            finTargetVisual.GetComponent<MeshRenderer>().enabled = true;
            if (!IsMouseOverUI() && Input.GetMouseButtonDown(0))
            {
                finLookCamera.m_Priority = 20;
            }
        }
        else if (!mouseOver)
        {
            finTargetVisual.GetComponent<MeshRenderer>().enabled = false;
            if (!mouseOver && !IsMouseOverUI() && Input.GetMouseButtonDown(0))
            {
                finLookCamera.m_Priority = 0;
            }
        }
    }

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

}
