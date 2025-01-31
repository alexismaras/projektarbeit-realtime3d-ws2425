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

    [SerializeField] GameObject finStandard1;
    [SerializeField] GameObject finSwallow1;

    [SerializeField] GameObject finStandard2;
    [SerializeField] GameObject finSwallow2;

    [SerializeField] GameObject finStandard3;
    [SerializeField] GameObject finSwallow3;

    MeshRenderer meshRendererSurfBoard01;
    MeshRenderer meshRendererSurfBoard02;
    MeshRenderer meshRendererSurfBoard03;

    MeshRenderer meshRendererSurfBoard11;
    MeshRenderer meshRendererSurfBoard12;
    MeshRenderer meshRendererSurfBoard13;

    MeshRenderer meshRendererSurfBoard21;
    MeshRenderer meshRendererSurfBoard22;
    MeshRenderer meshRendererSurfBoard23;

    MeshRenderer meshRendererFinStandard1;
    MeshRenderer meshRendererFinSwallow1;

    MeshRenderer meshRendererFinStandard2;
    MeshRenderer meshRendererFinSwallow2;

    MeshRenderer meshRendererFinStandard3;
    MeshRenderer meshRendererFinSwallow3;

    [SerializeField] Material greenMaterial;
    [SerializeField] Material blueMaterial;
    [SerializeField] Material redMaterial;




    public int chosenNose = 0;
    public int chosenTail = 1;

    public int chosenFin = 1;
    // Start is called before the first frame update
    void Start()
    {
        // for (var nose = 0; nose < 2; nose++)
        // {
        //     for (var tail = 1; tail < 4; tail++)
        //     {
        //         string boardMeshRendererFieldName = $"meshRendererSurfBoard{nose}{tail}";
        //         string surfBoardFieldName = $"surfBoard{nose}{tail}";

        //         FieldInfo boardMeshRendererField = GetType().GetField(boardMeshRendererFieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        //         FieldInfo surfBoardField = GetType().GetField(surfBoardFieldName, BindingFlags.NonPublic | BindingFlags.Instance);

        //         GameObject surfBoard = (GameObject)surfBoardField.GetValue(this);
        //         MeshRenderer renderer = surfBoard.GetComponent<MeshRenderer>();
        //         boardMeshRendererField.SetValue(this, renderer); 
        //     }
        // }

        // for (var fin = 1; fin < 3; fin++)
        // {
        //     string finMeshRendererFieldName = $"meshRendererFinStandard{fin}";
        //     string finFieldName = $"finStandard{fin}";

        //     FieldInfo finMeshRendererField = GetType().GetField(finMeshRendererFieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        //     FieldInfo finField = GetType().GetField(finFieldName, BindingFlags.NonPublic | BindingFlags.Instance);

        //     GameObject finStandard = (GameObject)finField.GetValue(this);
        //     MeshRenderer rendererStandard = finStandard.GetComponentInChildren<MeshRenderer>();
        //     finMeshRendererField.SetValue(this, rendererStandard); 

        //     string finSwallowMeshRendererFieldName = $"meshRendererFinSwallow{fin}";
        //     string finSwallowFieldName = $"finSwallow{fin}";

        //     FieldInfo finSwallowMeshRendererField = GetType().GetField(finSwallowMeshRendererFieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        //     FieldInfo finSwallowField = GetType().GetField(finSwallowFieldName, BindingFlags.NonPublic | BindingFlags.Instance);

        //     GameObject finSwallow = (GameObject)finSwallowField.GetValue(this);
        //     MeshRenderer rendererSwallow = finSwallow.GetComponentInChildren<MeshRenderer>();
        //     finSwallowMeshRendererField.SetValue(this, rendererSwallow); 
        // }

        meshRendererSurfBoard01 = surfBoard01.GetComponent<MeshRenderer>();
        meshRendererSurfBoard02 = surfBoard02.GetComponent<MeshRenderer>();
        meshRendererSurfBoard03 = surfBoard03.GetComponent<MeshRenderer>();

        meshRendererSurfBoard11 = surfBoard11.GetComponent<MeshRenderer>();
        meshRendererSurfBoard12 = surfBoard12.GetComponent<MeshRenderer>();
        meshRendererSurfBoard13 = surfBoard13.GetComponent<MeshRenderer>();

        meshRendererSurfBoard21 = surfBoard21.GetComponent<MeshRenderer>();
        meshRendererSurfBoard22 = surfBoard22.GetComponent<MeshRenderer>();
        meshRendererSurfBoard23 = surfBoard23.GetComponent<MeshRenderer>();

        meshRendererFinStandard1 = finStandard1.GetComponent<MeshRenderer>();
        meshRendererFinSwallow1 = finSwallow1.GetComponent<MeshRenderer>();

        meshRendererFinStandard2 = finStandard2.GetComponent<MeshRenderer>();
        meshRendererFinSwallow2 = finSwallow2.GetComponent<MeshRenderer>();

        meshRendererFinStandard3 = finStandard3.GetComponent<MeshRenderer>();
        meshRendererFinSwallow3 = finSwallow3.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (chosenNose < 2)
                chosenNose += 1;
            else
            {
                chosenNose = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (chosenTail < 3)
                chosenTail += 1;
            else
            {
                chosenTail = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (chosenFin < 3)
                chosenFin += 1;
            else
            {
                chosenFin = 1;
            }
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
        for (var nose = 0; nose < 3; nose++)
        {
            for (var tail = 1; tail < 4; tail++)
            {
                MeshRenderer boardMeshRenderer = GetVariableContaining($"meshRendererSurfBoard{nose}{tail}");
                if (nose == chosenNose && tail == chosenTail)
                {
                    boardMeshRenderer.enabled = true;
                }
                else
                {
                    boardMeshRenderer.enabled = false;
                }

                for (var fin = 1; fin < 4; fin++)
                {
                    MeshRenderer finStandardMeshRenderer = GetVariableContaining($"meshRendererFinStandard{fin}");
                    MeshRenderer finSwallowMeshRenderer = GetVariableContaining($"meshRendererFinSwallow{fin}");
                    if (fin == chosenFin)
                    {
                        if (chosenTail != 3)
                        {
                            finStandardMeshRenderer.enabled = true;
                            finSwallowMeshRenderer.enabled = false;
                        }
                        else
                        {
                            finStandardMeshRenderer.enabled = false;
                            finSwallowMeshRenderer.enabled = true;
                        }
                    }
                    else
                    {
                        finStandardMeshRenderer.enabled = false;
                        finSwallowMeshRenderer.enabled = false;
                    }
                }
            }
        }
    }

    void AllMaterialSet(Material boardMaterial)
    {
        for (var nose = 0; nose < 3; nose++)
        {
            for (var tail = 1; tail < 4; tail++)
            {
                MaterialGetSet(GetVariableContaining($"meshRendererSurfBoard{nose}{tail}"), boardMaterial);
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
