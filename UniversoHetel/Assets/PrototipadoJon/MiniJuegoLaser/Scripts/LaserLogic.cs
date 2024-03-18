using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    [SerializeField] private int dist;
    [SerializeField] private String reftag;
    [SerializeField] private int maxReflections;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        laserRenderer.enabled = Input.GetKey(KeyCode.Space);
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyUp(KeyCode.Space))
        {
            DrawLaser();
        }
    }

    void DrawLaser()
    {
        /*
        _verti = 1;
        _iactive = true;
        _currot = transform.forward;
        _curpos = transform.position;
        _lr.SetVertexCount(1);
        _lr.SetPosition(0, transform.position);
        
        while (_iactive)
        {
            _verti++;
            RaycastHit hit;
            _lr.SetVertexCount(_verti);
            if (Physics.Raycast(_curpos, _currot, out hit))
            {
                _curpos = hit.point;
                _currot = Vector3.Reflect(_currot, hit.normal);
                _lr.SetPosition(_verti - 1, hit.point);
                if (hit.transform.gameObject.CompareTag(reftag))
                {
                    _iactive = false;
                }
            }
            else
            {
                _iactive = false;
                _lr.SetPosition(_verti-1,_curpos+100*_currot);
            }

            if (_verti > _limit)
            {
                _iactive = false;
            }
        }
        */
        int laserReflected = 1; //How many times it got reflected
        int vertexCounter = 1; //How many line segments are there
        bool loopActive = true; //Is the reflecting loop active?
        Vector2 laserDirection = transform.up; //direction of the next laser
        Vector2 lastLaserPosition = transform.position; //origin of the next laser
 
        laserRenderer.SetVertexCount(1);
        laserRenderer.SetPosition(0, transform.position);
 
        while (loopActive) {
            RaycastHit2D hit = Physics2D.Raycast(lastLaserPosition, laserDirection, laserDistance);
 
            if (hit) {
                laserReflected++;
                vertexCounter += 3;
                laserRenderer.SetVertexCount (vertexCounter);
                laserRenderer.SetPosition (vertexCounter-3, Vector3.MoveTowards(hit.point, lastLaserPosition, 0.01f));
                laserRenderer.SetPosition(vertexCounter-2, hit.point);
                laserRenderer.SetPosition(vertexCounter-1, hit.point);
                lastLaserPosition = hit.point;
                laserDirection = Vector3.Reflect(laserDirection, hit.normal);
            } else {
                laserReflected++;
                vertexCounter++;
                laserRenderer.SetVertexCount (vertexCounter);
                laserRenderer.SetPosition (vertexCounter - 1, lastLaserPosition + (laserDirection.normalized * laserDistance));
 
                loopActive = false;
            }
            if (laserReflected > laserLimit)
                loopActive = false;
        }
    }
}
