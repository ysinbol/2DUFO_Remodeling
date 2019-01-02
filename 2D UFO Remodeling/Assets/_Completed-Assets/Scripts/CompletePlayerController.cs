using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletePlayerController : MonoBehaviour {

	public float speed;				//Floating point variable to store the player's movement speed.
	public Text winText;            //Store a reference to the UI Text component which will display the 'You win' message.
    public Text gameOverText;
    public GameObject lifeObj;
    public GameObject fadeObj;
    [SerializeField]
    private GameObject audioSourseObj;

	private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Life life;
    private FadeScript fade;
    private DamegeBlinker blinker;
    [SerializeField]
    private AudioClip damage;
    private float rotateSpeed = 10;
	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

		//Initialze winText to a blank string since we haven't won yet at beginning.
		winText.text = "";

        life = lifeObj.GetComponent<Life>();
        fade = fadeObj.GetComponent<FadeScript>();
        
        gameOverText.enabled = false;

        blinker = new DamegeBlinker(GetComponent<SpriteRenderer>());
        
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);

        if (life.IsDead())
        {
            gameOverText.enabled = true;
        }

        if(fade.IsFinishFadeOut())
        {
            SceneManager.LoadScene("Title");
        }
        FadeOut();
        blinker.BlinkUpdate();
    }

    bool isGoal = false;
    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other) 
	{
        if(other.gameObject.name.Equals("GOAL"))
        {
            winText.text = "GOAL!";
            fade.FadeOut();
            isGoal = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            audioSourseObj.GetComponent<AudioSource>().PlayOneShot(damage);
            blinker.BlinkStart();
            life.ReduceHp();
            Destroy(collision.gameObject);
        }
    }

    void FadeOut()
    {
        if(gameOverText.enabled || isGoal)
        {
            fade.FadeOut();
        }
    }
}
