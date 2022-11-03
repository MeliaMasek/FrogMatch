using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

//for gameobjects like projectiles 
public class ObjectBehavoir : MonoBehaviour
{
    private Rigidbody rigidbodyObj;
    public float force = 100;
   
    void Awake()
    {
        rigidbodyObj = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        rigidbodyObj.AddForce(Vector3.left * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        rigidbodyObj.Sleep();
        gameObject.SetActive(false);
    }
}
