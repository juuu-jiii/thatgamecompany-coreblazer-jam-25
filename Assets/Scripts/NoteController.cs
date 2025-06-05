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
    public GameObject noteHit;
    public GameObject noteMissed;
    private GameObject note;

    public delegate void NoteHitSuccessDelegate();
    public static event NoteHitSuccessDelegate OnNoteHit;
    
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
        if (other.tag == tag)
        {
            canBePressed = true;
        }
        else
        {
            print("Miss");
            GameObject noteMissedGameObject = Instantiate(noteMissed);
            ParticleSystem noteMissedParticleSystem = noteMissedGameObject.GetComponent<ParticleSystem>();
            noteMissedGameObject.transform.position = transform.position;
            noteMissedParticleSystem.Play();
            Destroy(note);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == tag)
        {
            canBePressed = false;
        }
        else
        {
            print("Miss");
            GameObject noteMissedGameObject = Instantiate(noteMissed);
            ParticleSystem noteMissedParticleSystem = noteMissedGameObject.GetComponent<ParticleSystem>();
            noteMissedGameObject.transform.position = transform.position;
            noteMissedParticleSystem.Play();
            Destroy(note);
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
                    print("Success");
                    GameObject noteHitGameObject = Instantiate(noteHit);
                    ParticleSystem noteHitParticleSystem = noteHitGameObject.GetComponent<ParticleSystem>();
                    noteHitGameObject.transform.position = transform.position;
                    noteHitParticleSystem.Play();
                    Destroy(note);
                    OnNoteHit?.Invoke();
                }
                else if (inputUp.IsPressed() && buttonUp)
                {
                    print("Success");
                    GameObject noteHitGameObject = Instantiate(noteHit);
                    ParticleSystem noteHitParticleSystem = noteHitGameObject.GetComponent<ParticleSystem>();
                    noteHitGameObject.transform.position = transform.position;
                    noteHitParticleSystem.Play();
                    Destroy(note);
                    OnNoteHit?.Invoke();
                }
                else if (inputRight.IsPressed() && buttonRight)
                {
                    print("Success");
                    GameObject noteHitGameObject = Instantiate(noteHit);
                    ParticleSystem noteHitParticleSystem = noteHitGameObject.GetComponent<ParticleSystem>();
                    noteHitGameObject.transform.position = transform.position;
                    noteHitParticleSystem.Play();
                    Destroy(note);
                    OnNoteHit?.Invoke();
                }
                else if (inputLeft.IsPressed() && buttonLeft)
                {
                    print("Success");
                    GameObject noteHitGameObject = Instantiate(noteHit);
                    ParticleSystem noteHitParticleSystem = noteHitGameObject.GetComponent<ParticleSystem>();
                    noteHitGameObject.transform.position = transform.position;
                    noteHitParticleSystem.Play();
                    Destroy(note);
                    OnNoteHit?.Invoke();
                }
            }
        }
    }

    public void currentButton(int position)
    {
        switch(position)
        {
            case 0:
                tag = "Down";
                moveUp = 1;
                buttonDown = true;
                break;
            case 1:
                tag = "Up";
                moveDown = 1;
                buttonUp = true;
                break;
            case 2:
                tag = "Left";
                moveRight = 1;
                buttonLeft = true;
                break;
            case 3:
                tag = "Right";
                moveLeft = 1;
                buttonRight = true;
                break;
            default:
                print("Unable to Set Note's Button");
                break;
        }
    }
}
