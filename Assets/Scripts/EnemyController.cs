using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public int damage;
    public float changeTime;
    public float patrolType; // 0 for L shape, 1 for square
    public float patrolDistance; // Distance to move in each direction before changing direction
    private float timer;
    private int patrolPhase = 0; // 0: right L, 1: up L, 2: left L, 3: down L
    Rigidbody2D rigidbody2D;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(player != null)
        {
            player.ChangeHealth(-damage);
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
            if(patrolType == 0){
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
            }
            else if(patrolType == 1) //Patrol following a square shape
            {
                patrolPhase = (patrolPhase + 1) % 4;
            }
            timer = changeTime;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        switch (patrolPhase)
        {
            case 0: // Move right (x+)
                position.x += speed * Time.deltaTime + patrolDistance;
                break;
            case 1: // Move up (y+)
                position.y += speed * Time.deltaTime + patrolDistance;
                break;
            case 2: // Move left (x-)
                position.x -= speed * Time.deltaTime + patrolDistance;
                break;
            case 3: // Move down (y-)
                position.y -= speed * Time.deltaTime + patrolDistance;
                break;
        }
        rigidbody2D.MovePosition(position);
    }
}