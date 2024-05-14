using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/10/2024]
 * [Allows Player to move around and interact with game environment]
 */

//Different character types
public enum CharacterType
{
    Warrior,
    Valkyrie,
    Wizard,
    Elf
}

public class PlayerController : MonoBehaviour
{
    //reference to various character inputs
    public WarriorInput warriorInput;
    public ValkyrieInput valkyrieInput;
    public WizardInput wizardInput;
    public ElfInput elfInput;

    //reference to specific player data
    private PlayerData playerData;
    
    //the assigned index of the player
    public int playerIndex = 0;

    //the type of character the player is
    public CharacterType characterType;

    //various ability behaviors
    public IMeleeBehavior meleeBehavior;
    public IShootBehavior shootBehavior;

    //the various projectile prefabs
    public GameObject[] projectilePrefabs = new GameObject[4];

    public AudioClip[] warriorAudioClips;
    public AudioClip[] valkyrieAudioClips;
    public AudioClip[] wizardAudioClips;
    public AudioClip[] elfAudioClips;

    private Vector2 moveValueX;
    private Vector2 moveValueY;

    private void OnEnable()
    {
        //PlayerEventBus.Subscribe(PlayerEvent.OnSpawn, InitializePlayerController);
        GameEventBus.Subscribe(GameState.startGame, ResetPositionOnStart);
    }

    private void OnDisable()
    {
        //PlayerEventBus.Unsubscribe(PlayerEvent.OnSpawn, InitializePlayerController);
        GameEventBus.Unsubscribe(GameState.startGame, ResetPositionOnStart);
    }

    public void Start()
    {
        InitializePlayerController();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveValueX.x, 0f, moveValueY.y) * (Time.deltaTime * playerData.playerSpeed));

        if(transform.position.y < 0 || transform.position.y > 0.3f)
        {
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        }
    }

    /// <summary>
    /// Allows the player to move around
    /// </summary>
    /// <param name="context"> the context in which the button was pressed </param>
    public void OnMove(InputAction.CallbackContext context)
    {
        moveValueX = context.ReadValue<Vector2>();
        moveValueY = context.ReadValue<Vector2>();
        SetRotation(moveValueX, moveValueY);
    }

    public void OnMelee(InputAction.CallbackContext context)
    {
        if (GetComponent<PlayerData>().hasMelee)
        {
            if (context.performed)
            {
                ApplyMeleeBehavior(meleeBehavior);
            }
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ApplyShootBehavior(shootBehavior);
        }
    }

    public void OnPotionUse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (playerData.hasPotion)
            {
                GetComponent<InventoryManager>().potionSlots.transform.GetChild(0).GetComponent<PotionSlot>().itemBehavior.Behavior(playerData);
                GetComponent<InventoryManager>().RemovePotionOnUse();
            }
        }
    }

    /// <summary>
    /// Set the player model's rotation based on the movement direction
    /// </summary>
    /// <param name="moveX"> the x value input </param>
    /// <param name="moveY"> the y value input </param>
    private void SetRotation(Vector2 moveX, Vector2 moveY)
    {
        switch (moveY.y)
        {
            //if moveY.y is equal to -1 rotate to 180 degrees
            case -1f:
                transform.GetChild(0).eulerAngles = new Vector3(0f, 180f, 0f);
                break;
            //if moveY.y is equal to 1 rotate to 0 degrees
            case 1f:
                transform.GetChild(0).eulerAngles = new Vector3(0f, 0f, 0f);
                break;
        }

        switch (moveX.x)
        {
            //if moveX.x is equal to -1 rotate to -90 degrees
            case -1f:
                transform.GetChild(0).eulerAngles = new Vector3(0f, -90f, 0f);
                break;
            //if moveX.x is equal to 1 rotate to 90 degrees
            case 1f:
                transform.GetChild(0).eulerAngles = new Vector3(0f, 90f, 0f);
                break;
        }

        //if moveX.x is between 0.7f and 0.9f
        if (moveX.x > 0.7f && moveX.x < 0.9f)
        {
            //if moveY.y is between 0.7f and 0.9f
            if (moveY.y > 0.7f && moveY.y < 0.9f)
            {
                //rotate to 45 degrees
                transform.GetChild(0).eulerAngles = new Vector3(0f, 45f, 0f);
            }
            //if moveY.y is between -0.7f and -0.9f
            else if (moveY.y < -0.7f && moveY.y > -0.9f)
            {
                //rotate to 135 degrees
                transform.GetChild(0).eulerAngles = new Vector3(0f, 135f, 0f);
            }
        }
        //if moveX.x is between -0.7f and -0.9f
        else if (moveX.x < -0.7f && moveX.x > -0.9f)
        {
            //if moveY.y is between 0.7f and 0.9f
            if (moveY.y > 0.7f && moveY.y < 0.9f)
            {
                //rotate to -45 degrees
                transform.GetChild(0).eulerAngles = new Vector3(0f, -45f, 0f);
            }
            //if moveY.y is between -0.7f and -0.9f
            else if (moveY.y < -0.7f && moveY.y > -0.9f)
            {
                //rotate to -135 degrees
                transform.GetChild(0).eulerAngles = new Vector3(0f, -135f, 0f);
            }
        }
    }

    private void ResetPositionOnStart()
    {
        transform.position = Vector3.zero;
    }

    /// <summary>
    /// initializes the player controller at the start of the game
    /// </summary>
    public void InitializePlayerController()
    {
        switch (GameManager.Instance.characters)
        {
            case 0:
                characterType = CharacterType.Warrior;
                playerIndex = 0;
                break;

            case 1:
                characterType = CharacterType.Valkyrie;
                playerIndex = 1;
                break;

            case 2:
                characterType = CharacterType.Wizard;
                playerIndex = 2;
                break;

            case 3:
                characterType = CharacterType.Elf;
                playerIndex = 3;
                break;
        }

        switch (characterType)
        {
            case CharacterType.Warrior:
                playerData = GetComponent<PlayerData>();
                warriorInput = new WarriorInput();
                warriorInput.Enable();
                GameManager.Instance.characters++;
                GameManager.Instance.players.Add(gameObject);
                GetComponent<InventoryManager>().InitializeSlots();
                Camera.main.GetComponent<FollowCam>().player = this;
                break;

            case CharacterType.Wizard:
                playerData = GetComponent<PlayerData>();
                wizardInput = new WizardInput();
                wizardInput.Enable();
                GameManager.Instance.characters++;
                GameManager.Instance.players.Add(gameObject);
                GetComponent<InventoryManager>().InitializeSlots();
                break;

            case CharacterType.Valkyrie:
                playerData = GetComponent<PlayerData>();
                valkyrieInput = new ValkyrieInput();
                valkyrieInput.Enable();
                GameManager.Instance.characters++;
                GameManager.Instance.players.Add(gameObject);
                GetComponent<InventoryManager>().InitializeSlots();
                break;

                case CharacterType.Elf:
                playerData = GetComponent<PlayerData>();
                elfInput = new ElfInput();
                elfInput.Enable();
                GameManager.Instance.characters++;
                GameManager.Instance.players.Add(gameObject);
                GetComponent<InventoryManager>().InitializeSlots();
                break;
        }
    }

    //apply a melee behavior
    public void ApplyMeleeBehavior(IMeleeBehavior behavior)
    {
        behavior.MeleeBehavior(this);
    }

    //apply a shoot behavior
    public void ApplyShootBehavior(IShootBehavior behavior)
    {
        behavior.ShootBehavior(this);
    }
}
