using UnityEngine;
using Photon.Pun;
public class SimpleMove : MonoBehaviourPunCallbacks
{
    public float velocity = 5;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float VerticalMovement = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(VerticalMovement, 0, horizontalMovement) * velocity * Time.deltaTime;
            transform.Translate(move);
        }
    }
}
