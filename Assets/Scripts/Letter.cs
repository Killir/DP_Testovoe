using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{

    char letter;
    Text text;
    bool isOpened;

    private void OnEnable()
    {
        if (!text)
            text = GetComponentInChildren<Text>();
    }

    public void InitLetter(char letter)
    {
        this.letter = letter;
        text.text = "";
        isOpened = false;
    }

    public char GetLetter()
    {
        return letter;
    }

    public void OpenLetter()
    {
        text.text = letter.ToString();
        isOpened = true;
    }

    public bool IsOpened()
    {
        return isOpened;
    }

}
