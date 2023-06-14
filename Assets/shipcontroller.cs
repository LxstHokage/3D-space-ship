using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipcontroller : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float angularSpeed = 0.5f;
    private ParticleSystem[] particles;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _particles = GetComponentsInChildren<ParticleSystem>();
        foreach (var particle in particles)
        {
            particle.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxis("Vertical"),
              y = Input.GetAxis("Horizontal");
        if (z != 0)
        {
            foreach (var particle in particles)
            {
                particle.gameObject.SetActive(true);
            }
        }
        else if (y < 0)
        {
                var particle = particles[0];
                particle.gameObject.SetActive(true);
        }
        else if (y > 0)
        {
                var particle = particles[1];
                particle.gameObject.SetActive(true);
        }
        else
        {
            foreach (var particle in particles)
            {
                particle.gameObject.SetActive(false);
            }
        }
        _rb.AddRelativeForce(0f,0f,speed * z);
        _rb.AddRelativeTorque(0f, y * angularSpeed, 0f);
    }
}
