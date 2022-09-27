using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetListener : MonoBehaviour
{
    [SerializeField] BaseNavigationAgentController controller;
    private void Start() => controller.positioner.navTarget.OnPositionChanged += SetPos;

    private void OnDestroy() => controller.positioner.navTarget.OnPositionChanged -= SetPos;

    private void SetPos(Vector3 position) => transform.position = position;
}
