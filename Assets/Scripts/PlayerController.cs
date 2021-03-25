using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ShipController purpleShip;
    private ShipController redShip;
    private ShipController blueShip;
    private Rigidbody2D myShipsBody;
    private BoxCollider2D wallColliderTrigger;
    private bool canFly;
    [SerializeField] float flySpeed = 10f;
    [SerializeField] float thrust = 32f;

    private Vector2 maxVelocity = new Vector2(44f, 44f);

    // Start is called before the first frame update
    void Start()
    {
        myShipsBody = GetComponent<Rigidbody2D>();
        wallColliderTrigger = GetComponent<BoxCollider2D>();
        canFly = true;
        GetShips();

    }

    void GetShips()
    {
        foreach (Transform child in transform)
        {
            ShipController[] ships = GetComponentsInChildren<ShipController>();
            foreach (ShipController ship in ships)
            {
                switch(ship.GetShipType())
                {
                    case ShipController.ShipType.BLUESHIP:
                        blueShip = ship;
                        break;
                    case ShipController.ShipType.REDSHIP:
                        redShip = ship;
                        break;
                    case ShipController.ShipType.PURPLESHIP:
                        purpleShip = ship;
                        break;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        ShipAcivationControl();
        //Rotation();
        if (canFly) Fly();
        print("Body Vel: " + myShipsBody.velocity);


    }

    void ShipAcivationControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            purpleShip.ChangeActiveStatus();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            blueShip.ChangeActiveStatus();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            redShip.ChangeActiveStatus();
        }
    }

    // I need to rework flying to be more "in space"
    void Fly()
    {
        float hthrow = Input.GetAxis("Horizontal");
        float vthrow = Input.GetAxis("Vertical");

        Vector2 newThrust = new Vector2(hthrow * thrust, vthrow * thrust);


        // RELATIVE FORCE
        //myShipsBody.AddRelativeForce(newThrust);

        // ADD FORCE
        myShipsBody.AddForce(newThrust);

        // corrections
        VelocityCorrections();






        //Vector2 playerVelocity = new Vector2(hthrow * flySpeed, vthrow * flySpeed);
        //myShipsBody.velocity = playerVelocity;
    }

    private void VelocityCorrections()
    {
        if (myShipsBody.velocity.x > maxVelocity.x)
        {
            myShipsBody.velocity = new Vector2(maxVelocity.x, myShipsBody.velocity.y);
        }
        if (myShipsBody.velocity.y > maxVelocity.y)
        {
            myShipsBody.velocity = new Vector2(myShipsBody.velocity.x, maxVelocity.y);
        }
        if (myShipsBody.velocity.x < -maxVelocity.x)
        {
            myShipsBody.velocity = new Vector2(-maxVelocity.x, myShipsBody.velocity.y);
        }
        if (myShipsBody.velocity.y < -maxVelocity.y)
        {
            myShipsBody.velocity = new Vector2(myShipsBody.velocity.x, -maxVelocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 12 is walls layer
        switch(collision.gameObject.layer)
        {
            case 12: print("Hit wall"); break;
        }
    }



    void Rotation()
    {
        // This seems toooooo touchy. I need to work on a different rotation solution




        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
    }
}
