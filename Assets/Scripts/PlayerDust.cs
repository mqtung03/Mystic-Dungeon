using UnityEngine;

public class PlayerDust : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;
    [SerializeField] Rigidbody2D myRigidbody;

    BoxCollider2D myFeetCollider;   
    void Start()
    {
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        bool isRunning = Mathf.Abs(myRigidbody.linearVelocity.x) > 0.1f;
        //bool isGrounded = true; // TODO: thay bằng check ground thực tế

        if (isRunning && myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !dustEffect.isPlaying)
        {
            dustEffect.Play();
            Debug.Log("Play dust effect");
        }
        else if ((!isRunning || !myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) && dustEffect.isPlaying)
        {
            dustEffect.Stop();
        }
    }
}
