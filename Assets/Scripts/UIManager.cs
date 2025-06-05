using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _noteHit;
    [SerializeField] private GameObject _noteMissed;
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _timeToUiFade;
    private Vector3 _initialScale;
    private bool _isPlaying = false;
    private float _elapsedTime = 0f;
    private float _timeSinceLastNoteHitOrMissed = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialScale = _noteHit.transform.localScale; // assumes initial scale of _noteHit and _noteMissed are equal
        NoteController.OnNoteHit += ShowNoteHit;
        NoteController.OnNoteMissed += ShowNoteMissed;
    }

    private void Play()
    {
        _isPlaying = true;
    }

    private void Stop()
    {
        _isPlaying = false;
        _elapsedTime = 0f;
    }

    private void FadeUi()
    {

    }

    private void ShowNoteMissed()
    {
        _noteHit.SetActive(false);
        _noteMissed.SetActive(true);
        Play();
        _timeSinceLastNoteHitOrMissed = 0f;
    }

    private void ShowNoteHit()
    {
        _noteHit.SetActive(true);
        _noteMissed.SetActive(false);
        Play();
        _timeSinceLastNoteHitOrMissed = 0f;
    }

    private void OnDestroy()
    {
        NoteController.OnNoteHit -= ShowNoteHit;
        NoteController.OnNoteMissed -= ShowNoteMissed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlaying)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime <= _scaleCurve[_scaleCurve.length - 1].time)
            {
                _noteHit.transform.localScale = _initialScale * _scaleCurve.Evaluate(_elapsedTime);
                _noteMissed.transform.localScale = _initialScale * _scaleCurve.Evaluate(_elapsedTime);
            }
            else
            {
                Stop();
            }
        }

        _timeSinceLastNoteHitOrMissed += Time.deltaTime;

        if (_timeSinceLastNoteHitOrMissed >= _timeToUiFade)
        {
            FadeUi();
        }
    }
}
