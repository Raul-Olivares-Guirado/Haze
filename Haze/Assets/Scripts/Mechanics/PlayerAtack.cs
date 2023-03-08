using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    //Llama al player como referencia para los flip x
    private SpriteRenderer _PlayerSpriteRenderer;
    //Llama al box collider de la espada 
    private BoxCollider2D _Collider2D;

    public Animator animator;
    //Referencia para mover la espada y flipearla en x
    public GameObject swordParent;

    // Start is called before the first frame update
    void Start()
    {
        //Accedemos al componente del player para comprobar si hace el flip x 
        _PlayerSpriteRenderer = transform.root.GetComponent<SpriteRenderer>();
        //Coge el collider de la espada
        _Collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Attack();
        }

        if (_PlayerSpriteRenderer.flipX == true)
        {
            swordParent.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            swordParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }


    public void Attack()
    {
        animator.Play("AttackSword");
        _Collider2D.enabled = true;
        Invoke("DisableAttack", 0.5f);
    }

    private void DisableAttack()
    {
        _Collider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HitDamageTest>().LosseLifeAndHit();
            _Collider2D.enabled = false;
        }
    }
}
