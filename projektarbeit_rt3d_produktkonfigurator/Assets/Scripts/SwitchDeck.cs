using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDeck : MonoBehaviour
{
    [SerializeField] GameObject surfBoard11;
    [SerializeField] GameObject surfBoard21;
    [SerializeField] GameObject surfBoard22;
    [SerializeField] GameObject surfBoard23;

    [SerializeField] Material greenMaterial;
    [SerializeField] Material blueMaterial;
    [SerializeField] Material redMaterial;
    Material[] faceMaterials;

    MeshRenderer meshRendererSurfBoard11;
    MeshRenderer meshRendererSurfBoard21;
    MeshRenderer meshRendererSurfBoard22;
    MeshRenderer meshRendererSurfBoard23;



    int chosenBoard = 1;
    // Start is called before the first frame update
    void Start()
    {
        meshRendererSurfBoard11 = surfBoard11.GetComponent<MeshRenderer>();
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
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            chosenBoard = 4;
        }

        if (chosenBoard == 1)
        {
            meshRendererSurfBoard11.enabled = true;
            meshRendererSurfBoard21.enabled = false;
            meshRendererSurfBoard22.enabled = false;
            meshRendererSurfBoard23.enabled = false;

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                faceMaterials = meshRendererSurfBoard11.materials;
                faceMaterials[0]= greenMaterial;
                meshRendererSurfBoard11.materials = faceMaterials;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                faceMaterials = meshRendererSurfBoard11.materials;
                faceMaterials[0]= blueMaterial;
                meshRendererSurfBoard11.materials = faceMaterials;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                faceMaterials = meshRendererSurfBoard11.materials;
                faceMaterials[0]= blueMaterial;
                meshRendererSurfBoard11.materials = faceMaterials;
            }

            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                faceMaterials = meshRendererSurfBoard11.materials;
                faceMaterials[1]= redMaterial;
                meshRendererSurfBoard11.materials = faceMaterials;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                faceMaterials = meshRendererSurfBoard11.materials;
                faceMaterials[1]= greenMaterial;
                meshRendererSurfBoard11.materials = faceMaterials;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                faceMaterials = meshRendererSurfBoard11.materials;
                faceMaterials[1]= blueMaterial;
                meshRendererSurfBoard11.materials = faceMaterials;
            }
        }
        else if (chosenBoard == 2)
        {
            meshRendererSurfBoard11.enabled = false;
            meshRendererSurfBoard21.enabled = true;
            meshRendererSurfBoard22.enabled = false;
            meshRendererSurfBoard23.enabled = false;
        }
        else if (chosenBoard == 3)
        {
            meshRendererSurfBoard11.enabled = false;
            meshRendererSurfBoard21.enabled = false;
            meshRendererSurfBoard22.enabled = true;
            meshRendererSurfBoard23.enabled = false;
        }
        else if (chosenBoard == 4)
        {
            meshRendererSurfBoard11.enabled = false;
            meshRendererSurfBoard21.enabled = false;
            meshRendererSurfBoard22.enabled = false;
            meshRendererSurfBoard23.enabled = true;
        }
        
    }
}
