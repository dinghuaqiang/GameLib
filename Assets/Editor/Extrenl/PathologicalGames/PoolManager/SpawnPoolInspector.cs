/// <Licensing>
/// � 2011 (Copyright) Path-o-logical Games, LLC
/// If purchased from the Unity Asset Store, the following license is superseded 
/// by the Asset Store license.
/// Licensed under the Unity Asset Package Product License (the "License");
/// You may not use this file except in compliance with the License.
/// You may obtain a copy of the License at: http://licensing.path-o-logical.com
/// </Licensing>
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using GameLib.Core.Support;


// Only compile if not using Unity iPhone
[CustomEditor(typeof(SpawnPool))]
public class SpawnPoolInspector : Editor
{
    public bool expandPrefabs = true;

    public override void OnInspectorGUI()
	{
        var script = (SpawnPool)target;

        EditorGUI.indentLevel = 0;
        PGEditorUtils.LookLikeControls();

        script.PoolName = EditorGUILayout.TextField("Pool Name", script.PoolName);

        script.MatchPoolScale = EditorGUILayout.Toggle("Match Pool Scale", script.MatchPoolScale);
        script.MatchPoolLayer = EditorGUILayout.Toggle("Match Pool Layer", script.MatchPoolLayer);
        
        script.dontDestroyOnLoad = EditorGUILayout.Toggle("Don't Destroy On Load", script.dontDestroyOnLoad);
        
        script.LogMessages = EditorGUILayout.Toggle("Log Messages", script.LogMessages);

        this.expandPrefabs = PGEditorUtils.SerializedObjFoldOutList<PrefabPool>
                            (
                                "Per-Prefab Pool Options", 
                                script.PerPrefabPoolOptions,
                                this.expandPrefabs,
                                ref script.EditorListItemStates,
                                true
                            );

        // Flag Unity to save the changes to to the prefab to disk
        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }

}


