using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerAttributes))]
public class PlayerEditor : Editor {


	public override void OnInspectorGUI ()
	{
		PlayerAttributes pA = (PlayerAttributes)target;

		base.OnInspectorGUI();

		EditorGUILayout.BeginVertical();

		EditorGUILayout.LabelField("Set player life");
		pA.life = EditorGUILayout.IntSlider(pA.life,0,pA.maxValues);

		EditorGUILayout.LabelField("Set player oxygen");
		pA.oxygen = EditorGUILayout.IntSlider(pA.oxygen,0,pA.maxValues);

		EditorGUILayout.LabelField("Set player energy");
		pA.energy = EditorGUILayout.IntSlider(pA.energy,0,pA.maxValues);

		EditorGUILayout.LabelField("Set experience points");
		pA.experiencePoints = EditorGUILayout.IntSlider(pA.experiencePoints,0,pA.maxValues);
		 
		EditorGUILayout.EndVertical();
	}
}
