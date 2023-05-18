using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AttackOlivido : MonoBehaviour
{

    public Collider2D _Collider2D;

    //Layer de tokens Olvido para revertir los controles
    public GameObject OlvidoLayer;
    //Layer del objeto entero para destruirlo cuando lo tocamos
    public GameObject OlvidoEnemy;

    public Animator animator;

    [SerializeField] private AudioClip ouch;
    [SerializeField] private AudioClip _death;

    [SerializeField]
    private Volume _volume;
    private ChromaticAberration _chromaticAberration;
    private DepthOfField _depthOfField;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PostProActive();
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = false;
            collision.gameObject.GetComponent<PlayerController>().audioSource.PlayOneShot(ouch);
            AudioSource.PlayClipAtPoint(this._death, this.transform.position);
            OlvidoLayer.SetActive(true);
            animator.Play("Baddie-Death");
            Invoke("DestroyEnemy", 0.5f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(OlvidoEnemy);
    }

    public void PostProActive()
    {
        VolumeProfile profile = _volume.sharedProfile;

        _volume.profile.TryGet(out _chromaticAberration);
        _volume.profile.TryGet(out _depthOfField);
        _chromaticAberration.active = true;
        _depthOfField.active = true;
    }


}
