using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public enum ShipType { REDSHIP, BLUESHIP, PURPLESHIP }

    private ShipType myType;
    private FlameController myFlame;
    private ShipBodyController myBody;
    // Start is called before the first frame update
    void Start()
    {
        SetShipType();
        myFlame = GetComponentInChildren<FlameController>();
        myBody = GetComponentInChildren<ShipBodyController>();
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deactivate()
    {
        // need to change state of ship
        myFlame.SetGreyFlames(true);
        myBody.SetGreyShip(true);
    }
}
