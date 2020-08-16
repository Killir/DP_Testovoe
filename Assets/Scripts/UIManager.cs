using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public int defaultTryCount;
    public GameObject settingScreen;
    public GameObject mainScreen;
    public GameObject winScreen;
    public GameObject gameOverScreen;
    public GameObject onWordOpenPanel;

    public Text scoreText;
    public Text tryCountText;

    public Slider minWordLenghtSlider;
    public Text minWordLenghtText;
    public InputField tryCountInputField;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tryCountInputField.text = defaultTryCount.ToString();
    }

    public void StartGameButton()
    {
        settingScreen.SetActive(false);
        mainScreen.SetActive(true);

        int minWordLenght = Mathf.RoundToInt(minWordLenghtSlider.value);
        int startTryCount = int.Parse(tryCountInputField.text);
        GameManager.instance.StartGame(minWordLenght, startTryCount);
    }

    public void RestartButton()
    {
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        GameManager.instance.Restart();
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Очки: " + score.ToString();
    }

    public void UpdateTryCountText(int tryCount)
    {
        tryCountText.text = "Попыток: " + tryCount.ToString();
    }

    public void SwitchOnWordOpenPanel(bool value)
    {
        onWordOpenPanel.SetActive(value);
    }

    public void OnSliderValueChange()
    {
        minWordLenghtText.text = minWordLenghtSlider.value.ToString() + " б.";
    }

}
