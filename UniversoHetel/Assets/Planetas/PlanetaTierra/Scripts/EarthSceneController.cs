using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class EarthSceneController : MonoBehaviour
{
    
    /*
     Code can be reused in other planet Scenes
     
        -Portal related code is to Show the portal if a planet is set as destination
        
        -Ship related code handles instantiation of the... ship (o wow)!
        
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
        
        if (LoadingData.shipPosition != Vector3.zero)
        {
            _shipPosition = LoadingData.shipPosition;
            _returningFromMenu = true;
        }
        
        InstantiateShip();

        if (LoadingData.CreatePortal)
        {
            portalObject.SetActive(true);
            LoadingData.CreatePortal = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateShip()
    {
        _playerShipInstance = Instantiate(playerShipPrefab, _shipPosition, Quaternion.identity);
        if (_returningFromMenu)
        {
            _returningFromMenu = false;
            _playerShipInstance.transform.rotation = LoadingData.shipRotation;
        }
        GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().Follow = _playerShipInstance.transform;
        GameObject.Find("PlayerInput").GetComponent<PlayerInput>().shipMovement = _playerShipInstance.GetComponent<ShipMovement>();
    }

    private void resetData()
    {
        LoadingData.shipPosition = Vector3.zero;
        LoadingData.shipRotation = Quaternion.identity;
        LoadingData.shipScale = Vector3.one;
    }
}
