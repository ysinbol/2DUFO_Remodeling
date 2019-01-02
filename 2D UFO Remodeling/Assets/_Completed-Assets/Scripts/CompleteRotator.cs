using UnityEngine;
using System.Collections;

public class CompleteRotator : MonoBehaviour {

    private Rigidbody2D rigidbody2D;
    private Vector2 moveDirection;
    [SerializeField]
    private float speed;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        moveDirection =
            new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));

        moveDirection.Normalize();
        rigidbody2D.AddForce(new Vector2(moveDirection.x, moveDirection.y) * speed,ForceMode2D.Impulse);
    }

    //Update is called every frame
    void Update () 
	{
        transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
	}


}
