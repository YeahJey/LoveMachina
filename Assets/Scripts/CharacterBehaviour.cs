using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour, IHealth
{
    float cooldown;
    float comboCooldown;
    Animator animator;
    public Movement movement;
    PlayerAttack attack;
    public float damage;
    public float health { get; set; }

    public float moveSpeed;
    public GameObject playerRotation;
    public bool isMovable = true;
    public Vector2 movementDir;
    public Rigidbody2D rb;


    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        movement = gameObject.GetComponent<Movement>();
        attack = gameObject.GetComponentInChildren<PlayerAttack>();
    }
    public void ChangeHealth(float amount)
    {
        health -= amount;
    }

    private void Update()
    {
        //if (cooldown > 0) cooldown -= Time.deltaTime * (1 + (GemManager.instance.GetGem(GemManager.Gems.Green)/100));
        if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            animator.SetBool("IsAttacking", true);
            cooldown = 1f;
        }
        else if (Input.GetMouseButtonDown(0) && cooldown >= 0)
        {
            comboCooldown = 0.5f;
            animator.SetBool("IsAttacking", true);
            animator.SetBool("ReadyToCombo", true);
        }
    }
    private void FixedUpdate()
    {
        if (cooldown > 0) cooldown = animator.GetFloat("AttackCombo");
        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) isMovable = true;
        else isMovable = false;
        if (comboCooldown > 0) comboCooldown -= Time.deltaTime;
        else animator.SetBool("ReadyToCombo", false);
        movementDir.x = Input.GetAxisRaw("Horizontal");
        movementDir.y = Input.GetAxisRaw("Vertical");
        if (isMovable)
        {
            rb.MovePosition((Vector2)transform.position + movementDir * moveSpeed * Time.fixedDeltaTime);
            //Player rotation
            //Vector3 pos = Camera.main.WorldToScreenPoint(playerRotation.transform.position);
            //Vector3 dir = Input.mousePosition - pos;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            //playerRotation.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

}
