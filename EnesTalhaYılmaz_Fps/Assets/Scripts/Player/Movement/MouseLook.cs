using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] int mouseSensitivity=100;
    [SerializeField] Transform playerBody;
    [SerializeField] LayerMask mouseColliderLayerMask;
    [SerializeField] Transform debugItem;
    [SerializeField] Transform BuildItemPreview;
    float xRotation=0f;
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }
    void Update()
    {
        LookAround();
        // Vector3 worldPosition = GetMouseworldPosition();
        // Instantiate(debugItem,worldPosition,Quaternion.identity);
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, +90);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private Vector3 GetMouseworldPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderLayerMask)) {
            if(raycastHit.transform.tag=="Side"){
                BuildItemPreview.position=raycastHit.transform.position;
            }
            return raycastHit.point;
        }
        else 
        {
        return Vector3.zero;
        }
    }
}
