using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButtonClick : MonoBehaviour
{
    [SerializeField] SwitchDeck switchDeck;

    public void ChangeNoseRight()
    {
        if (switchDeck.chosenNose < 2)
            switchDeck.chosenNose += 1;
        else
            switchDeck.chosenNose = 0;
    }

    public void ChangeNoseLeft()
    {
        if (switchDeck.chosenNose > 0)
            switchDeck.chosenNose -= 1;
        else
            switchDeck.chosenNose = 2;
    }

    public void ChangeTailRight()
    {
        if (switchDeck.chosenTail < 3)
            switchDeck.chosenTail += 1;
        else
            switchDeck.chosenTail = 1;
    }

    public void ChangeTailLeft()
    {
        if (switchDeck.chosenTail > 1)
            switchDeck.chosenTail -= 1;
        else
            switchDeck.chosenTail = 3;
    }

    public void ChangeFinRight()
    {
        if (switchDeck.chosenFin < 3)
            switchDeck.chosenFin += 1;
        else
            switchDeck.chosenFin = 1;
    }

    public void ChangeFinLeft()
    {
        if (switchDeck.chosenFin > 1)
            switchDeck.chosenFin -= 1;
        else
            switchDeck.chosenFin = 3;
    }

    public void ChangeColorDeck(int colorSwatch)
    {
        if (switchDeck.chosenDeckMaterial != colorSwatch)
            switchDeck.chosenDeckMaterial = colorSwatch;
    }

    public void ChangeColorOutline(int colorSwatch)
    {
        if (switchDeck.chosenOutlineMaterial != colorSwatch)
            switchDeck.chosenOutlineMaterial = colorSwatch;
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
