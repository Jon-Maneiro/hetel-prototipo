using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingData
{
    // -- Loading Screen -- 
    public static string SceneToLoad;//The next scene that will be loaded
    
    // -- Planet Selection -- 
    public static string CurrentScene;//Current Scene, scene to return if minigame is lost
    public static string NextPlanet;//Planet to which travel is planned
    public static readonly string PlanetSelection = "SeleccionPlanetas";//The Planet Selection Screen
    public static bool CreatePortal = false;//Whether the planet scene should create a portal- This should only happen if a planet has been selected
    public static bool MinigameWon = true;
    public static string NextContinent;//Continent to which travel is planned;
    
    // -- Return from Planet Selection Scene -- 
    public static Vector3 ShipPosition = Vector3.zero; //Ship's position in last Scene
    public static Quaternion ShipRotation = Quaternion.identity;//Ship's rotation in last Scene
    public static Vector3 ShipScale;//Currently Unused - Ship's scale in last Scene
    
    
    
    // -- SpaceMinigameList --
    public static readonly string[] AsteroidMinigameList =
    {
        "MinijuegoAsteroides1",
        "MinijuegoAsteroides2",
    };
    
    
    // -- PlanetEnumeration --

    public enum Planets
    {
        Digital,
        Maquinas,
        Ciencia,
        Construccion,
        Energia,
        Vida
    }
    
    //Needs to be completed, whenever new planets are added
    public static readonly string[] PlanetScenes =
    {
        "DigitalScene"
    };

}
