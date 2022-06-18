using System;
using UnityEditor;
using UnityEngine;

public class SetSceneCamera
{
    private const string SCENE_CAMERA_PLAYER_PREFS = "SceneCameraPostion";
    
    private static CameraTransform SavedCameraTransform
    {
        get
        {
            return JsonUtility.FromJson<CameraTransform>(PlayerPrefs.GetString(SCENE_CAMERA_PLAYER_PREFS));
        }
        set
        {
            PlayerPrefs.SetString(SCENE_CAMERA_PLAYER_PREFS, JsonUtility.ToJson(value));
        }
    }
    
    [MenuItem("Assets/Save scene camera position")]
    public static void SaveCameraPosition()
    {
        var sceneView = SceneView.lastActiveSceneView;
        CameraTransform cameraTransform = new CameraTransform(sceneView.pivot, sceneView.rotation, sceneView.size);
        SavedCameraTransform = cameraTransform;
    }
    
    [MenuItem("Assets/Load scene camera position")]
    public static void LoadCameraPosition()
    {
        var sceneView = SceneView.lastActiveSceneView;
        var savedCameraTransform = SavedCameraTransform;
        sceneView.pivot = savedCameraTransform.Position;
        sceneView.rotation = savedCameraTransform.Rotation;
        sceneView.size = savedCameraTransform.Size;
    }

    [Serializable]
    struct CameraTransform
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public float Size;

        public CameraTransform(Vector3 position, Quaternion rotation, float size)
        {
            Position = position;
            Rotation = rotation;
            Size = size;
        }
    }
}
