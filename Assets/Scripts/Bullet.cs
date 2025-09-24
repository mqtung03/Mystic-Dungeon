using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] AudioClip enemyKillSFX;   // 🔹 Âm thanh khi kill enemy
    [SerializeField] [Range(0f, 1f)] float sfxVolume = 0.5f;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        xSpeed = Mathf.Sign(player.transform.localScale.x) * bulletSpeed;
        transform.localScale = new Vector3(Mathf.Sign(xSpeed), 1f, 1f);
    }

    void Update()
    {
        myRigidbody.linearVelocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (enemyKillSFX != null)
            {
                AudioSource.PlayClipAtPoint(enemyKillSFX, Camera.main.transform.position, sfxVolume);
            }
            Destroy(other.gameObject);
            
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
