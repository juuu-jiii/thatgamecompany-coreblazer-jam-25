using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class BeatController : MonoBehaviour
{
    [SerializeField] private float bpm = 0;
    [SerializeField] private AudioSource audio;
    [SerializeField] private Intervals[] intervals;
    [SerializeField] private float startBeats = 1;

    //public Intervals interval;
    public float sampleTime = 0;
    private float startIntervals = 0;
    private Intervals interval;

    void Start()
    {
        audio.PlayDelayed(startBeats);
        StartCoroutine(Delay(startBeats));

    }

    void Update()
    {
        foreach(Intervals interval in intervals)
        {
            sampleTime = (audio.timeSamples / (audio.clip.frequency * interval.GetBeatLength(bpm)));
            interval.CheckForNewInterval(sampleTime);
        }
    }

    public IEnumerator Delay(float startBeats)
    {
        for (startIntervals++; startIntervals < startBeats; startIntervals++)
        {
            interval.CheckForNewInterval(startIntervals);
            yield return new WaitForSeconds(interval.GetBeatLength(bpm));
        }

        StopCoroutine(Delay(startBeats));
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float noteLength;
    [SerializeField] private UnityEvent trigger;
    private int lastInterval = 0;

    public float GetBeatLength(float bpm)
    {
        return 60f / (bpm * noteLength);
    }

    public void CheckForNewInterval(float interval)
    {
        if (Mathf.FloorToInt(interval) != lastInterval)
        {
            lastInterval = Mathf.FloorToInt(interval);
            trigger.Invoke();
        }
    }
}
