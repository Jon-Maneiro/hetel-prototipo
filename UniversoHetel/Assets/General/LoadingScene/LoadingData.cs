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
    public static Vector3 shipPosition = Vector3.zero; //Ship's position in last Scene
    public static Quaternion shipRotation = Quaternion.identity;//Ship's rotation in last Scene
    public static Vector3 shipScale;//Currently Unused - Ship's scale in last Scene
    
    
    
    //SpaceMinigameList
    public static string[] AsteroidMinigameList =
    {
        "MinijuegoAsteroides1"
    };
    
    
    //PlanetEnumeration
}
