using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;

public class BeatController : MonoBehaviour
{
    [SerializeField] private float bpm = 0;
    [SerializeField] private AudioSource audioBeat;
    //[SerializeField] private AudioSource audioSilent;
    [SerializeField] private Intervals[] intervals;
    [SerializeField] private float startBeats = 1;
    [SerializeField] private BackgroundColorChanger bgColorChanger;
    [SerializeField] private bool audioLoop = false;
    //[SerializeField] private bool changeBg = false;

    //public Intervals interval;
    public float sampleTime = 0;
    private float startIntervals = 0;
    private Intervals interval;
    private float firstBeats = 0;
    private float songLength = 0;

    void Start()
    {
        songLength = (audioBeat.clip.length - startBeats);
        audioBeat.mute = true;
        //Debug.Log(audioBeat.mute);
        audioBeat.PlayDelayed(0);
        //Debug.Log(audioBeat.mute);
        //Debug.Log("Played Muted");
        //StartCoroutine(Delay(startBeats));
        //Debug.Log("note count is " + bgColorChanger.NoteCount);
    }

    void Update()
    {
        //if ((int)(songLength / ((audio.timeSamples / (audio.clip.frequency * intervals.FirstOrDefault()?.GetBeatLength(bpm))) + firstBeats)) != int.MinValue)
        //    bgColorChanger.NoteCount = (int)(songLength / ((audio.timeSamples / (audio.clip.frequency * intervals.FirstOrDefault()?.GetBeatLength(bpm))) + firstBeats));

        foreach (Intervals interval in intervals)
        {
            //Debug.Log("number of notes is " + songLength / sampleTime);
            sampleTime = ((audioBeat.timeSamples / (audioBeat.clip.frequency * interval.GetBeatLength(bpm))) /* + firstBeats */ );
            //Debug.Log("SampleTime: " + sampleTime);
            
            if(!audioLoop)
            {
                if (bgColorChanger.NoteCount == 0 || bgColorChanger.NoteCount == int.MinValue)
                    bgColorChanger.NoteCount = (int)(songLength / ((audioBeat.timeSamples / (audioBeat.clip.frequency * intervals.FirstOrDefault()?.GetBeatLength(bpm))) /* + firstBeats */ ));
            }
            

            if (audioBeat.mute)
            {
                //firstBeats++;
                if (sampleTime >= startBeats && !audioLoop)
                {
                    audioBeat.mute = false;
                    audioBeat.PlayDelayed(0);
                    //Debug.Log("Played Unmuted");
                    //Debug.Log(audioBeat.mute);
                }
            }

            //print(interval.gameObject.name);
            //print(interval.CheckTrigger());
            if ((sampleTime+startBeats) <= songLength && sampleTime != 0)
            {
                interval.CheckForNewInterval(sampleTime);
            }
            else if(audioLoop)
            {
                interval.CheckForNewInterval(sampleTime);
            }
            
        }
    }

    /*
    public IEnumerator Delay(float startBeats)
    {
        foreach (Intervals interval in intervals)
        {
            for (startIntervals++; startIntervals < startBeats; startIntervals++)
            {
                //interval.CheckForNewInterval(startIntervals);
                yield return new WaitForSeconds(interval.GetBeatLength(bpm));
                
                if (bgColorChanger.NoteCount == 0 || bgColorChanger.NoteCount == int.MinValue)
                    bgColorChanger.NoteCount = (int)(songLength / ((audioBeat.timeSamples / (audioBeat.clip.frequency * intervals.FirstOrDefault()?.GetBeatLength(bpm))) + firstBeats));

                print(firstBeats);
                firstBeats++;
                if (firstBeats > startBeats)
                {
                    StopCoroutine(Delay(startBeats));
                }
            }
        }
        
    }
    */

    private void Test()
    {
        //audio.clip.length;
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float noteLength;
    [SerializeField] private UnityEvent trigger;
    private int lastInterval = 0;
    private int totalIntervals = 0;

    public float GetBeatLength(float bpm)
    {
        return 60f / (bpm * noteLength);
    }

    public void CheckForNewInterval(float interval)
    {
        if (Mathf.FloorToInt(interval) != lastInterval /* && Mathf.FloorToInt(interval) > lastInterval */)
        {
            Debug.Log("total intervals is " + ++totalIntervals);
            Debug.Log(Mathf.FloorToInt(interval));
            lastInterval = Mathf.FloorToInt(interval);
            trigger.Invoke();
        }
    }
}
