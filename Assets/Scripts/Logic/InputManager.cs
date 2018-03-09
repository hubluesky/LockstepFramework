  using UnityEngine;

  namespace LockstepFramework {
      public class InputManager : MonoBehaviour {
          void Update() {
              float horizontal = Input.GetAxis("Horizontal");
              float vertical = Input.GetAxis("Vertical");

              MovementAction movementAction = new MovementAction() { horizontal = horizontal, vertical = vertical };
              ActionManager.AddAction(movementAction);
          }
      }
  }