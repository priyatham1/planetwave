using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
    
{
    public float moveSpeed = 7f;
    public SpriteRenderer spriteRenderer;
    public Sprite flyingAstroSprite;
    public Sprite idleAstroSprite;
    private Vector2 screenBounds;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < (screenBounds.y * -1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

       // rb.AddForce(Vector3.MoveTowards(rb.position, target, speed * Time.deltaTime));

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            spriteRenderer.sprite = flyingAstroSprite;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, moveSpeed), ForceMode2D.Impulse);

        }
    }

    // called when the astro hits an obstacle
    void OnCollisionEnter2D(Collision2D col)
    {
        spriteRenderer.sprite = idleAstroSprite;

    }

}
