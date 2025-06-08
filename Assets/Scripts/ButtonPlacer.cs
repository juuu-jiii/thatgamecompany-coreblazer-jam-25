using UnityEngine;
//using UnityEngine.UI;

public class ButtonPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _sceneReference;
    [SerializeField] private RectTransform _buttonRectTransform;
    //[SerializeField] private Button _button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParticleSystem ps = _sceneReference.GetComponent<ParticleSystem>();
        Bounds psBounds = ps.GetComponent<ParticleSystemRenderer>().bounds;

        // Get lower left and upper right corners of particle system bounds
        Vector3 psBoundsMin = psBounds.min;
        Vector3 psBoundsMax = psBounds.max;

        // Transform those corners from world to screen space
        Vector3 buttonBoundsMin = Camera.main.WorldToScreenPoint(psBoundsMin);
        Vector3 buttonBoundsMax = Camera.main.WorldToScreenPoint(psBoundsMax);


        //_buttonRectTransform.sizeDelta = new Vector2(
        //    psBounds.ex
        //    psBounds.size.y);
        
        Debug.Log("psBounds extents are " + psBounds.extents);
        _buttonRectTransform.position = Camera.main.WorldToScreenPoint(_sceneReference.transform.position);
        _buttonRectTransform.sizeDelta = buttonBoundsMax - buttonBoundsMin;
        //Camera.main.WorldToScreenPoint
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
