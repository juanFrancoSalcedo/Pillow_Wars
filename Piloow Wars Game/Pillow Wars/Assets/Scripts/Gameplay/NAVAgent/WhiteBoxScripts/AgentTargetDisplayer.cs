using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentTargetDisplayer : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] BaseNavigationAgentController controller;
    private void Start() => controller.positioner.navTarget.OnPositionChanged += SetPos;

    private void OnDestroy() => controller.positioner.navTarget.OnPositionChanged -= SetPos;

    private void SetPos(Vector3 position) => _text.text = position.ToString();
}
