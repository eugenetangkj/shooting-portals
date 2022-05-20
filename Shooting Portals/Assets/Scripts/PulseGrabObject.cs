using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseGrabObject : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform grabDetect;
    [SerializeField] private float rayDistance = 0.5f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDistance);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Moveable Object") 
        {
            if (Input.GetKey(KeyCode.R))
            {
                grabCheck.collider.gameObject.transform.parent = grabPoint;
                grabCheck.collider.gameObject.transform.position = grabPoint.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else 
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

}
