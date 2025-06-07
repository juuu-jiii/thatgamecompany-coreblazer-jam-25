using UnityEngine;

public class TextBobber : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _amplitudeModifier;
    [SerializeField] private float _periodModifier;
    private Vector3 _initialPosition;
    private float _elapsedTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialPosition = _rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _rectTransform.position = new Vector3(
            _initialPosition.x,
            _initialPosition.y + Mathf.Sin(_elapsedTime * _periodModifier) * _amplitudeModifier,
            _initialPosition.z);

        _elapsedTime += Time.deltaTime;

        _elapsedTime %= Mathf.PI * 2;
    }
}
