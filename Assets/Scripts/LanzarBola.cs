using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class LanzarBola : MonoBehaviour
{
    bool dragging = false;
    float distance;
    public float throwSpeed;
    public float archSpeed;
    public float speed;
    Camera mainCamera;
    Rigidbody rb;
    public GameObject objectToThrow;
    public bool hasBeenThrown;
    public int objNumber;
    Maps mapa;

    private void Start()
    {
        mapa = GameObject.Find("Map").GetComponent<Maps>();
         rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main ;
    }

    private void Update()
    {
        if(dragging)
        {
            var touchPosition = Pointer.current.position.ReadValue();
            Ray ray = mainCamera.ScreenPointToRay(touchPosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = Vector3.Lerp(this.transform.position, rayPoint, speed * Time.deltaTime);
        }

        if(transform.position.y < -10)
        {
            rb.useGravity = false;
            GameObject map = GameObject.Find("Map");
            map.GetComponent<Maps>().ChangeTurn();
            Destroy(gameObject);
        }

    }
    public void Touch(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if(!hasBeenThrown)
            {
                distance = Vector3.Distance(transform.position, mainCamera.transform.position);
                dragging = true;
            }

        }
        if (callbackContext.canceled)
        {
            dragging = false;
            hasBeenThrown = true;
            transform.SetParent(null);
            rb.useGravity = true;
            rb.velocity += transform.forward * throwSpeed;
            rb.velocity += transform.up * archSpeed;
            Destroy(gameObject.GetComponent<PlayerInput>());

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {

            mapa.ChangeTurn();
            Destroy(gameObject);
        }
    }


}