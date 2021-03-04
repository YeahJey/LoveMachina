using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    List<IHealth> healths = new List<IHealth>();
    public CharacterBehaviour character;
    BoxCollider2D box;
    [Range(0, 1)][SerializeField] float attackDash = 5f;
    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    public void Attack()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(character.playerRotation.transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        character.playerRotation.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var rot = character.playerRotation.transform.rotation.eulerAngles.z;
        var enemies = Physics2D.OverlapBoxAll(new Vector3(transform.position.x + (Mathf.Sin(Mathf.Deg2Rad * -rot) * box.offset.y * 0.3f), transform.position.y + (Mathf.Cos(Mathf.Deg2Rad * -rot) * box.offset.y * 0.3f), 0), box.size * 0.3f, -rot);
        Vector2 direction = dir.normalized;
        character.rb.MovePosition((Vector2)transform.position + direction * attackDash);
        //print(new Vector3((transform.position.x + (Mathf.Sin(Mathf.Deg2Rad * -rot) * box.offset.y)) * 0.3f, (transform.position.y + (Mathf.Cos(Mathf.Deg2Rad * -rot) * box.offset.y)) * 0.3f, 0));     
        foreach (Collider2D enemy in enemies)
        {
            if(enemy.tag == "Enemy")
            {
                enemy.GetComponent<IHealth>().ChangeHealth(10);
                print(enemy.GetComponent<IHealth>().health);
            }
        }
    }
}
