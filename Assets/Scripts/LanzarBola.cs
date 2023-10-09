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
    ObjectsToPlane manager;
    public GameObject objectToThrow;
    GameObject puntoLanzamiento;

    private void Start()
    {
         rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main ;
        puntoLanzamiento = GameObject.Find("HuecoObjeto");
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
            GameObject nuevaPelota = Instantiate(objectToThrow, puntoLanzamiento.transform.transform.transform.position, puntoLanzamiento.transform.rotation, puntoLanzamiento.transform);
            Destroy(gameObject);
        }
    }
    public void Touch(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            distance = Vector3.Distance(transform.position, mainCamera.transform.position);
            dragging = true;
        }
        if (callbackContext.canceled)
        {
            transform.SetParent(null);
            rb.useGravity = true;
            rb.velocity += transform.forward * throwSpeed;
            rb.velocity += transform.up * archSpeed;
            dragging = false;
        }
    }


}