using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudScript : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public static int Score =0;
   
    private EdgeCollider2D edgeCollider2D;
    public Text ScoreText;
    private GameObject ScoreTextGO;



    // Start is called before the first frame update
    void Start()
    {
        edgeCollider2D = gameObject.GetComponent<EdgeCollider2D>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

      ScoreTextGO = GameObject.Find("ScoreText");
     ScoreText = ScoreTextGO.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.x < screenBounds.x * -1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Score++;
        ScoreText.text = Score.ToString();
        edgeCollider2D.enabled = false;
    }

   

}
