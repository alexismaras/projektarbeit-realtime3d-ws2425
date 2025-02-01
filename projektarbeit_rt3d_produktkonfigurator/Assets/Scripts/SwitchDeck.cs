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

    [SerializeField] Material outlineMaterial1;
    [SerializeField] Material outlineMaterial2;
    [SerializeField] Material outlineMaterial3;
    [SerializeField] Material outlineMaterial4;
    [SerializeField] Material outlineMaterial5;
    [SerializeField] Material outlineMaterial6;
    [SerializeField] Material outlineMaterial7;
    [SerializeField] Material outlineMaterial8;

    [SerializeField] Material deckMaterial1;
    [SerializeField] Material deckMaterial2;
    [SerializeField] Material deckMaterial3;
    [SerializeField] Material deckMaterial4;
    [SerializeField] Material deckMaterial5;
    [SerializeField] Material deckMaterial6;
    [SerializeField] Material deckMaterial7;
    [SerializeField] Material deckMaterial8;




    public int chosenNose = 0;
    public int chosenTail = 1;
    public int chosenFin = 1;
    public int chosenDeckMaterial = 1;
    public int chosenOutlineMaterial = 1;
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

        ChooseBoard();

        ChooseMaterial();


        if (Input.GetKeyDown(KeyCode.A))
        {
            if (chosenDeckMaterial < 8)
                chosenDeckMaterial += 1;
            else
            {
                chosenDeckMaterial = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (chosenOutlineMaterial < 8)
                chosenOutlineMaterial += 1;
            else
            {
                chosenOutlineMaterial = 1;
            }
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

    void ChooseMaterial()
    {
        Material deckMaterial = GetMaterialContaining($"deckMaterial{chosenDeckMaterial}");
        Material outlineMaterial = GetMaterialContaining($"outlineMaterial{chosenOutlineMaterial}");

        for (var nose = 0; nose < 3; nose++)
        {
            for (var tail = 1; tail < 4; tail++)
            {
                MaterialGetSet(GetVariableContaining($"meshRendererSurfBoard{nose}{tail}"), deckMaterial, outlineMaterial);
            }
        }
    }

    void MaterialGetSet(MeshRenderer boardMeshRenderer, Material deckMaterial, Material outlineMaterial)
    {
        Material[] faceMaterials = boardMeshRenderer.materials;
        faceMaterials[0]= outlineMaterial;
        faceMaterials[1]= deckMaterial;
        boardMeshRenderer.materials = faceMaterials;
    }

    MeshRenderer GetVariableContaining(string searchString)
    {

        FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {

            if (field.Name.Contains(searchString))
            {
                return field.GetValue(this) as MeshRenderer;
            }
        }

        return null;
    }

    Material GetMaterialContaining(string searchString)
    {

        FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {

            if (field.Name.Contains(searchString))
            {
                return field.GetValue(this) as Material;
            }
        }

        return null;
    }
}
