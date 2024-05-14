using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/25/2024]
 * [Manages all UI that is displayed on screen]
 */
public class UIManager : Singleton<UIManager>
{
    //different UI screens
    public GameObject menuScreen, gameScreen, gameOverScreen, centerText;

    //Various text properties on screen
    public TextMeshProUGUI warriorHealthText, valkyrieHealthText, wizardHealthText, elfHealthText, warriorScoreText, valkyrieScoreText, wizardScoreText, elfScoreText, levelText;

    //references to characters stats
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
        //updates the players stat values
        UpdatePlayerStats();
    }

    /// <summary>
    /// enables the menu UI
    /// </summary>
    private void EnableMenuUI()
    {
        //disable the playing screen and game over screen, but enable the menu screen
        SetDisplayScreen(true, false, false);

        //disable the cursor
        Cursor.visible = false;
    }

    /// <summary>
    /// enables the playing game screen
    /// </summary>
    private void EnablePlayingUI()
    {
        //disable the menu and game over screen, but enable the playing screen
        SetDisplayScreen(false, true, false);

        StartCoroutine(PressStartToJoinText());
    }

    /// <summary>
    /// enable the game over screen
    /// </summary>
    private void EnableGameOverUI()
    {
        //disable the menu and playing screen, but enable the game over screen
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

    /// <summary>
    /// Updates the players stat values depending on which characters are in play
    /// </summary>
    private void UpdatePlayerStats()
    {
        //if there is a warrior player
        if (warrior != null)
        {
            //set the warrior's health text and score text
            warriorHealthText.text = warrior.playerHealth.ToString();
            warriorScoreText.text = warrior.playerScore.ToString();
        }

        //if there is a valkyrie player
        if (valkyrie != null)
        {
            //set the valkyries health text and score text
            valkyrieHealthText.text = valkyrie.playerHealth.ToString();
            valkyrieScoreText.text = valkyrie.playerScore.ToString();
        }

        //if there is a wizard player
        if (wizard != null)
        {
            //set the wizard's health text and score text
            wizardHealthText.text = wizard.playerHealth.ToString();
            wizardScoreText.text = wizard.playerScore.ToString();
        }

        //if there is an elf player
        if (elf != null)
        {
            //set the elf's health text and score text
            elfHealthText.text = elf.playerHealth.ToString();
            elfScoreText.text = elf.playerScore.ToString();
        }
    }

    /// <summary>
    /// Text that appears at the start of the game to tell the player how to join in
    /// </summary>
    /// <returns> text duration </returns>
    private IEnumerator PressStartToJoinText()
    {
        for (int index = 0; index < 1; index++)
        {
            //set the text to active for 3 seconds
            centerText.SetActive(true);

            yield return new WaitForSeconds(3f);
        }

        //turn the text off
        centerText.SetActive(false);
    }
}
