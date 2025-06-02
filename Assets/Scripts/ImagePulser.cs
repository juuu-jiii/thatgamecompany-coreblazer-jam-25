using UnityEngine;

public class ImagePulser : MonoBehaviour
{
    [SerializeField] private AnimationCurve _scaleCurve;
    //[SerializeField] private GameObject _image;
    [SerializeField] private float _amplitudeModifier;
    private Vector3 _originalScale;
    private bool _animationInProgress = false;
    private float _elapsedTime = 0f;

    public void Play()
    {
        if (!_animationInProgress)
            _animationInProgress = true;
    }

    private void Reset()
    {
        _animationInProgress = false;
        _elapsedTime = 0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            Play();

        if (_animationInProgress)
        {
            _elapsedTime += Time.deltaTime;
            float scale = _scaleCurve.Evaluate(_elapsedTime);
            transform.localScale = new Vector3(
                _originalScale.x + scale * _amplitudeModifier,
                _originalScale.y + scale * _amplitudeModifier,
                _originalScale.z + scale * _amplitudeModifier);

            if (_elapsedTime >= _scaleCurve[_scaleCurve.length - 1].time)
            {
                Reset();
            }
        }
    }
}
