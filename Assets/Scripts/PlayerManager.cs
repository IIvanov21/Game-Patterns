using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed=20.0f;
    [SerializeField] private float mouseSensitivity = 120.0f;
    [SerializeField] private bool isMouseLocked = false;
    [SerializeField] private float score = 0;

    private float horizontalInput, verticalInput;
    private Rigidbody rb;
    private Transform cameraTransform;

    static public PlayerManager instance;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MouseState(isMouseLocked);

        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement logic
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right*horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward*verticalInput * speed * Time.deltaTime);

        //Rotation Logic
        float rotation=Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        cameraTransform.Rotate(Vector3.right, (mouseSensitivity * Time.deltaTime * Input.GetAxis("Mouse Y")));
        Vector3 euler = cameraTransform.localEulerAngles;
        float eulerX = euler.x;

        if (eulerX > 180f) eulerX -= 360f;
        eulerX = Mathf.Clamp(eulerX, -60, 60);

        euler.x = eulerX;
        euler.y = 0;
        euler.z = 0;
        
        cameraTransform.localRotation = Quaternion.Euler(euler);


    }

    void MouseState(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void UpdateScore(float scoreIn)
    {
        score += scoreIn;
    }
}
