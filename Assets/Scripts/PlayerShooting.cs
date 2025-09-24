using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float shootCooldown = 0.5f;

    Animator myAnimator;
    float nextFireTime = 0f;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            // Chỉ gọi animation Attack
            myAnimator.SetTrigger("Attack");
            nextFireTime = Time.time + shootCooldown;
        }
    }

    // Hàm này sẽ được gọi ở Animation Event trong clip Attack
    void FireArrow()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
