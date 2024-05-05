using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public GameObject menuScreen, gameScreen, gameOverScreen;

    public TextMeshProUGUI warriorHealthText, valkyrieHealthText, wizardHealthText, elfHealthText, warriorScoreText, valkyrieScoreText, wizardScoreText, elfScoreText, levelText;

    public PlayerData warrior;
    public PlayerData valkyrie;
    public PlayerData wizard;
    public PlayerData elf;

    private void OnEnable()
    {
        GameEventBus.Subscribe(GameState.mainMenu, EnableMenuUI);
        GameEventBus.Subscribe(GameState.startGame, EnablePlayingUI);
        GameEventBus.Subscribe(GameState.gameOver, EnableGameOverUI);
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameState.mainMenu, EnableMenuUI);
        GameEventBus.Unsubscribe(GameState.startGame, EnablePlayingUI);
        GameEventBus.Unsubscribe(GameState.gameOver, EnableGameOverUI);
    }

    private void Update()
    {
        if (warrior != null)
        {
            warriorHealthText.text = warrior.GetComponent<PlayerData>().playerHealth.ToString();
            warriorScoreText.text = warrior.GetComponent<PlayerData>().playerScore.ToString();
        }

        if (valkyrie != null)
        {
            valkyrieHealthText.text = valkyrie.playerHealth.ToString();
            valkyrieScoreText.text = valkyrie.playerScore.ToString();
        }

        if (wizard != null)
        {
            wizardHealthText.text = wizard.GetComponent<PlayerData>().playerHealth.ToString();
            wizardScoreText.text = wizard.GetComponent<PlayerData>().playerScore.ToString();
        }
    }

    /// <summary>
    /// enables the menu UI
    /// </summary>
    private void EnableMenuUI()
    {
        //disable the playing screen and game over screen, but enable the menu screen
        SetDisplayScreen(true, false, false);
    }

    /// <summary>
    /// enables the playing game screen
    /// </summary>
    private void EnablePlayingUI()
    {
        //disable the menu and game over screen, but enable the playing screen
        SetDisplayScreen(false, true, false);

        //disable the cursor
        Cursor.visible = false;
    }

    /// <summary>
    /// enable the game over screen
    /// </summary>
    private void EnableGameOverUI()
    {
        //enable the cursor 
        //disable the menu and playing screen, but enable the game over screen
        Cursor.visible = true;
        SetDisplayScreen(false, false, true);
    }

    /// <summary>
    /// enables and disables the correct screen at runtime
    /// </summary>
    /// <param name="menu"> sets the menu screen on or off </param>
    /// <param name="game"> sets the game screen on or off </param>
    /// <param name="over"> sets the game over screen on or off </param>
    private void SetDisplayScreen(bool menu, bool game, bool over)
    {
        menuScreen.SetActive(menu);
        gameScreen.SetActive(game);
        gameOverScreen.SetActive(over);
    }
}
