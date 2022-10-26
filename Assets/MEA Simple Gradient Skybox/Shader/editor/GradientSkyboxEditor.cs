using UnityEngine;
using UnityEditor;
using System;

public class GradientSkyboxEditor : ShaderGUI
{

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
    {
        if (RenderSettings.skybox == materialEditor.target)
        {
            RenderSettings.fogColor = RenderSettings.skybox.GetColor("_FogColor");
        }
       
        base.OnGUI(materialEditor, props);
        Material targetMat = materialEditor.target as Material;

    }
}
