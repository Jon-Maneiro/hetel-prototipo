using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeLoop : MonoBehaviour
{
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private Mesh _skinnedMesh;
    private int blendShapeCount;

    private int playIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        _skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShapeCount = _skinnedMesh.blendShapeCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (playIndex > 0) _skinnedMeshRenderer.SetBlendShapeWeight(playIndex-1, 0f);
        if (playIndex == 0) _skinnedMeshRenderer.SetBlendShapeWeight(blendShapeCount, 0f);
        _skinnedMeshRenderer.SetBlendShapeWeight(playIndex, 100f);
        playIndex++;
        if (playIndex > blendShapeCount - 1) playIndex = 0;
    }
}
