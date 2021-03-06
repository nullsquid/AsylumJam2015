﻿using PigeonCoopToolkit.Navmesh2D;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class NavMesh2D {

    private static NavMesh2DBehaviour _instanceRef;

    private static NavMesh2DBehaviour instance
    {
        get
        {
            if (_instanceRef == null)
            {
                _instanceRef = Object.FindObjectOfType<NavMesh2DBehaviour>();
            }

            return _instanceRef;
        }
    }

    /// <summary>
    /// Returns true if the scene has a NavMesh baked into it.
    /// </summary>
    public static bool SceneHasNavmesh()
    {
        return instance != null;
    }

    /// <summary>
    /// A smoothed path from start to end.
    /// </summary>
    /// <param name="startPosition">The Start position</param>
    /// <param name="endPosition">The End position</param>
    /// <returns>A list of points, order from start to end</returns>
    public static List<Vector2> GetSmoothedPath(Vector2 startPosition, Vector2 endPosition)
    {
        if (instance == null)
        {
            Debug.LogError("NavMesh2D: Scene does not contain a 2D NavMesh");
            return new List<Vector2>();
        }

        List<Vector2> resultingPath = new List<Vector2>(0);

        NavMesh2DNode startMesh2DNode = GetNavMeshObject().ClosestNodeTo(startPosition);
        NavMesh2DNode endMesh2DNode = GetNavMeshObject().ClosestNodeTo(endPosition);
        if (startMesh2DNode != null && endMesh2DNode != null)
        {
            resultingPath = instance.SmoothedVectorPath2D(
                instance.GenerationInformation.ColliderPadding, startPosition, endPosition,
                instance.GetPath(startMesh2DNode, endMesh2DNode)
                );
        }

        return resultingPath;
    }

    /// <summary>
    /// A path from start to end.
    /// </summary>
    /// <param name="startPosition">The Start position</param>
    /// <param name="endPosition">The End position</param>
    /// <returns>A list of points, order from start to end</returns>
    public static List<Vector2> GetPath(Vector2 startPosition, Vector2 endPosition)
    {
        if (instance == null)
        {
            Debug.LogError("NavMesh2D: Scene does not contain a 2D NavMesh");
            return new List<Vector2>();
        }

        List<Vector2> resultingPath = new List<Vector2>();
        resultingPath.Add(startPosition);
        NavMesh2DNode startMesh2DNode = GetNavMeshObject().ClosestNodeTo(startPosition);
        NavMesh2DNode endMesh2DNode = GetNavMeshObject().ClosestNodeTo(endPosition);
        if (startMesh2DNode != null && endMesh2DNode != null)
        {
            resultingPath.AddRange(instance.GetPath(
                startMesh2DNode,
                endMesh2DNode).Select(a => (Vector2)a.position));
        }

        resultingPath.Add(endPosition);

        return resultingPath;
    }

    /// <summary>
    /// Returns the actual NavMesh2D object that lives in your scene
    /// </summary>
    /// <returns></returns>
    public static NavMesh2DBehaviour GetNavMeshObject()
    {
        return instance;
    }
}
