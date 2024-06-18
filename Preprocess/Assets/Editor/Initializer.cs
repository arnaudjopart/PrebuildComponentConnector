
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class Initializer
{
    static Initializer()
    {
        Debug.Log("Initializer: Listening to PrefabUtility.prefabInstanceUpdated");
        PrefabUtility.prefabInstanceUpdated += TestScript;
    }

    private static void TestScript(GameObject instance)
    {
        var path = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(instance);
        Debug.Log(path);
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        //AssetDatabase.Sa

        TestScenePreprocess.InjectComponent(prefab);
        //TestScenePreprocess.InjectComponent(instance);
        
        //PrefabUtility.ApplyObjectOverride(instance, path, InteractionMode.AutomatedAction);
        //var result = PrefabUtility.GetPrefabInstanceHandle(instance)
    }
}
