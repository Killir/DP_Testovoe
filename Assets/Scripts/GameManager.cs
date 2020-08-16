using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float nextWordTime = 1.5f;
    public Letter[] letters;

    Queue<string> words;    
    LetterButton[] letterButtons;
    int startTryCount;
    int minWordLenght;
    int tryCount;
    int score;

    void Awake()
    {
        instance = this;
    }

    void Init()
    {
        words = FileReader.GetWords(minWordLenght);
        SetScore(0);
    }

    void SetNextWord()
    {
        string word = null;
        if (words.Count > 0) {
            word = words.Dequeue();
        } else { 
            Win();
            return;
        }

        Debug.Log(word);

        UIManager.instance.SwitchOnWordOpenPanel(false);
        foreach (Letter l in letters) {
            l.gameObject.SetActive(false);
        }

        SetButtonsInteractable(true);
        for (int i = 0; i < word.Length; i++) {
            letters[i].gameObject.SetActive(true);
            letters[i].InitLetter(word[i]);
        }

        SetTryCount(startTryCount);
    }

    void Win()
    {
        SetButtonsInteractable(false);
        UIManager.instance.ShowWinScreen();
    }

    void GameOver()
    {
        SetButtonsInteractable(false);
        UIManager.instance.ShowGameOverScreen();
    }

    public void StartGame(int minWordLenght, int startTryCount)
    {
        letterButtons = FindObjectsOfType<LetterButton>();
        this.startTryCount = startTryCount;
        this.minWordLenght = minWordLenght;

        Init();
        SetNextWord();
    }

    public void Restart()
    {
        Init();
        SetNextWord();
    }

    void OnWordOpen()
    {
        SetScore(score + tryCount);
        UIManager.instance.SwitchOnWordOpenPanel(true);
        Invoke("SetNextWord", nextWordTime);
    }

    public void CheckLetter(char letter)
    {
        bool isLetterFount = false;
        bool isWordOpened = true;
        foreach(Letter l in letters) {
            if (l.isActiveAndEnabled) {
                if (letter == l.GetLetter()) {
                    l.OpenLetter();
                    isLetterFount = true;
                }
                isWordOpened &= l.IsOpened();
            } else {
                break;
            }
        }

        if (isWordOpened) {
            OnWordOpen();
        }

        if (!isLetterFount) {
            SetTryCount(tryCount - 1);
        }

        if (tryCount == 0) {
            GameOver();
        }

    }

    void SetButtonsInteractable(bool value)
    {
        foreach (LetterButton lb in letterButtons) {
            lb.SetIteractable(value);
        }
    }

    void SetScore(int value)
    {
        score = value;
        UIManager.instance.UpdateScoreText(score);
    }

    void SetTryCount(int value)
    {
        tryCount = value;
        UIManager.instance.UpdateTryCountText(tryCount);
    }

}
