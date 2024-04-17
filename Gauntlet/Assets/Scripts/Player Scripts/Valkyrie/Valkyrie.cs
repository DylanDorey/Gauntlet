using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie : MonoBehaviour, IValkyrieMelee, IValkyrieShoot
{
    public float bulletSpeed = 5f;
    public Rigidbody projectile;

    [Range(1f, 10f)]
    public float meleeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private new MonoBehaviour(IValkyrieMelee)
    {
        swingSword();
    }

    private MonoBehaviour(IValkyrieShoot)
    {
        shootSword();
    }

    private void swingSword()
    {
    
    }

    private void shootSword()
    { 
    
    }
}
