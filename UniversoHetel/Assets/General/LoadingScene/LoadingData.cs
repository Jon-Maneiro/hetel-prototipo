using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingData
{
    //Loading Screen
    public static string SceneToLoad;//The next scene that will be loaded
    
    //Planet Selection
    public static string CurrentScene;//Current Scene
    public static string NextPlanet;//Planet to which travel is planned
    public static readonly string PlanetSelection = "SeleccionPlanetas";//The Planet Selection Screen
    public static bool CreatePortal = false;//Whether the planet scene should create a portal- This should only happen if a planet has been selected
    
    //Return from Planet Selection Scene
    public static Transform LocationOfShip;
    public static Vector3 shipPosition = Vector3.zero;
    public static Quaternion shipRotation = Quaternion.identity;
    public static Vector3 shipScale;
    
    
    
    //SpaceMinigameList
    public static string[] AsteroidMinigameList =
    {
        "MinijuegoAsteroides1"
    };
}
