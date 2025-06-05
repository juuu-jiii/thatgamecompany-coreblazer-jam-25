using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _noteHit;
    [SerializeField] private GameObject _noteMissed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NoteController.OnNoteHit += ShowNoteHit;
        NoteController.OnNoteMissed += ShowNoteMissed;
    }

    private void ShowNoteMissed()
    {
        _noteHit.SetActive(false);
        _noteMissed.SetActive(true);
    }

    private void ShowNoteHit()
    {
        _noteHit.SetActive(true);
        _noteMissed.SetActive(false);
    }

    private void OnDestroy()
    {
        NoteController.OnNoteHit -= ShowNoteHit;
        NoteController.OnNoteMissed -= ShowNoteMissed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
