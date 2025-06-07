using UnityEngine;

public class AlternatePulse : MonoBehaviour
{
    [SerializeField] private float pulseSize = 1.15f;
    [SerializeField] private float returnSpeed = 5f;
    private Vector3 startSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        StartSize();
    }

    public void Pulse()
    {
        transform.localScale = startSize * pulseSize;
    }

    void StartSize()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, startSize, Time.deltaTime * returnSpeed);
    }
}
