using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{

    public char letter;
    Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
    }

    public void OnButtonClick()
    {
        GameManager.instance.CheckLetter(letter);
        button.interactable = false;
    }

    public void SetIteractable()
    {
        button.interactable = true;
    }

}
