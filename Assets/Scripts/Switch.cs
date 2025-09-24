using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Sprite offSprite;
    [SerializeField] Sprite onSprite;
    [SerializeField] string[] activatorTags = { "Player", "Pushable" }; // những đối tượng có thể bật công tắc
    [SerializeField] Door connectedDoor; // tham chiếu đến cửa cần mở

    private SpriteRenderer spriteRenderer;
    private bool isOn = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = offSprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (CanActivate(other.tag))
        {
            TurnOn();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (CanActivate(other.tag))
        {
            TurnOff();
        }
    }

    void TurnOn()
    {
        isOn = true;
        spriteRenderer.sprite = onSprite;
        Debug.Log("Switch ON");
        // TODO: gọi event để mở cửa / kích hoạt trap...
        if (connectedDoor != null)
        {
            connectedDoor.OpenDoor(); // gọi hàm mở cửa
        }
    }

    void TurnOff()
    {
        isOn = false;
        spriteRenderer.sprite = offSprite;
        Debug.Log("Switch OFF");
        if (connectedDoor != null)
        {
            connectedDoor.CloseDoor(); // gọi hàm đóng cửa (nếu bạn muốn)
        }
    }

    bool CanActivate(string tag)
    {
        foreach (var t in activatorTags)
        {
            if (tag == t) return true;
        }
        return false;
    }
}
