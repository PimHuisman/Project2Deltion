using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MainWeapons))]
public class ToolbarWeapon : Editor
{
    private MainWeapons myTarget;
    private SerializedObject soTarget;

    private SerializedProperty ammoText;
    private SerializedProperty weaponType;
    private SerializedProperty currentAmmo;
    private SerializedProperty maxAmmo;
    private SerializedProperty fireAmmo;

    private SerializedProperty maxClip;
    private SerializedProperty currentClipAmount;

    private SerializedProperty hole;
    private SerializedProperty raycastLength;
    private SerializedProperty cameraPosition;

    private SerializedProperty reloadTime;
    private SerializedProperty inpactForce;
    private SerializedProperty fireAgain;
    private SerializedProperty damage;


    private void OnEnable()
    {
        myTarget = (MainWeapons)target;
        soTarget = new SerializedObject(target);

        ammoText = soTarget.FindProperty("ammoText");
        weaponType = soTarget.FindProperty("weaponType");
        currentAmmo = soTarget.FindProperty("currentAmmo");
        maxAmmo = soTarget.FindProperty("maxAmmo");
        fireAmmo = soTarget.FindProperty("fireAmmo");
        maxClip = soTarget.FindProperty("maxClip");
        currentClipAmount = soTarget.FindProperty("currentClipAmount");
        hole = soTarget.FindProperty("hole");
        raycastLength = soTarget.FindProperty("raycastLength");
        cameraPosition = soTarget.FindProperty("cameraPosition");
        reloadTime = soTarget.FindProperty("reloadTime");
        inpactForce = soTarget.FindProperty("inpactForce");
        fireAgain = soTarget.FindProperty("fireAgain");
        damage = soTarget.FindProperty("damage");

    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        myTarget.weaponToolbarTop = GUILayout.Toolbar(myTarget.weaponToolbarTop, new string[] { "AmmoInfo", "ClipInfo", "RaycastInfo", "Bullet/ClipInfo" });
        switch (myTarget.weaponToolbarTop)
        {
            case 0:
                //myTarget.weaponToolbarBottom = 4;
                myTarget.weaponCurrentTab = "AmmoInfo";
                break;
            case 1:
                //myTarget.weaponToolbarBottom = 4;
                myTarget.weaponCurrentTab = "ClipInfo";
                break;
            case 2:
                //myTarget.weaponToolbarBottom = 4;
                myTarget.weaponCurrentTab = "RaycastInfo";
                break;
            case 3:
                //myTarget.weaponToolbarBottom = 4;
                myTarget.weaponCurrentTab = "Bullet/ClipInfo";
                break;
        }


        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        EditorGUI.BeginChangeCheck();

        switch (myTarget.weaponCurrentTab)
        {
            case "AmmoInfo":
                EditorGUILayout.PropertyField(ammoText);
                EditorGUILayout.PropertyField(weaponType);
                EditorGUILayout.PropertyField(currentAmmo);
                EditorGUILayout.PropertyField(maxAmmo);
                EditorGUILayout.PropertyField(fireAmmo);
                break;
            case "ClipInfo":
                EditorGUILayout.PropertyField(maxClip);
                EditorGUILayout.PropertyField(currentClipAmount);
                break;
            case "RaycastInfo":
                EditorGUILayout.PropertyField(hole);
                EditorGUILayout.PropertyField(raycastLength);
                EditorGUILayout.PropertyField(cameraPosition);
                break;
            case "Bullet/ClipInfo":
                EditorGUILayout.PropertyField(reloadTime);
                EditorGUILayout.PropertyField(inpactForce);
                EditorGUILayout.PropertyField(fireAgain);
                EditorGUILayout.PropertyField(damage);
                break;
                
        }

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
    }
}
