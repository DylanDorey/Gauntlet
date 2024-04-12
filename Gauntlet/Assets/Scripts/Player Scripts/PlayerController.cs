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

    public CharacterType character;

    private GameObject characterPrefab;
    public IMeleeBehavior meleeBehavior;
    public IShootBehavior shootBehavior;

    private void OnEnable()
    {
        PlayerEventBus.Subscribe(PlayerEvent.OnSpawn, StartPlayerController);
    }

    private void OnDisable()
    {
        PlayerEventBus.Unsubscribe(PlayerEvent.OnSpawn, StartPlayerController);
    }

    public virtual void Start()
    {
        PlayerEventBus.Publish(PlayerEvent.OnSpawn);
    }

    private void FixedUpdate()
    {
        switch (character)
        {
            case CharacterType.Warrior:

                Vector2 warriorVecY = warriorInput.Warrior.Move.ReadValue<Vector2>();
                Vector2 warriorVecX = warriorInput.Warrior.Move.ReadValue<Vector2>();
                transform.Translate(new Vector3(warriorVecX.x, 0f, warriorVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
                SetRotation(warriorVecX, warriorVecY);
                break;

            case CharacterType.Valkyrie:

                //reads the Vector2 value from the playerActions components and from the move action (AD) in our actions scriptable object
                Vector2 valkyrieVecY = valkyrieInput.Valkyrie.Move.ReadValue<Vector2>();
                Vector2 valkyrieVecX = valkyrieInput.Valkyrie.Move.ReadValue<Vector2>();
                transform.Translate(new Vector3(valkyrieVecX.x, 0f, valkyrieVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
                SetRotation(valkyrieVecX, valkyrieVecY);
                break;

            case CharacterType.Wizard:

                //reads the Vector2 value from the playerActions components and from the move action (AD) in our actions scriptable object
                Vector2 wizardVecY = wizardInput.Wizard.Move.ReadValue<Vector2>();
                Vector2 wizardVecX = wizardInput.Wizard.Move.ReadValue<Vector2>();
                transform.Translate(new Vector3(wizardVecX.x, 0f, wizardVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
                SetRotation(wizardVecX, wizardVecY);
                break;

            case CharacterType.Elf:

                //reads the Vector2 value from the playerActions components and from the move action (AD) in our actions scriptable object
                Vector2 elfVecY = elfInput.Elf.Move.ReadValue<Vector2>();
                Vector2 elfVecX = elfInput.Elf.Move.ReadValue<Vector2>();
                transform.Translate(new Vector3(elfVecX.x, 0f, elfVecY.y) * (GetComponent<PlayerData>().playerSpeed * Time.deltaTime));
                SetRotation(elfVecX, elfVecY);
                break;
        }
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
        if (context.performed)
        {
            ApplyMeleeBehavior(meleeBehavior);
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ApplyShootBehavior(shootBehavior);
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
        switch (character)
        {
            case CharacterType.Warrior:

                //reference for the WarriorInput scriptable object
                warriorInput = new WarriorInput(); //constructor
                //turn warrior on
                warriorInput.Enable();
                break;

            case CharacterType.Valkyrie:

                //reference for the ValkyrieInput scriptable object
                valkyrieInput = new ValkyrieInput(); //constructor
                //turn valkyrie on
                valkyrieInput.Enable();
                break;

            case CharacterType.Wizard:

                //reference for the WizardInput scriptable object
                wizardInput = new WizardInput(); //constructor
                //turn wizard on
                wizardInput.Enable();
                break;

            case CharacterType.Elf:

                //reference for the ElfInput scriptable object
                elfInput = new ElfInput(); //constructor
                //turn elf on
                elfInput.Enable();
                break;
        }

        characterPrefab = transform.GetChild(0).gameObject;

        //determine which character this player will be
        //int characterToAdd = GameManager.Instance.characters;
        //switch (characterToAdd)
        //{
        //    case 0:
        //        gameObject.AddComponent<Warrior>();
        //        gameObject.AddComponent<ThrowAxe>();
        //        gameObject.AddComponent<WarriorMelee>();
        //        break;
        //    case 1:
        //        gameObject.AddComponent<Wizard>();
        //        gameObject.AddComponent<ThrowFireball>();
        //        break;
        //    case 2:
        //        gameObject.AddComponent<Valkyrie>();
        //        gameObject.AddComponent<ThrowSword>();
        //        gameObject.AddComponent<ValkyrieMelee>();
        //        break;
        //    case 3:
        //        gameObject.AddComponent<Elf>();
        //        gameObject.AddComponent<ShootArrow>();
        //        gameObject.AddComponent<ElfMelee>();
        //        break;
        //    default:
        //        break;
        //}

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

    /// <summary>
    /// Spawns in the player controller prefab at its spawn location
    /// </summary>
    public void StartPlayerController()
    {
        InitializePlayerController();
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
