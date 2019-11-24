using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]

public class ShadowThresholdCustomEffect : MonoBehaviour
{
    public Material shadowMaterial;
    private Camera cam;


    [Range(0, 1)]
    public float shadowThreshold;
    [Range(0, 1)]
    public float shadowThreshold2;
    [Range(0, 1)]
    public float shadowThreshold3;
    [Range(0, 1)]
    public float shadowThreshold4;
    //[Range(0, 5)]
    //public float Depth_Outline_Multiplier;
    //[Range(1, 4)]
    //public float Depth_Outline_Bias;
    //[Range(0, 5)]
    //public float Normal_Outline_Multiplier;
    //[Range(1, 4)]
    //public float Normal_Outline_Bias;
    //[Range(0, 20)]
    //public float Outline_Wide;
    [Range(0, 1)]
    public float WhiteLevel;
    [Range(0, 1)]
    public float WhiteLevel2;
    [Range(0, 10)]
    public float Redch;
    [Range(0, 10)]
    public float Greench;
    [Range(0, 10)]
    public float Bluech;
    [Range(0.1f, 10)]
    public float glipower;//1~10
    [Range(1, 100)]
    public float GlitchflowSpeed;
    [Range(0.1f, 5)]
    public float glitchuv;//0.1~5
    public bool zero;//0-1
    public bool outlineonoff;

    public void GlitchTextureChange(Texture glitchTexture)
    {
        shadowMaterial.SetTexture("_MainTex6", glitchTexture);
    }

    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.DepthNormals;
    }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        shadowMaterial.SetFloat("_ShadowThreshold", shadowThreshold);
        shadowMaterial.SetFloat("_ShadowThreshold2", shadowThreshold2);
        shadowMaterial.SetFloat("_ShadowThreshold3", shadowThreshold3);
        shadowMaterial.SetFloat("_ShadowThreshold4", shadowThreshold4);
        //shadowMaterial.SetFloat("_DepthMul", Depth_Outline_Multiplier);
        //shadowMaterial.SetFloat("_DepthPow", Depth_Outline_Bias);
        //shadowMaterial.SetFloat("_NormalMul", Normal_Outline_Multiplier);
        //shadowMaterial.SetFloat("_NormalPow", Normal_Outline_Bias);
        //shadowMaterial.SetFloat("_OutlineWide", Outline_Wide);
        shadowMaterial.SetFloat("_WhiteLevel", WhiteLevel);
        shadowMaterial.SetFloat("_WhiteLevel2", WhiteLevel2);
        shadowMaterial.SetFloat("_Redch", Redch);
        shadowMaterial.SetFloat("_Greench", Greench);
        shadowMaterial.SetFloat("_Bluech", Bluech);
        shadowMaterial.SetFloat("_glipower", glipower);
        shadowMaterial.SetFloat("_GlitchflowSpeed", GlitchflowSpeed);
        shadowMaterial.SetFloat("_glitchuv", glitchuv);
        if (zero == true)
        {
            shadowMaterial.SetFloat("_zero", 1);
        }
        else
        {
            shadowMaterial.SetFloat("_zero", 0);
        }

        if (outlineonoff == true)
        {
            shadowMaterial.SetFloat("_outlineonoff", 0);
        }
        else
        {
            shadowMaterial.SetFloat("_outlineonoff", 1);
        }

        Graphics.Blit(source, destination, shadowMaterial);
    }
}