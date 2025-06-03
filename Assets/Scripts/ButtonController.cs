using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    public Sprite defaultImage;
    public Sprite pressedImage;
    [SerializeField] private InputAction input;
    //[SerializeField] private string test;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        //input.InputSystem.actions.FindAction(test);
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        if(input.WasPressedThisFrame() && input.IsPressed())
        {
            changeSprite(pressedImage);
        }
        else if(input.WasReleasedThisFrame())
        {
            changeSprite(defaultImage);
        }
    }

    void changeSprite(Sprite image)
    {
        spriteRend.sprite = image;
    }
}
