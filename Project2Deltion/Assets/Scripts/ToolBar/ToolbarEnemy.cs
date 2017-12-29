﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyAI))]
public class ToolbarEnemy : Editor
{
    private EnemyAI myTarget;
    private SerializedObject soTarget;

    private SerializedProperty health;
    private SerializedProperty currentHealth;
    private SerializedProperty dead;

    private SerializedProperty body;
    private SerializedProperty ragDoll;

    private SerializedProperty head;

    private SerializedProperty points;
    private SerializedProperty destPoint;
    private SerializedProperty random;
    private SerializedProperty onWayPoint;

    private SerializedProperty lookLength;

    private SerializedProperty chasing;
    private SerializedProperty player;

    private SerializedProperty attackLength;

    private SerializedProperty senseField;
    private SerializedProperty maxTimer;



    private void OnEnable()
    {
        myTarget = (EnemyAI)target;
        soTarget = new SerializedObject(target);

        health = soTarget.FindProperty("health");
        currentHealth = soTarget.FindProperty("currentHealth");
        dead = soTarget.FindProperty("dead");
        body = soTarget.FindProperty("body");
        ragDoll = soTarget.FindProperty("ragDoll");
        head = soTarget.FindProperty("head");
        points = soTarget.FindProperty("points");
        destPoint = soTarget.FindProperty("destPoint");
        random = soTarget.FindProperty("random");
        onWayPoint = soTarget.FindProperty("onWayPoint");
        lookLength = soTarget.FindProperty("lookLength");
        chasing = soTarget.FindProperty("chasing");
        player = soTarget.FindProperty("player");
        attackLength = soTarget.FindProperty("attackLength");
        senseField = soTarget.FindProperty("senseField");
        maxTimer = soTarget.FindProperty("maxTimer");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        //DrawDefaultInspector();
        soTarget.Update();

        EditorGUI.BeginChangeCheck();

        myTarget.toolbarTop = GUILayout.Toolbar(myTarget.toolbarTop, new string[] { "RagDoll", "isChasing", "isAttacking", "isThinking"});
        switch (myTarget.toolbarTop)
        {
            case 0:
                myTarget.toolbarBottom = 4;
                myTarget.currentTab = "RagDoll";
                break;
            case 1:
                myTarget.toolbarBottom = 4;
                myTarget.currentTab = "isChasing";
                break;
            case 2:
                myTarget.toolbarBottom = 4;
                myTarget.currentTab = "isAttacking";
                break;
            case 3:
                myTarget.toolbarBottom = 4;
                myTarget.currentTab = "isThinking";
                break;
        }

        myTarget.toolbarBottom = GUILayout.Toolbar(myTarget.toolbarBottom, new string[] {"WalkField", "Health", "?!#.....", "LookRayCast" });
        switch (myTarget.toolbarBottom)
        {
            case 0:
                myTarget.toolbarTop = 4;
                myTarget.currentTab = "WalkField";
                break;
            case 1:
                myTarget.toolbarTop = 4;
                myTarget.currentTab = "Health";
                break;
            case 2:
                myTarget.toolbarTop = 4;
                myTarget.currentTab = "?!#.....";
                break;
            case 3:
                myTarget.toolbarTop = 4;
                myTarget.currentTab = "LookRayCast";
                break;
        }

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        EditorGUI.BeginChangeCheck();

        switch (myTarget.currentTab)
        {

            case "RagDoll":
                EditorGUILayout.PropertyField(body);
                EditorGUI.indentLevel += 1;
                if (body.isExpanded)
                {
                    EditorGUILayout.PropertyField(body.FindPropertyRelative("Array.size"));
                    for (int i = 0; i < body.arraySize; i++)
                    {
                        EditorGUILayout.PropertyField(body.GetArrayElementAtIndex(i));
                    }
                }
                EditorGUI.indentLevel -= 1;
                EditorGUILayout.PropertyField(ragDoll);
                break;
            case "isChasing":
                EditorGUILayout.PropertyField(chasing);
                EditorGUILayout.PropertyField(player);
                break;
            case "isAttacking":
                EditorGUILayout.PropertyField(attackLength);
                break;
            case "isThinking":
                EditorGUILayout.PropertyField(senseField);
                EditorGUILayout.PropertyField(maxTimer);
                break;
            case "WalkField":
                EditorGUILayout.PropertyField(points);
                EditorGUI.indentLevel += 1;
                if (points.isExpanded)
                {
                    EditorGUILayout.PropertyField(points.FindPropertyRelative("Array.size"));
                    for (int i = 0; i < points.arraySize; i++)
                    {
                        EditorGUILayout.PropertyField(points.GetArrayElementAtIndex(i));
                    }
                }
                EditorGUI.indentLevel -= 1;

                EditorGUILayout.PropertyField(destPoint);
                EditorGUILayout.PropertyField(random);
                EditorGUILayout.PropertyField(onWayPoint);
                break;
            case "Health":
                EditorGUILayout.PropertyField(health);
                EditorGUILayout.PropertyField(currentHealth);
                EditorGUILayout.PropertyField(dead);
                break;
            case "?!#.....":
                EditorGUILayout.PropertyField(head);
                break;
            case "LookRayCast":
                EditorGUILayout.PropertyField(lookLength);
                break;

        }

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }


    }

}
