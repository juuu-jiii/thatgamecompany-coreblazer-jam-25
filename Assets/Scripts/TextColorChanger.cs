using System.Collections;
using TMPro;
using UnityEngine;

public class TextColorChanger : MonoBehaviour
{
    [SerializeField] private AnimationCurve _colorCurve;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private TextMeshProUGUI _tmPro;
    [SerializeField] private float _delay;
    private bool _animating = false;
    private float _elapsedTime = 0f;

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);
        _animating = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_delay > 0f)
            StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (_animating && _elapsedTime <= _colorCurve[_colorCurve.length - 1].time)
        {
            _tmPro.color = Color.Lerp(
                _startColor, 
                _endColor, 
                _elapsedTime / _colorCurve[_colorCurve.length - 1].time);
            _elapsedTime += Time.deltaTime;
        }
        
    }
}
