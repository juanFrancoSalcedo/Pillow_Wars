using PillowWars.Units.Pijaman;
using System.Collections;
using UnityEngine;

namespace PillowWars
{
    public class InputPlayerController : MonoBehaviour
    {
        [SerializeField] private NavigationAgentPlayerController agentController = null;
        [SerializeField] private BaseEntity entityController = null;
        private DragController dragController = null;
        private ComboController comboList = new ComboController();

        #region Command
        Command basicAttack;
        #endregion

        private void Awake() => dragController = DragController.Instance;

        private void Start()
        {
            //TODOME separate this class InputPlayerController as Player PijamanInputPlayerController
            //Tank you Command and abstract classes >:(
            basicAttack = new BasicAttackPijamanCommand();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                BasicAttack();
        }

        public void BasicAttack()
        {
            comboList.AddCommand(basicAttack);
            print(entityController == null);
            print(entityController.StateController == null);
            basicAttack.Execute(entityController.StateController);
        }

        public void LongAttack()
        {

        }

        private void OnEnable() => dragController.OnDragged += GetDragPosition;

        private void OnDisable() => dragController.OnDragged -= GetDragPosition;

        private void GetDragPosition(Vector3 pos)
        {
            var inmor = agentController.transform.position;
            var normaLized = pos.normalized;
            var nono = new Vector3(normaLized.x, 0, normaLized.y);

            var cient = inmor + nono;
            agentController.positioner.SetPosition(cient);
        }
    }

}
