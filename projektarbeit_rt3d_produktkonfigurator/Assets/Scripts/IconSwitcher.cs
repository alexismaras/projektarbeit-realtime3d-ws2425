using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class IconSwitcher : MonoBehaviour
{
    [SerializeField] SwitchDeck switchDeck;

    [SerializeField] Image iconImage;

    [SerializeField] Sprite icon01;
    [SerializeField] Sprite icon02;
    [SerializeField] Sprite icon03;

    [SerializeField] Sprite icon11;
    [SerializeField] Sprite icon12;
    [SerializeField] Sprite icon13;

    [SerializeField] Sprite icon21;
    [SerializeField] Sprite icon22;
    [SerializeField] Sprite icon23;

    [SerializeField] Sprite fin1;
    [SerializeField] Sprite fin2;
    [SerializeField] Sprite fin3;

    int currentChosenNose;
    int currentChosenTail;

    int currentChosenFin;
    // Start is called before the first frame update
    void Start()
    {
        currentChosenNose = switchDeck.chosenNose;
        currentChosenTail = switchDeck.chosenTail;
        currentChosenFin = switchDeck.chosenFin;

        iconImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "BoardIcon")
        {
            if (switchDeck.chosenNose != currentChosenNose || switchDeck.chosenTail != currentChosenTail)
            {
                iconImage.sprite = GetSpriteContaining($"icon{switchDeck.chosenNose}{switchDeck.chosenTail}");
                currentChosenNose = switchDeck.chosenNose;
                currentChosenTail = switchDeck.chosenTail;
            }
        }
        else if (tag == "FinIcon")
        {
            if (switchDeck.chosenFin != currentChosenFin)
            {
                iconImage.sprite = GetSpriteContaining($"fin{switchDeck.chosenFin}");
                currentChosenFin = switchDeck.chosenFin;
            }
        }
    }

    Sprite GetSpriteContaining(string searchString)
    {

        FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {

            if (field.Name.Contains(searchString))
            {
                return field.GetValue(this) as Sprite;
            }
        }

        return null;
    }
}
