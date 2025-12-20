using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPoint;
    public float pickUpRange = 1.5f;

    PickableObject carriedObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (carriedObject == null)
                TryPickUp();
            else
                Drop();
        }
    }

    void TryPickUp()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            pickUpRange
        );

        foreach (Collider hit in hits)
        {
            PickableObject obj = hit.GetComponent<PickableObject>();
            if (obj != null)
            {
                carriedObject = obj;
                obj.PickUp(holdPoint);
                break;
            }
        }
    }

    void Drop()
    {
        carriedObject.Drop();
        carriedObject = null;
    }
}
