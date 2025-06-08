using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorChanger : MonoBehaviour
{
    [SerializeField] private AnimationCurve _colorCurve;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private Image _image;
    [SerializeField] private float _delay;

    public delegate void FinishFadingDelegate();
    public static FinishFadingDelegate OnFinishFading;

    private bool _animating = false;
    private float _elapsedTime = 0f;

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);
        _animating = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        Debug.Log("play called");
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (_animating)
        {
            Debug.Log("animating");
            if (_elapsedTime <= _colorCurve[_colorCurve.length - 1].time)
            {
                _image.color = Color.Lerp(
                    _startColor,
                    _endColor,
                    _elapsedTime / _colorCurve[_colorCurve.length - 1].time);
                _elapsedTime += Time.deltaTime;
            }
            else
            {
                OnFinishFading?.Invoke();
            }
        }
    }
}
