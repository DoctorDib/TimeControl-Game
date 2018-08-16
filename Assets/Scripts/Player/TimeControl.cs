using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace Player {
	public class TimeControl : MonoBehaviour {

		// 2 - fast
		// 1 - Normal
		// 0 - Pause time
		// -1 - Rewind time
		
		public float currTime = 1;
		public bool activateTimeField = false;
		
		private bool m_RewindTime = false;
		private Controller m_PlayerController;

		private void Update() {
			// Control
			if (Input.GetButtonDown("Fire1") && currTime < 1)
				if (activateTimeField) {
					SetTimeControl(currTime -= 0.25f);
				}
			
			if (Input.GetButtonDown("Fire2") && currTime > -1)
				if (activateTimeField) {
					SetTimeControl(currTime -= 0.25f);
				}

			if (Input.GetButtonDown("Fire3")) {
				if (activateTimeField) {
					Time.timeScale = 1;
					currTime = 1;
					activateTimeField = false;
				} else {
					activateTimeField = true;
					SetTimeControl(currTime);
				}
			}
			
			if (activateTimeField) {
				SetTimeControl(currTime);
			}
		}

		private void Start() {
			m_PlayerController = gameObject.GetComponent<Controller>();
		}

		public void SetTimeControl(float time) {
			if (time > 0 && time < 1) {
				//m_PlayerController.Move(velocity * (Time.deltaTime + 1-Time.timeScale));
				Time.timeScale = time;
				Time.fixedDeltaTime = Time.timeScale * 0.02f;
			}
			
		}

	}
}
