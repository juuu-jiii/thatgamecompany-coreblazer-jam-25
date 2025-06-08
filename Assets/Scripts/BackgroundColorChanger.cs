using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField] private Gradient _backgroundColorGradient;
    [SerializeField] private Gradient _bardGradient;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _bardSprite;
    [SerializeField] private float _lerpDuration;
    [SerializeField] private int _leniency; // number of notes the player can miss but still manage to fully transition the background from dark to light
    private bool _animating = false;
    private float _elapsedTime = 0f;

    // the following fields are normalized to range [0, 1]
    private float _animationStartPoint; // as long as animation is playing, this stays constant
    private float _animationEndPoint; // this can change during an animation, if lots of progress is made in a short amount of time, for example

    public int NoteCount;

    private void Stop()
    {
        _animating = false;
        _elapsedTime = 0f;
    }

    public void Play()
    {
        _animating = true;
        _elapsedTime = 0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NoteController.OnNoteHit += Animate;
    }

    private void OnDestroy()
    {
        NoteController.OnNoteHit -= Animate;
    }

    private void Animate()
    {
        if (!_animating)
        {
            _animationStartPoint = _animationEndPoint;
        }

        _animationEndPoint += 1f / (NoteCount - _leniency);

        if (!_animating)
        {
            Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (!_animating)
        //    {
        //        _animationStartPoint = _animationEndPoint;
        //    }

        //    _animationEndPoint += 0.05f; // hardcode 5% progress when spacebar is pressed

        //    if (!_animating)
        //    {
        //        Play();
        //    }
        //}

        if (_animating)
        {
            _elapsedTime += Time.deltaTime;

            _spriteRenderer.color = Color.Lerp(
                _backgroundColorGradient.Evaluate(_animationStartPoint),
                _backgroundColorGradient.Evaluate(_animationEndPoint),
                _elapsedTime / _lerpDuration);

            _bardSprite.color = Color.Lerp(
                _bardGradient.Evaluate(_animationStartPoint),
                _bardGradient.Evaluate(_animationEndPoint),
                _elapsedTime / _lerpDuration);

            if (_elapsedTime >= _lerpDuration)
            {
                Stop();
            }
        }

    }
}
