#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace ShapesXr
{
    [CustomEditor(typeof(SpaceDescriptor))]
    public class SpaceDescriptorEditor : Editor
    {
        private SpaceDescriptor _spaceDescriptor;

        
        private void OnEnable()
        {
            _spaceDescriptor = serializedObject.targetObject as SpaceDescriptor;
        }

        public override void OnInspectorGUI()
        {
            if (!_spaceDescriptor)
            {
                return;
            }

            int stageCount = _spaceDescriptor.StageObjects.Count;

            if (stageCount == 0)
            {
                return;
            }

            EditorGUILayout.BeginVertical();
            
            EditorGUILayout.SelectableLabel($"Space: {_spaceDescriptor.AccessCode.Insert(3, " ")}", EditorStyles.boldLabel);

            EditorGUI.BeginDisabledGroup(stageCount == 0);

            _spaceDescriptor.ActiveStage = EditorGUILayout.IntSlider($"Stage: {_spaceDescriptor.ActiveStage + 1}/{stageCount}", _spaceDescriptor.ActiveStage + 1, 1, stageCount) - 1;

            EditorGUI.EndDisabledGroup();
            
            EditorGUILayout.Space();

            if (GUILayout.Button("Reimport"))
            {
                SpaceImporter.ImportSpace(_spaceDescriptor.AccessCode);
                DestroyImmediate(_spaceDescriptor.gameObject);
            }
            
            EditorGUILayout.EndVertical();
        }
    }
}

#endif