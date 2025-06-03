using UnityEngine;
using UnityEngine.InputSystem;

public class NoteController : MonoBehaviour
{
    public float beatTempo;
    public float moveLeft = 0;
    public float moveRight = 0;
    public float moveUp = 0;
    public float moveDown = 0;
    public string tag = "Button";
    public bool canBePressed;
    public InputAction inputDown;
    public InputAction inputUp;
    public InputAction inputLeft;
    public InputAction inputRight;
    public bool buttonDown = false;
    public bool buttonLeft = false;
    public bool buttonRight = false;
    public bool buttonUp = false;
    private GameObject note;
    
    void Start()
    {
        beatTempo = beatTempo / 60f;
        note = this.gameObject;
        //print(this.gameObject);
    }

    void Update()
    {
        NoteInput();
        Movement();
    }

    void Movement()
    {
        transform.position -= new Vector3((moveLeft * beatTempo * Time.deltaTime), (moveDown * beatTempo * Time.deltaTime), 0f);
        transform.position += new Vector3((moveRight * beatTempo * Time.deltaTime), (moveUp * beatTempo * Time.deltaTime), 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == tag)
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == tag)
        {
            canBePressed = false;
        }
    }

    void OnEnable()
    {
        inputDown.Enable();
        inputUp.Enable();
        inputRight.Enable();
        inputLeft.Enable();
    }

    void OnDisable()
    {
        inputDown.Disable();
        inputUp.Disable();
        inputRight.Disable();
        inputLeft.Disable();
    }

    void NoteInput()
    {
        if (canBePressed)
        {
            if (inputDown.WasPressedThisFrame() || inputUp.WasPressedThisFrame() || inputLeft.WasPressedThisFrame() || inputRight.WasPressedThisFrame())
            {
                if (inputDown.IsPressed() && buttonDown)
                {
                    Destroy(note);
                }
                else if (inputUp.IsPressed() && buttonUp)
                {
                    Destroy(note);
                }
                else if (inputRight.IsPressed() && buttonRight)
                {
                    Destroy(note);
                }
                else if (inputLeft.IsPressed() && buttonLeft)
                {
                    Destroy(note);
                }
            }
        }
    }

    public void currentButton(int position)
    {
        switch(position)
        {
            case 0:
                buttonDown = true;
                break;
            case 1:
                buttonUp = true;
                break;
            case 2:
                buttonLeft = true;
                break;
            case 3:
                buttonRight = true;
                break;
            default:
                print("Unable to Set Note's Button");
                break;
        }
    }

}
