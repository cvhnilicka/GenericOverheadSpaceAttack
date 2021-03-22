﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ShipController purpleShip;
    private ShipController redShip;
    private ShipController blueShip;
    private Rigidbody2D myShipsBody;
    [SerializeField] float flySpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        myShipsBody = GetComponent<Rigidbody2D>();
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
        Rotation();
        Fly();

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


    void Fly()
    {
        float hthrow = Input.GetAxis("Horizontal");
        float vthrow = Input.GetAxis("Vertical");
        Vector2 playerVelocity = new Vector2(hthrow * flySpeed, vthrow * flySpeed);
        myShipsBody.velocity = playerVelocity;
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
