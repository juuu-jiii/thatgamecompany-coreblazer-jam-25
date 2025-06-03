using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject prefabNote;
    private GameObject newNote;
    private Transform spawner;
    public Transform transformDown;
    public Transform transformUp;
    public Transform transformLeft;
    public Transform transformRight;
    private int position = 0;

    void Start()
    {
        spawner = this.gameObject.transform;
    }

    public void SpawnNote()
    {
        newNote = Instantiate(prefabNote, randomTransform());
        NoteController button = (NoteController) newNote.GetComponent(typeof(NoteController));
        button.currentButton(position);
    }

    public Transform randomTransform()
    {
        position = Random.Range(0, 4);

        switch(position)
        {
            case 0:
                return transformDown;
            case 1:
                return transformUp;
            case 2:
                return transformLeft;
            case 3:
                return transformRight;
            default:
                print("Unable to Spawn Correct Note Transform");
                return spawner;
        }
    }
}
