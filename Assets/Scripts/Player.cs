using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name { get; private set; }
    public Vector3 location;
    //{ get; private set; }
    private GameObject parent;
    private Area currentArea;
    private int id;

    public Player(string name, Vector3 location, int id)
    {
        this.name = name;
        this.location = location;
        this.id = id;
    }

    public void updateLocation(Vector3 newLocation) {
        location = newLocation;
    }

    public Vector3 getLocation() {
        return location;
    }

    public void setLocation(Vector3 location) {
        this.location = location;
    }

    public string getName() {
        return name;
    }

    public void setParent(GameObject parent) {
        this.parent = parent;
    }

    public GameObject getParent() {
        return parent;
    }

    public Area getArea()  {
        return currentArea;
    }

    public void setArea(Area area) {
        this.currentArea = area;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
}