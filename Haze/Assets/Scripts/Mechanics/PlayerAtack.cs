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

    [SerializeField] private AudioClip _attack;

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
        AudioSource.PlayClipAtPoint(this._attack, this.transform.position);
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

}
