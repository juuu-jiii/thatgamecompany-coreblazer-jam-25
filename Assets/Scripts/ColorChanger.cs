using System.Collections;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private AnimationCurve _colorCurve;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _delay;
    private float _elapsedTime = 0f;

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);
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
        if (_elapsedTime <= _colorCurve[_colorCurve.length - 1].time)
        {
            _spriteRenderer.color = Color.Lerp(
                _gradient.colorKeys[0].color, 
                _gradient.colorKeys[_gradient.colorKeys.Length - 1].color, 
                _elapsedTime / _colorCurve[_colorCurve.length - 1].time);
            _elapsedTime += Time.deltaTime;
        }
        
    }
}
