using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/10/2024]
 * [Allows Player to move around and interact with game environment]
 */

public enum CharacterType
{
    Warrior,
    Valkyrie,
    Wizard,
    Elf
}

public class PlayerController : MonoBehaviour
{
    //reference to various scriptable objects, character inputs
    public WarriorInput warriorInput;
    public ValkyrieInput valkyrieInput;
    public WizardInput wizardInput;
    public ElfInput elfInput;

    public int playerIndex = 0;

    //the type of character the player is
    public CharacterType characterType;
    public IMeleeBehavior meleeBehavior;
    public IShootBehavior shootBehavior;

    //the various character prefabs
    public GameObject[] characterPrefabs = new GameObject[4];
    //the various projectile prefabs
    public GameObject[] projectilePrefabs = new GameObject[4];

    public AudioClip[] warriorAudioClips;
    public AudioClip[] valkyrieAudioClips;
    public AudioClip[] wizardAudioClips;
    public AudioClip[] elfAudioClips;


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
        //PlayerEventBus.Publish(PlayerEvent.OnSpawn);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isPlaying)
        {
            if (characterType == CharacterType.Warrior)
            {
                Vector2 warriorVecY = warriorInput.Warrior.Move.ReadValue<Vector2>();
                Vector2 warriorVecX = warriorInput.Warrior.Move.ReadValue<Vector2>();
                transform.Translate(new Vector3(warriorVecX.x, 0f, warriorVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
                SetRotation(warriorVecX, warriorVecY);
            }
            else if(characterType == CharacterType.Wizard)
            {
                Vector2 wizardVecY = wizardInput.Wizard.Move.ReadValue<Vector2>();
                Vector2 wizardVecX = wizardInput.Wizard.Move.ReadValue<Vector2>();
                transform.Translate(new Vector3(wizardVecX.x, 0f, wizardVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
                SetRotation(wizardVecX, wizardVecY);
            }
            else if (characterType == CharacterType.Valkyrie)
            {
                Vector2 valkyrieVecY = valkyrieInput.Valkyrie.Move.ReadValue<Vector2>();
                Vector2 valkyrieVecX = valkyrieInput.Valkyrie.Move.ReadValue<Vector2>();
                transform.Translate(new Vector3(valkyrieVecX.x, 0f, valkyrieVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
                SetRotation(valkyrieVecX, valkyrieVecY);
            }
            //switch (characterType)
            //{
            //    case CharacterType.Warrior:
            //        Vector2 warriorVecY = warriorInput.Warrior.Move.ReadValue<Vector2>();
            //        Vector2 warriorVecX = warriorInput.Warrior.Move.ReadValue<Vector2>();
            //        transform.Translate(new Vector3(warriorVecX.x, 0f, warriorVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
            //        SetRotation(warriorVecX, warriorVecY);
            //        break;

            //    case CharacterType.Valkyrie:
            //        Vector2 wizardVecY = wizardInput.Wizard.Move.ReadValue<Vector2>();
            //        Vector2 wizardVecX = wizardInput.Wizard.Move.ReadValue<Vector2>();
            //        transform.Translate(new Vector3(wizardVecX.x, 0f, wizardVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
            //        SetRotation(wizardVecX, wizardVecY);
            //        break;

            //    case CharacterType.Wizard:
            //        Vector2 valkyrieVecY = valkyrieInput.Valkyrie.Move.ReadValue<Vector2>();
            //        Vector2 valkyrieVecX = valkyrieInput.Valkyrie.Move.ReadValue<Vector2>();
            //        transform.Translate(new Vector3(valkyrieVecX.x, 0f, valkyrieVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
            //        SetRotation(valkyrieVecX, valkyrieVecY);
            //        break;

            //    case CharacterType.Elf:
            //        //Vector2 elfVecY = elfInput.Elf.Move.ReadValue<Vector2>();
            //        //Vector2 elfVecX = elfInput.Elf.Move.ReadValue<Vector2>();
            //        //transform.Translate(new Vector3(elfVecX.x, 0f, elfVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
            //        //SetRotation(elfVecX, elfVecY);
            //        break;
            //}
        }
    }

    /// <summary>
    /// Allows the player to move around
    /// </summary>
    /// <param name="context"> the context in which the button was pressed </param>
    public void OnMove(InputAction.CallbackContext context)
    {
        //On move is only going to fire when called with W or S
        Vector2 moveVecY = context.ReadValue<Vector2>();
        Vector2 moveVecX = context.ReadValue<Vector2>();
        transform.Translate(new Vector3(moveVecX.x, 0f, moveVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
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
            if (GetComponent<PlayerData>().hasPotion)
            {
                GetComponent<InventoryManager>().potionSlots.transform.GetChild(0).GetComponent<PotionSlot>().itemBehavior.Behavior(GetComponent<PlayerData>());
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

        //switch (character)
        //{
        //    case CharacterType.Warrior:
        //        gameObject.AddComponent<Warrior>();
        //        gameObject.AddComponent<ThrowAxe>();
        //        gameObject.AddComponent<WarriorMelee>();
        //        break;

        //    case CharacterType.Wizard:
        //        gameObject.AddComponent<Wizard>();
        //        gameObject.AddComponent<ThrowFireball>();
        //        break;

        //    case CharacterType.Valkyrie:
        //        gameObject.AddComponent<Valkyrie>();
        //        gameObject.AddComponent<throwSword>();
        //        gameObject.AddComponent<swordMelee>();
        //        break;

        //    //case CharacterType.Elf:
        //    //    gameObject.AddComponent<Elf>();
        //    //    gameObject.AddComponent<ShootArrow>();
        //    //    gameObject.AddComponent<ElfMelee>();
        //    //    break;
        //}

        switch (characterType)
        {
            case CharacterType.Warrior:
                warriorInput = new WarriorInput();
                warriorInput.Enable();
                GameManager.Instance.characters++;
                GameManager.Instance.players.Add(gameObject);
                GetComponent<InventoryManager>().InitializeSlots();
                break;

            case CharacterType.Wizard:
                wizardInput = new WizardInput();
                wizardInput.Enable();
                GameManager.Instance.characters++;
                GameManager.Instance.players.Add(gameObject);
                GetComponent<InventoryManager>().InitializeSlots();
                break;

            case CharacterType.Valkyrie:
                valkyrieInput = new ValkyrieInput();
                valkyrieInput.Enable();
                GameManager.Instance.characters++;
                GameManager.Instance.players.Add(gameObject);
                GetComponent<InventoryManager>().InitializeSlots();
                break;

                //case CharacterType.Elf:
                //elfInput = new ElfInput();
                //elfInput.Enable();
                //GameManager.Instance.characters++;
                //GameManager.Instance.players.Add(gameObject);
                //GetComponent<InventoryManager>().InitializeSlots();
                //    break;
        }
    }

    ///// <summary>
    ///// Spawns in the player controller prefab at its spawn location
    ///// </summary>
    //public void StartPlayerController()
    //{
    //    InitializePlayerController();
    //}

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
