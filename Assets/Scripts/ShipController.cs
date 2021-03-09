using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipController : MonoBehaviour
{
    public enum ShipType { REDSHIP, BLUESHIP, PURPLESHIP }

    private ShipType myType;
    private FlameController myFlame;
    private ShipBodyController myBody;
    private ParticleSystemController myLazers;
    bool isActive;
    
    // Start is called before the first frame update
    void Start()
    {
        SetShipType();
        myFlame = GetComponentInChildren<FlameController>();
        myBody = GetComponentInChildren<ShipBodyController>();
        myLazers = GetComponentInChildren<ParticleSystemController>();
        isActive = true;
        myLazers.Deactivate();
    }

    void SetShipType()
    {
        if (name.Contains("Red"))
        {
            myType = ShipType.REDSHIP;
        }
        if (name.Contains("Purple"))
        {
            myType = ShipType.PURPLESHIP;
        }
        if (name.Contains("Blue"))
        {
            myType = ShipType.BLUESHIP;
        }
    }

    public ShipType GetShipType() { return myType; }

    public bool IsActive() { return this.isActive; }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    public void Deactivate()
    {
        // need to change state of ship
        isActive = false;
        myFlame.SetGreyFlames(true);
        myBody.SetGreyShip(true);
        myLazers.Deactivate();
    }


    public void Activate()
    {
        isActive = true;
        myFlame.SetGreyFlames(false);
        myBody.SetGreyShip(false);
        //myLazers.Deactivate();
    }

    public void ChangeActiveStatus()
    {
        if (isActive) Deactivate();
        else Activate();

    }

    void Fire()
    {
        if (isActive)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                myLazers.Activate();
            }
            if (CrossPlatformInputManager.GetButtonUp("Fire1"))
            {
                myLazers.Deactivate();
            }
        }
    }
}
