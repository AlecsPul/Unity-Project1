using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float changeTime;
    private float timer;
    private int patrolPhase = 0; // 0: right, 1: up, 2: left, 3: down
    Rigidbody2D rigidbody2D;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(player != null)
        {
            player.ChangeHealth(-20);
        }
    }
    void Start()
    {
        timer = changeTime;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            // Patrol following an L shape
            if(patrolPhase == 0){
                patrolPhase = 1;
            }
            else if(patrolPhase == 1){
                patrolPhase = 3;
            }
            else if(patrolPhase == 2){
                patrolPhase = 0;
            }
            else if(patrolPhase == 3){
                patrolPhase = 2;
            }

            //patrolPhase = (patrolPhase + 1) % 4; // This line is for a square patrol
            
            timer = changeTime;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        switch (patrolPhase)
        {
            case 0: // Move right (x+)
                position.x += speed * Time.deltaTime;
                break;
            case 1: // Move up (y+)
                position.y += speed * Time.deltaTime;
                break;
            case 2: // Move left (x-)
                position.x -= speed * Time.deltaTime;
                break;
            case 3: // Move down (y-)
                position.y -= speed * Time.deltaTime;
                break;
        }
        rigidbody2D.MovePosition(position);
    }
}