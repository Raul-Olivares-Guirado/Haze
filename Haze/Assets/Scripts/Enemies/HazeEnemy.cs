using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;



public class HazeEnemy : MonoBehaviour
{

    public TimerController timerController;
    [SerializeField]
    private Volume _volume;
    private Vignette _vignette;
    private LensDistortion _lensDistortion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timerController.EnabledTimer();
            PostProActive();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timerController.DisabledTimer();
            PostProInActive();
        }
    }

    public void PostProActive()
    {
        VolumeProfile profile = _volume.sharedProfile;

        _volume.profile.TryGet(out _vignette);
        _volume.profile.TryGet(out _lensDistortion);
        _vignette.intensity.value = 1f;
        _lensDistortion.active = true;
    }

    public void PostProInActive()
    {
        VolumeProfile profile = _volume.sharedProfile;

        _volume.profile.TryGet(out _vignette);
        _volume.profile.TryGet(out _lensDistortion);
        _vignette.intensity.value = 0.173f;
        _lensDistortion.active = false;
    }
}
