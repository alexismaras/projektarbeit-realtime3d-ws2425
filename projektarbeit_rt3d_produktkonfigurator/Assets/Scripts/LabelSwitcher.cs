using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LabelSwitcher : MonoBehaviour
{
    [SerializeField] SwitchDeck switchDeck;

    [SerializeField] TMP_Text finLabel;
    [SerializeField] TMP_Text noseLabel;
    [SerializeField] TMP_Text tailLabel;

    [SerializeField] string nose0 = "POINTED";
    [SerializeField] string nose1 = "POINTED ROUND";
    [SerializeField] string nose2 = "ROUND";

    [SerializeField] string tail1 = "SQUARE";
    [SerializeField] string tail2 = "ROUNDED";
    [SerializeField] string tail3 = "SWALLOW";

    [SerializeField] string fin1 = "RAKE";
    [SerializeField] string fin2 = "HATCHET";
    [SerializeField] string fin3 = "D-FIN";

    int currentChosenNose;
    int currentChosenTail;

    int currentChosenFin;
    // Start is called before the first frame update
    void Start()
    {
        noseLabel.text = GetStringContaining($"nose{switchDeck.chosenNose}");
        tailLabel.text = GetStringContaining($"tail{switchDeck.chosenTail}");
        finLabel.text = GetStringContaining($"fin{switchDeck.chosenFin}");
        currentChosenNose = switchDeck.chosenNose;
        currentChosenTail = switchDeck.chosenTail;
        currentChosenFin = switchDeck.chosenFin;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchDeck.chosenNose != currentChosenNose)
        {
            noseLabel.text = GetStringContaining($"nose{switchDeck.chosenNose}");
            currentChosenNose = switchDeck.chosenNose;
        }
        if (switchDeck.chosenTail != currentChosenTail)
        {
            tailLabel.text = GetStringContaining($"tail{switchDeck.chosenTail}");
            currentChosenTail = switchDeck.chosenTail;
        }
        if (switchDeck.chosenFin != currentChosenFin)
        {
            finLabel.text = GetStringContaining($"fin{switchDeck.chosenFin}");
            currentChosenFin = switchDeck.chosenFin;
        }
    }

    string GetStringContaining(string searchString)
    {

        FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {

            if (field.Name.Contains(searchString))
            {
                return field.GetValue(this) as string;
            }
        }

        return null;
    }
}
