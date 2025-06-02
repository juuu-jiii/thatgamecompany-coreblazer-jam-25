using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{

    private SpriteRenderer sr;

    private void Start()
    {
        transform.position = Vector3.zero;

        sr = GetComponent<SpriteRenderer>();

        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(
            worldScreenWidth / sr.sprite.bounds.size.x,
            worldScreenHeight / sr.sprite.bounds.size.y, 1);
    }
}
