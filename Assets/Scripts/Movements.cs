using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    [SerializeField] float mainThrust = 800;
    [SerializeField] float rotationThrust = 100;
    Rigidbody rb;
    AudioSource audoSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audoSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if(!audoSource.isPlaying)
            {
                audoSource.Play();
            }
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else
        {
            audoSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RotateElement(-rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RotateElement(rotationThrust);
        }
    }

    void RotateElement(float rotationThrustFactor)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThrustFactor * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
