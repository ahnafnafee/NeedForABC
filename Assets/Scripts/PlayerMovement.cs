using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _distanceToGround;
    private Vector3 _groundNormal;

    private Rigidbody _rb;

    public float speed = 4;
    public float turnAngle = 70f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //FORWARD MOVEMENT

        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(0, 0, z);

        //TURNING

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnAngle * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnAngle * Time.deltaTime, 0);
        }
        
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            _groundNormal = hit.normal;
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
        transform.rotation = toRotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("PlanetObj"))
        {
            Debug.Log("Collision!");
        }
        
        if (other.collider.CompareTag("Letter"))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.SetActive(false);
            Debug.Log("YOU GOT THE LETTER " + other.gameObject.GetComponent<TextMeshPro>().text);
        }
        
        
        
        
    }
}