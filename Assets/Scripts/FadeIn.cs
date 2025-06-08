using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private AnimationCurve _colorCurve;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private Image _image;
    [SerializeField] private float _delay;
    private float _elapsedTime = 0f;

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (_elapsedTime <= _colorCurve[_colorCurve.length - 1].time)
        {
            _image.color = Color.Lerp(
                _startColor,
                _endColor,
                _elapsedTime / _colorCurve[_colorCurve.length - 1].time);
            _elapsedTime += Time.deltaTime;
        }

    }
}
