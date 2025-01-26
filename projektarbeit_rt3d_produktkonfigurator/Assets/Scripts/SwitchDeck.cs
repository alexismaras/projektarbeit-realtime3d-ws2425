using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDeck : MonoBehaviour
{
    [SerializeField] GameObject surfBoard21;
    [SerializeField] GameObject surfBoard22;
    [SerializeField] GameObject surfBoard23;

    MeshRenderer meshRendererSurfBoard21;
    MeshRenderer meshRendererSurfBoard22;
    MeshRenderer meshRendererSurfBoard23;

    int chosenBoard = 1;
    // Start is called before the first frame update
    void Start()
    {
        meshRendererSurfBoard21 = surfBoard21.GetComponent<MeshRenderer>();
        meshRendererSurfBoard22 = surfBoard22.GetComponent<MeshRenderer>();
        meshRendererSurfBoard23 = surfBoard23.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            chosenBoard = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            chosenBoard = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            chosenBoard = 3;
        }

        if (chosenBoard == 1)
        {
            meshRendererSurfBoard21.enabled = true;
            meshRendererSurfBoard22.enabled = false;
            meshRendererSurfBoard23.enabled = false;
        }
        else if (chosenBoard == 2)
        {
            meshRendererSurfBoard21.enabled = false;
            meshRendererSurfBoard22.enabled = true;
            meshRendererSurfBoard23.enabled = false;
        }
        else if (chosenBoard == 3)
        {
            meshRendererSurfBoard21.enabled = false;
            meshRendererSurfBoard22.enabled = false;
            meshRendererSurfBoard23.enabled = true;
        }
        
    }
}
