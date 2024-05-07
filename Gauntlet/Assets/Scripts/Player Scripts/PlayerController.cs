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
    public PlayerInput playerInput;

    //the various character prefabs
    public GameObject[] characterPrefabs = new GameObject[4];

    //the various projectile prefabs
    public GameObject[] projectilePrefabs = new GameObject[4];

    public CharacterType character;

    public IMeleeBehavior meleeBehavior;
    public IShootBehavior shootBehavior;

    private void OnEnable()
    {
        PlayerEventBus.Subscribe(PlayerEvent.OnSpawn, InitializePlayerController);
    }

    private void OnDisable()
    {
        PlayerEventBus.Unsubscribe(PlayerEvent.OnSpawn, InitializePlayerController);
    }

    public void Start()
    {
        PlayerEventBus.Publish(PlayerEvent.OnSpawn);
    }

    private void FixedUpdate()
    {
        Vector2 moveVecY = playerInput.Player.Move.ReadValue<Vector2>();
        Vector2 moveVecX = playerInput.Player.Move.ReadValue<Vector2>();
        transform.Translate(new Vector3(moveVecX.x, 0f, moveVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
        SetRotation(moveVecX, moveVecY);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        
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


    /// <summary>
    /// initializes the player controller at the start of the game
    /// </summary>
    public void InitializePlayerController()
    {
        switch(GameManager.Instance.characters)
        {
            case 0:
                character = CharacterType.Warrior;
                break;

            case 1:
                character = CharacterType.Valkyrie;
                break;

            case 2:
                character = CharacterType.Wizard;
                break;

            case 3:
                character = CharacterType.Elf;
                break;

        }

        switch (character)
        {
            case CharacterType.Warrior:
                gameObject.AddComponent<Warrior>();
                gameObject.AddComponent<ThrowAxe>();
                gameObject.AddComponent<WarriorMelee>();
                break;

            case CharacterType.Wizard:
                gameObject.AddComponent<Wizard>();
                gameObject.AddComponent<ThrowFireball>();
                break;

            case CharacterType.Valkyrie:
                gameObject.AddComponent<Valkyrie>();
                gameObject.AddComponent<throwSword>();
                gameObject.AddComponent<swordMelee>();
                break;
            //case CharacterType.Elf:
            //    gameObject.AddComponent<Elf>();
            //    gameObject.AddComponent<ShootArrow>();
            //    gameObject.AddComponent<ElfMelee>();
            //    break;
        }

        GetComponent<InventoryManager>().InitializeSlots();

        GameManager.Instance.players.Add(this.gameObject);

        //reference for the PlayerInput scriptable object
        playerInput = new PlayerInput(); //constructor
        //turn player on
        playerInput.Enable();

        //characterToAdd++;

        //if (characterToAdd == 3)
        //{
        //    GameManager.Instance.maxCharactersInPlay = true;
        //    characterToAdd = 0;
        //}
        //else
        //{
        //    characterToAdd++;
        //}
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
