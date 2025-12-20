using UnityEngine;

public class PickableObject : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform holdPoint)
    {
        rb.isKinematic = true;
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
    }

    public void Drop()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
    }
}
