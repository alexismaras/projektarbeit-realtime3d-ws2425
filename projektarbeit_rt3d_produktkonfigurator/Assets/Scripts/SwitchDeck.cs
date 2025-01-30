using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SwitchDeck : MonoBehaviour
{
    [SerializeField] GameObject surfBoard01;
    [SerializeField] GameObject surfBoard02;
    [SerializeField] GameObject surfBoard03;
    
    [SerializeField] GameObject surfBoard11;
    [SerializeField] GameObject surfBoard12;
    [SerializeField] GameObject surfBoard13;

    [SerializeField] GameObject surfBoard21;
    [SerializeField] GameObject surfBoard22;
    [SerializeField] GameObject surfBoard23;

    MeshRenderer meshRendererSurfBoard01;
    MeshRenderer meshRendererSurfBoard02;
    MeshRenderer meshRendererSurfBoard03;

    MeshRenderer meshRendererSurfBoard11;
    MeshRenderer meshRendererSurfBoard12;
    MeshRenderer meshRendererSurfBoard13;

    MeshRenderer meshRendererSurfBoard21;
    MeshRenderer meshRendererSurfBoard22;
    MeshRenderer meshRendererSurfBoard23;

    [SerializeField] Material greenMaterial;
    [SerializeField] Material blueMaterial;
    [SerializeField] Material redMaterial;




    int chosenNose= 0;
    int chosenTail= 1;
    // Start is called before the first frame update
    void Start()
    {
        meshRendererSurfBoard01 = surfBoard01.GetComponent<MeshRenderer>();
        meshRendererSurfBoard02 = surfBoard02.GetComponent<MeshRenderer>();
        meshRendererSurfBoard03 = surfBoard03.GetComponent<MeshRenderer>();

        meshRendererSurfBoard11 = surfBoard11.GetComponent<MeshRenderer>();
        meshRendererSurfBoard12 = surfBoard12.GetComponent<MeshRenderer>();
        meshRendererSurfBoard13 = surfBoard13.GetComponent<MeshRenderer>();

        meshRendererSurfBoard21 = surfBoard21.GetComponent<MeshRenderer>();
        meshRendererSurfBoard22 = surfBoard22.GetComponent<MeshRenderer>();
        meshRendererSurfBoard23 = surfBoard23.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            chosenNose = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            chosenNose = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            chosenNose = 2;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            chosenTail = 1;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            chosenTail = 2;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            chosenTail = 3;
        }

        ChooseBoard();


        if (Input.GetKeyDown(KeyCode.A))
        {
            AllMaterialSet(redMaterial);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            AllMaterialSet(blueMaterial);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            AllMaterialSet(greenMaterial);
        }

        
        
    }

    void ChooseBoard()
    {
        for (var n = 0; n < 3; n++)
        {
            for (var t = 1; t < 4; t++)
            {
                MeshRenderer boardMeshRenderer =  GetVariableContaining($"meshRendererSurfBoard{n}{t}");
                if (n == chosenNose && t == chosenTail)
                {
                    boardMeshRenderer.enabled = true;
                }
                else
                {
                    boardMeshRenderer.enabled = false;
                }
            }
        }
    }

    void AllMaterialSet(Material boardMaterial)
    {
        for (var n = 0; n < 3; n++)
        {
            for (var t = 1; t < 4; t++)
            {
                MaterialGetSet(GetVariableContaining($"meshRendererSurfBoard{n}{t}"), boardMaterial);
            }
        }
    }

    void MaterialGetSet(MeshRenderer boardMeshRenderer, Material boardMaterial)
    {
        Material[] faceMaterials = boardMeshRenderer.materials;
        faceMaterials[0]= boardMaterial;
        boardMeshRenderer.materials = faceMaterials;
    }

    MeshRenderer GetVariableContaining(string searchString)
    {
        // Get all fields in this class
        FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            // Check if the field name contains the search string
            if (field.Name.Contains(searchString))
            {
                return field.GetValue(this) as MeshRenderer;
            }
        }

        return null; // Return null if no match is found
    }
}
