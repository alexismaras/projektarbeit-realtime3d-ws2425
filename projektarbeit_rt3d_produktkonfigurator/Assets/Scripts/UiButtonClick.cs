using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButtonClick : MonoBehaviour
{
    [SerializeField] SwitchDeck switchDeck;

    [SerializeField] AudioSource uiClickSound;

    public void ChangeNoseRight()
    {
        PlayUiClickSound();
        if (switchDeck.chosenNose < 2)
            switchDeck.chosenNose += 1;
        else
            switchDeck.chosenNose = 0;
    }

    public void ChangeNoseLeft()
    {
        PlayUiClickSound();
        if (switchDeck.chosenNose > 0)
            switchDeck.chosenNose -= 1;
        else
            switchDeck.chosenNose = 2;
    }

    public void ChangeTailRight()
    {
        PlayUiClickSound();
        if (switchDeck.chosenTail < 3)
            switchDeck.chosenTail += 1;
        else
            switchDeck.chosenTail = 1;
    }

    public void ChangeTailLeft()
    {
        PlayUiClickSound();
        if (switchDeck.chosenTail > 1)
            switchDeck.chosenTail -= 1;
        else
            switchDeck.chosenTail = 3;
    }

    public void ChangeFinRight()
    {
        PlayUiClickSound();
        if (switchDeck.chosenFin < 3)
            switchDeck.chosenFin += 1;
        else
            switchDeck.chosenFin = 1;
    }

    public void ChangeFinLeft()
    {
        PlayUiClickSound();
        if (switchDeck.chosenFin > 1)
            switchDeck.chosenFin -= 1;
        else
            switchDeck.chosenFin = 3;
    }

    public void ChangeColorDeck(int colorSwatch)
    {
        PlayUiClickSound();
        if (switchDeck.chosenDeckMaterial != colorSwatch)
            switchDeck.chosenDeckMaterial = colorSwatch;
    }

    public void ChangeColorOutline(int colorSwatch)
    {
        PlayUiClickSound();
        if (switchDeck.chosenOutlineMaterial != colorSwatch)
            switchDeck.chosenOutlineMaterial = colorSwatch;
    }

    public void QuitGame()
    {
        PlayUiClickSound();
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void PlayUiClickSound()
    {
        uiClickSound.Play();
    }
}
