using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    public Transform controlHit;

    public float radiusHit;

    public float timeToAttack;

    public float nextAttackTime;

    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {

        if (nextAttackTime > 0)
        {
            nextAttackTime -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && nextAttackTime <= 0)
        {
            Attacking();
            nextAttackTime = timeToAttack;
        }
    }


    private void Attacking()
    {
        //Llama al trigger que he creado en el animator del personaje para el ataque
        _animator.SetTrigger("Attack");

        Collider2D[] objects = Physics2D.OverlapCircleAll(controlHit.position, radiusHit);

        foreach (Collider2D collision in objects)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.transform.GetComponent<LifesEnemy>().HittAndLife();
            }
        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controlHit.position, radiusHit);
    }





















    /*
    /// <summary>
    /// Ataque con espada
    /// </summary>
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
        _Collider2D.enabled = false;
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

    //Gestiona el ataque del enemigo
    public void Attack()
    {
        animator.Play("AttackSword");
        //Activa el collider cuando ataca
        _Collider2D.enabled = true; 
        //Desactiva el collider al atacar en 0.5 seg
        Invoke("DisableAttack", 0.1f);
    }
    //Desactiva el ataque que luego hacemos un invoke
    public void DisableAttack()
    {
        _Collider2D.enabled = false;
    }
    //Gestiona la colision de la espada con el enemigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<LifesEnemy>().HittAndLife(); //LLama al componente de la clase LifesEnemy pra usar su metodo de restar las vida y destruirlo
        }
    }*/

}
