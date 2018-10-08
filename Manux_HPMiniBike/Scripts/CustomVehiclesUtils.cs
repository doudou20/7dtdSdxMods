﻿using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;



class CustomVehiclesUtils
{
    public static void GetAllChildTransforms(Transform root, ref List<Transform> childrenList, ref List<int> childrenInstanceIds)
    {
        for (int i = 0; i < root.childCount; i++)
        {
            Transform child = root.GetChild(i);
            if (!childrenInstanceIds.Contains(child.GetInstanceID()))
            {
                childrenList.Add(child);
                childrenInstanceIds.Add(child.GetInstanceID());
            }
            GetAllChildTransforms(child, ref childrenList, ref childrenInstanceIds);
        }
    }

    public static bool StringVectorToVector3(string stringVec, out Vector3 newVector3)
    {
        string[] stringVector;
        stringVector = stringVec.Split(',');
        if (stringVector.Length == 3)
        {
            float x;
            float.TryParse(stringVector[0], out x);
            float y;
            float.TryParse(stringVector[1], out y);
            float z;
            float.TryParse(stringVector[2], out z);
            newVector3 = new Vector3(x, y, z);
            return true;
        }
        else
        {
            Debug.LogError("Xml Vector is invalid");
        }
        newVector3 = new Vector3();
        return false;
    }

    public static bool StringVectorToColor(string stringVec, out Color newColor)
    {
        string[] stringVector;
        stringVector = stringVec.Split(',');
        if (stringVector.Length == 3)
        {
            float r;
            float.TryParse(stringVector[0], NumberStyles.Float, CultureInfo.InvariantCulture, out r);
            float g;
            float.TryParse(stringVector[1], NumberStyles.Float, CultureInfo.InvariantCulture, out g);
            float b;
            float.TryParse(stringVector[2], NumberStyles.Float, CultureInfo.InvariantCulture, out b);
            newColor = new Color(r, g, b);
            return true;
        }
        else
        {
            Debug.Log("Xml Mesh Color is invalid");
        }
        newColor = new Color();
        return false;
    }

    public static void ChangeMeshesColor(Color color, Renderer[] renderers)
    {
        foreach (Renderer rend in renderers)
        {
            rend.material.EnableKeyword("_COLOR");
            rend.material.SetColor("_Color", color);
        }
    }

    public static void ChangeMeshesEmissiveColor(Color color, Renderer[] renderers)
    {
        foreach (Renderer rend in renderers)
        {
            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", color);
        }
    }
}

