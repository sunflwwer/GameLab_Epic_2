using UnityEngine;
using UnityEngine.InputSystem;

namespace GMTK.PlatformerToolkit {
    // 마우스 클릭 입력을 처리하는 스크립트

    public class characterMouseInput : MonoBehaviour {

        [Header("Audio")]
        [SerializeField][Tooltip("좌클릭 시 재생될 사운드")] private AudioSource leftClickSFX;
        [SerializeField][Tooltip("우클릭 시 재생될 사운드")] private AudioSource rightClickSFX;

        [Header("Purify Settings")]
        [SerializeField][Tooltip("정화 범위")] private float purifyRange = 5f;
        [SerializeField][Tooltip("적 레이어")] private LayerMask enemyLayer;


        [Header("Options")]
        [SerializeField][Tooltip("좌클릭 활성화")] private bool enableLeftClick = true;
        [SerializeField][Tooltip("우클릭 활성화")] private bool enableRightClick = true;

        // 좌클릭 이벤트 핸들러
        public void OnLeftClick(InputAction.CallbackContext context) {
            // 버튼을 눌렀을 때만 반응 (누르고 있거나 뗄 때는 무시)
            if (context.performed && enableLeftClick) {
                Debug.Log("좌클릭 감지!");
                
                // 사운드가 설정되어 있으면 재생
                if (leftClickSFX != null) {
                    leftClickSFX.Play();
                }

                PurifyEnemies();
            }
        }

        // 우클릭 이벤트 핸들러
        public void OnRightClick(InputAction.CallbackContext context) {
            // 버튼을 눌렀을 때만 반응
            if (context.performed && enableRightClick) {
                Debug.Log("우클릭 감지!");
                
                // 사운드가 설정되어 있으면 재생
                if (rightClickSFX != null) {
                    rightClickSFX.Play();
                }

                PurifyEnemies();
            }
        }

        private void PurifyEnemies()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, purifyRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.Purify();
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, purifyRange);
        }
    }
}

