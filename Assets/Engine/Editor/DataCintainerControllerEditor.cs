using UnityEditor;
using UnityEngine;

namespace Engine.Editor
{
    [CustomEditor(typeof(DataContainerController))]
    public class DataCintainerControllerEditor : UnityEditor.Editor
    {
        private ReorderableListExtend reorderableList;
        private DataContainerController TargetObject;

        private void OnEnable()
        {
            /*TargetObject = (DataContainerController)target;
            if(TargetObject.DataContainers == null)
                TargetObject.DataContainers = new List<IDataContainer>();*/

            reorderableList = new ReorderableListExtend(serializedObject, "m_PrefabBehaviour", false);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // Step 2, print it out.
            reorderableList.DoLayoutList();

            if (GUI.changed)
                serializedObject.ApplyModifiedProperties();
        }
    }
}