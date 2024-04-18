using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlanetSceneInitialization : MonoBehaviour
{
    
    /*
     READ READ READ READ READ READ READ READ READ READ READ READ READ READ READ READ READ READ READ READ READ READ READ
     For this script to work there needs to be certain prefabs in scene
     -MainCamera (Nave)
     -VirtualCamera (Nave)
     -PlayerInput(Nave)
     -Portal(CommonAssets)
     
     And certain variables NEED to be assigned
     -Reference to playerShip 
     -Reference to in Scene portal
     */

    [SerializeField] private GameObject portalObject;

    [SerializeField] private GameObject playerShipPrefab;
    private GameObject _playerShipInstance;
    private Vector3 _shipPosition = new Vector3(2000,2000,2000);
    private bool _returningFromMenu = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //Saves the current scene into memory so it can be accessed if necessary
        //I.E. When returning from PlanetSelectionScreen or if minigame fails
        LoadingData.CurrentScene = SceneManager.GetActiveScene().name;

        if (LoadingData.MinigameWon == false)
        {
            LoadingData.MinigameWon = true;
            _shipPosition = portalObject.transform.position;
            _shipPosition.x -= 100;
        }
        else
        if (LoadingData.ShipPosition != Vector3.zero)
        {
            _shipPosition = LoadingData.ShipPosition;
            _returningFromMenu = true;
        }
        
        InstantiateShip();

        if (LoadingData.CreatePortal)
        {
            portalObject.SetActive(true);
            LoadingData.CreatePortal = false;
        }
    }
    
    private void InstantiateShip()
    {
        _playerShipInstance = Instantiate(playerShipPrefab, _shipPosition, Quaternion.identity);
        if (_returningFromMenu)
        {
            _returningFromMenu = false;
            _playerShipInstance.transform.rotation = LoadingData.ShipRotation;
        }
        GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().Follow = _playerShipInstance.transform;
        GameObject.Find("PlayerInput").GetComponent<PlayerInput>().shipMovement = _playerShipInstance.GetComponent<ShipMovement>();
    }

    private void resetData()
    {
        LoadingData.ShipPosition = Vector3.zero;
        LoadingData.ShipRotation = Quaternion.identity;
        LoadingData.ShipScale = Vector3.one;
    }
}
