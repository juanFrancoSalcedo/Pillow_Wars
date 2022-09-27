using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BaseNavigationAgentController : MonoBehaviour 
{
    protected NavMeshAgent agent => GetComponent<NavMeshAgent>();
    public NavigationAgentPositioner positioner = null;
    public event System.Action<float> OnVelocityChanged;

    protected void Awake() => positioner = new NavigationAgentPositioner();

    protected void OnEnable() => positioner.navTarget.OnPositionChanged += UpdateAgentTarget;

    protected void OnDisable() => positioner.navTarget.OnPositionChanged -= UpdateAgentTarget;

    private void Update() => OnVelocityChanged?.Invoke(agent.velocity.magnitude);
    protected void UpdateAgentTarget(Vector3 newPos) => agent.SetDestination(newPos);
}
