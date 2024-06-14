using System.Linq;
using System.Reflection;
using CustomAttributes;
using Editor;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScenePreprocess : IProcessSceneWithReport
{

    public int callbackOrder { get; }
    public void OnProcessScene(Scene scene, BuildReport report)
    {
        //if (BuildPipeline.isBuildingPlayer) return;
        var camera = GameObject.FindWithTag("MainCamera");

        var components = camera.GetComponents(typeof(Component));
        //Go through every component of this GameObject
        foreach (var component in components)
        {
            //Filter Monobehaviour and Component
            //Debug.Log(component.GetType().FullName);
            var isMono = component is MonoBehaviour;
            if (isMono)
            {
                //Get component, based on component type
                //var test = camera.GetComponent(component.GetType());
                
                Debug.Log(component.GetType().FullName +"? "+isMono);

                //Retrieve private fields of the class
                var result = component.GetType().GetFields(BindingFlags.NonPublic|BindingFlags.Instance);
                foreach (var fieldInfo in result)
                {
                    //Check if private field has the custom attribute
                    var results = fieldInfo.GetCustomAttributes(typeof(IPrebuildGetComponent), true);
                    foreach (IPrebuildGetComponent connector in results)
                    {
                        connector.Apply(fieldInfo,component,camera);
                    }
                    //if results.lenght<0, that means it does not have the attribute
                    //if (results.Length <= 0) continue;
                    //Debug.Log(fieldInfo.FieldType);

                    //fieldInfo.SetValue(component,camera.GetComponent(fieldInfo.FieldType));
                     
                }
                
                /*
                SerializedProperty prop = serObj.GetIterator();
                //SerializedObject serObj = new SerializedObject(test);
                while (prop.NextVisible(true))
                {

                    if (prop.type.Contains("Rigidbody"))
                    {
                        var name = "Rigidbody";
                        prop.objectReferenceValue = camera.GetComponent(name);
                        serObj.ApplyModifiedProperties();
                

                    }
                    //Debug.Log(prop.name);
            
           
            
                }*/
                
            }
            
        }
        
        /*
        var script = camera.GetComponent<TestClass>( );
        SerializedObject serObj = new SerializedObject(script);
        SerializedProperty prop = serObj.GetIterator();
       
        while (prop.NextVisible(true))
        {
            Debug.Log(prop.type);
            if (prop.type.Contains("Rigidbody"))
            {
                var name = "Rigidbody";
                prop.objectReferenceValue = camera.GetComponent(name);
                serObj.ApplyModifiedProperties();
                

            }
            Debug.Log(prop.name);
            
           
            
        }*/
    }
}
