using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPin : MonoBehaviour
{
    [SerializeField] private float coolDown;
    [SerializeField] public Transform shootingPos;
    [SerializeField] public GameObject arrows;
    private float cdTimer = 999;

    private Animator animator;
    private Movement movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && cdTimer > coolDown && movement.canShoot()) 
        {
            Shoot();
        }
        cdTimer += Time.deltaTime;
    }

    private void Shoot()
    {
        Instantiate(arrows, shootingPos.position, transform.rotation);
        animator.SetTrigger("Shoot");
        cdTimer = 0;

    }
}
