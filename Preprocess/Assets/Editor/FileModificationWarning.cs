using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PrefabUtility;

namespace Assets.Editor
{
    public class FileModificationWarning : AssetModificationProcessor
    {
     
        

        static string[] OnWillSaveAssets(string[] paths)
        {
            Debug.Log("OnWillSaveAssets");
            foreach (string path in paths)
                if (path.Contains(".prefab"))
                {


                    
                }
                
            return paths;
        }

        private static void TestScript(GameObject instance)
        {
            Debug.Log(instance.name);
        }
    }
}