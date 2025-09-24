using UnityEngine;
using UnityEngine.Rendering; // cần cho SortingGroup

public class Door : MonoBehaviour
{
    [SerializeField] float openHeight = 3f;          // cửa mở lên cao bao nhiêu
    [SerializeField] float moveSpeed = 2f;           // tốc độ mở cửa
    [SerializeField] string openedLayerName = "OpenedDoor"; // Layer vật lý khi mở
    [SerializeField] string openedSortingLayer = "DayXH";   // Sorting Layer khi mở
    [SerializeField] int openedSortingOrder = -1;    // Order khi mở (đặt thấp hơn background)

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool shouldOpen = false;

    private int defaultLayer;
    private int openedLayer;

    private string defaultSortingLayer;
    private int defaultSortingOrder;

    private SortingGroup sortingGroup;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * openHeight;

        defaultLayer = gameObject.layer;
        openedLayer = LayerMask.NameToLayer(openedLayerName);

        sortingGroup = GetComponent<SortingGroup>();
        if (sortingGroup != null)
        {
            defaultSortingLayer = sortingGroup.sortingLayerName;
            defaultSortingOrder = sortingGroup.sortingOrder;
        }
    }

    void Update()
    {
        Vector3 target = shouldOpen ? openPosition : closedPosition;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        // khi mở xong thì đổi layer + sorting layer
        if (shouldOpen && Vector3.Distance(transform.position, openPosition) < 0.01f)
        {
            gameObject.layer = openedLayer;

            if (sortingGroup != null)
            {
                sortingGroup.sortingLayerName = openedSortingLayer;
                sortingGroup.sortingOrder = openedSortingOrder;
            }
        }
        else if (!shouldOpen)
        {
            gameObject.layer = defaultLayer;

            if (sortingGroup != null)
            {
                sortingGroup.sortingLayerName = defaultSortingLayer;
                sortingGroup.sortingOrder = defaultSortingOrder;
            }
        }
    }

    public void OpenDoor() => shouldOpen = true;

    public void CloseDoor() => shouldOpen = false;
}
