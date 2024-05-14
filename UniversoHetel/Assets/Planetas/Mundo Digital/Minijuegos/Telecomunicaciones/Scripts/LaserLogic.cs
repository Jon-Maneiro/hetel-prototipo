using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class LaserLogic : MonoBehaviour
{
    [SerializeField] private String reftag;
    [SerializeField] private String goodtag;
    [SerializeField] private String errortag;
    [SerializeField] private String walltag;
    [SerializeField] private Transform startPoint;
    
    private bool _iactive;
    private Vector3 _currot;
    private Vector3 _curpos;
    private LineRenderer _lr;
    
    public int laserDistance = 100; //max raycasting distance
    public int laserLimit = 10; //the laser can be reflected this many times
    public LineRenderer laserRenderer; //the line renderer

    private LaserControls _laser;
    private bool _toggleLaser = false;

    public static event Action<GameObject> CubeHit;
    
    // Start is called before the first frame update
    void Start()
    {
        _laser = new LaserControls();
        _laser.Enable();
        _laser.Laser.Space.performed += context => ActivateLaser();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ActivateLaser()
    {
        _toggleLaser = !_toggleLaser;
        if (_toggleLaser)
        {
            laserRenderer.enabled = true;
            InvokeRepeating(nameof(DrawLaser),0,0.01f);
        }
        else
        {
            CancelInvoke(nameof(DrawLaser));
            laserRenderer.enabled = false;
        }
    }
    
    private void DrawLaser()
    {
        
        int laserReflected = 1; //How many times it got reflected
        int vertexCounter = 1; //How many line segments are there
        bool loopActive = true; //Is the reflecting loop active?
        Vector3 laserDirection = Vector3.up; //direction of the next laser
        Vector3 lastLaserPosition = transform.position; //origin of the next laser
 
        laserRenderer.positionCount = 1;
        laserRenderer.SetPosition(0, startPoint.position);
 
        while (loopActive)
        {
            RaycastHit hit;
            if (Physics.Raycast(lastLaserPosition, laserDirection,out hit)) {
                if (hit.transform.CompareTag(reftag))
                {
                    laserReflected++;
                    vertexCounter += 3;
                    laserRenderer.positionCount = vertexCounter;
                    laserRenderer.SetPosition(vertexCounter - 3,
                        Vector3.MoveTowards(hit.point, lastLaserPosition, 0.01f));
                    laserRenderer.SetPosition(vertexCounter - 2, hit.point);
                    laserRenderer.SetPosition(vertexCounter - 1, hit.point);
                    lastLaserPosition = hit.point;
                    laserDirection = Vector3.Reflect(laserDirection, hit.normal);
                }

                if (hit.transform.CompareTag(goodtag))
                {
                    Debug.Log("Buen Cubo");
                    CubeHit?.Invoke(hit.transform.gameObject);
                    loopActive = false;
                }

                if (hit.transform.CompareTag(errortag))
                {
                    Debug.Log("Mal Cubo");
                    CubeHit?.Invoke(hit.transform.gameObject);
                    loopActive = false;
                }

                if (hit.transform.CompareTag(walltag))
                {
                    loopActive = false;
                    vertexCounter += 2;
                    laserRenderer.positionCount = vertexCounter;
                    laserRenderer.SetPosition(vertexCounter - 2,
                        Vector3.MoveTowards(hit.point, lastLaserPosition, 0.01f));
                    laserRenderer.SetPosition(vertexCounter - 1, hit.point);
                    lastLaserPosition = hit.point;
                }

            }
            else {
                laserReflected++;
                vertexCounter++;
                laserRenderer.positionCount =  vertexCounter;
                laserRenderer.SetPosition (vertexCounter - 1, lastLaserPosition + (laserDirection.normalized * laserDistance));
 
                loopActive = false;
            }
            if (laserReflected > laserLimit)
                loopActive = false;
        }
        
    }
    
    
}
