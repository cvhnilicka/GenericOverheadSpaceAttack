using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipMovementController : MonoBehaviour
{

    // cached components for the ship object
    private Rigidbody2D shipBody;

    [SerializeField] float flySpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        if (!ValidateShipBody())
        {
            Debug.Log("ShipBody Validation Failure");
        }
    }

    bool ValidateShipBody()
    {

        foreach (Transform child in transform)
        {
            if (child.gameObject.name.Contains("Body"))
            {
                if (child.TryGetComponent<Rigidbody2D>(out shipBody))
                {
                    return true;
                }
            }
        }
        return false; 
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    void Fly()
    {
        float hthrow = Input.GetAxis("Horizontal");
        float vthrow = Input.GetAxis("Vertical");
        Vector2 playerVelocity = new Vector2(hthrow * flySpeed, vthrow*flySpeed);
        shipBody.velocity = playerVelocity;
    }
}
