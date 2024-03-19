using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    [SerializeField] private int dist;
    [SerializeField] private String reftag;
    [SerializeField] private int maxReflections;
    [SerializeField] private Transform startPoint;
    [SerializeField] private bool reflectOnlyMirror;
    
    private int _verti = 1;
    private bool _iactive;
    private Vector3 _currot;
    private Vector3 _curpos;
    private LineRenderer _lr;
    private int _limit = 100;
    
    public int laserDistance = 100; //max raycasting distance
    public int laserLimit = 10; //the laser can be reflected this many times
    public LineRenderer laserRenderer; //the line renderer
    
    
    // Start is called before the first frame update
    void Start()
    {
        _lr = laserRenderer;
        
        _lr.SetPosition(0, startPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        DrawLaser();
    }
    
    void DrawLaser()
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
            } else {
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
