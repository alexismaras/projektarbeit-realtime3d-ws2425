using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwatchSwitcher : MonoBehaviour
{
    [SerializeField] SwitchDeck switchDeck;
    [SerializeField] Sprite activeSwatch;
    [SerializeField] Sprite inactiveSwatch;

    [SerializeField] int thisSwatch;

    int previousChosenDeckMaterial;
    int previousChosenOutlineMaterial;
    Button thisButton;
    Image thisButtonImage;

    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButtonImage = thisButton.GetComponent<Image>();
        previousChosenDeckMaterial = switchDeck.chosenDeckMaterial;
        previousChosenOutlineMaterial = switchDeck.chosenOutlineMaterial;

        if (tag == "DeckSwatch")
        {
            if (switchDeck.chosenDeckMaterial == thisSwatch)
            {
                thisButtonImage.sprite = activeSwatch;
            }
            else
            {
                thisButtonImage.sprite = inactiveSwatch;
            }
        }
        else if (tag== "OutlineSwatch")
        {
            if (switchDeck.chosenOutlineMaterial == thisSwatch)
            {
                thisButtonImage.sprite = activeSwatch;
            }
            else
            {
                thisButtonImage.sprite = inactiveSwatch;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (previousChosenDeckMaterial != switchDeck.chosenDeckMaterial || previousChosenOutlineMaterial != switchDeck.chosenOutlineMaterial)
        {
            if (tag == "DeckSwatch")
            {
                if (switchDeck.chosenDeckMaterial == thisSwatch)
                {
                    thisButtonImage.sprite = activeSwatch;
                }
                else
                {
                    thisButtonImage.sprite = inactiveSwatch;
                }
            }
            else if (tag== "OutlineSwatch")
            {
                if (switchDeck.chosenOutlineMaterial == thisSwatch)
                {
                    thisButtonImage.sprite = activeSwatch;
                }
                else
                {
                    thisButtonImage.sprite= inactiveSwatch;
                }
            }
        }
        previousChosenDeckMaterial = switchDeck.chosenDeckMaterial;
        previousChosenOutlineMaterial = switchDeck.chosenOutlineMaterial;
    }
}
