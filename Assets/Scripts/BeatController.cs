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
    private float firstBeats = 0;
    private float songLength = 0;

    void Start()
    {
        songLength = (audio.clip.length - startBeats + 1);
        audio.PlayDelayed(startBeats);
        StartCoroutine(Delay(startBeats));

    }

    void Update()
    {
        foreach(Intervals interval in intervals)
        {
            sampleTime = ((audio.timeSamples / (audio.clip.frequency * interval.GetBeatLength(bpm))) + firstBeats);
            
            if(sampleTime <= songLength)
            {
                interval.CheckForNewInterval(sampleTime);
            }
            
        }
    }

    public IEnumerator Delay(float startBeats)
    {
        foreach (Intervals interval in intervals)
        {
            for (startIntervals++; startIntervals < startBeats; startIntervals++)
            {
                //interval.CheckForNewInterval(startIntervals);
                yield return new WaitForSeconds(interval.GetBeatLength(bpm));
                print(firstBeats);
                firstBeats++;
                if (firstBeats > startBeats)
                {
                    StopCoroutine(Delay(startBeats));
                }
            }
        }
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
        if (Mathf.FloorToInt(interval) != lastInterval && Mathf.FloorToInt(interval) > lastInterval)
        {
            lastInterval = Mathf.FloorToInt(interval);
            trigger.Invoke();
        }
    }
}
