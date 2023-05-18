using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OlvidoTokenCollect : MonoBehaviour
{
    [SerializeField] private AudioClip tokenOlvido;


    public GameObject OlvidoLayer;

    [SerializeField]
    private Volume _volume;
    private ChromaticAberration _chromaticAberration;
    private DepthOfField _depthOfField;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = true;
            PostProInActive();
            Destroy(gameObject);
            OlvidoLayer.SetActive(false);
            AudioSource.PlayClipAtPoint(this.tokenOlvido, this.transform.position);
        }
    }

    public void PostProInActive()
    {
        VolumeProfile profile = _volume.sharedProfile;

        _volume.profile.TryGet(out _chromaticAberration);
        _volume.profile.TryGet(out _depthOfField);
        _chromaticAberration.active = false;
        _depthOfField.active = false;
    }
}
