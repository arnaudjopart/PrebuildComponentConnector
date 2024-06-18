using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScenePreprocess : IProcessSceneWithReport
{

    public int callbackOrder { get { return 0; } }
    public void OnProcessScene(Scene scene, BuildReport report)
    {
        Debug.Log("MyCustomBuildProcessor.OnProcessScene " + scene.name);
        //if (BuildPipeline.isBuildingPlayer) return;
        var rootsObjects = scene.GetRootGameObjects();
        foreach (var rootObject in rootsObjects)
        {
            InjectComponent(rootObject);
        }
    }

    public static void InjectComponent(GameObject _object)
    {
        var components = _object.GetComponents(typeof(Component));
        //Go through every component of this GameObject
        foreach (var component in components)
        {
            
            //Filter Monobehaviour and Component
            //Debug.Log(component.GetType().FullName);
            if (component is not MonoBehaviour) continue;
            //Retrieve private fields of the class
            var fieldInfos = component.GetType().GetFields(BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Public);
            foreach (var fieldInfo in fieldInfos)
            {
                //Check if field has the custom attribute
                var customAttributes = fieldInfo.GetCustomAttributes(typeof(IPrebuildGetComponent), true);
                foreach (IPrebuildGetComponent connector in customAttributes)
                {
                    connector.Apply(fieldInfo,component,_object);
                }
            }
        }

        foreach (Transform childTransform in _object.transform)
        {
            InjectComponent(childTransform.gameObject);
        }
    }
}
