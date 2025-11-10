using UnityEngine;

namespace GMTK.PlatformerToolkit
{
    public class EnemyController : MonoBehaviour
    {
        [Header("State")]
        [SerializeField]
        [Tooltip("악력. 0이 되면 정화됩니다.")]
        private int evilPower = 5;
        private const int maxEvilPower = 5;

        [Header("Colors")]
        [SerializeField]
        [Tooltip("완전히 정화되었을 때의 색상")]
        private Color purifiedColor = Color.blue;
        [SerializeField]
        [Tooltip("초기 상태의 색상")]
        private Color evilColor = Color.red;

        private SpriteRenderer spriteRenderer;

        void Start()
        {
            // SpriteRenderer 컴포넌트를 가져옵니다.
            spriteRenderer = GetComponent<SpriteRenderer>();
            UpdateColor();
        }

        // 악력을 감소시키고 색상을 업데이트하는 함수
        public void Purify()
        {
            if (evilPower > 0)
            {
                evilPower--;
                Debug.Log("악력 감소! 현재 악력: " + evilPower);
                UpdateColor();
            }
        }

        // 악력에 따라 색상을 업데이트하는 함수
        private void UpdateColor()
        {
            if (spriteRenderer != null)
            {
                // evilPower 값에 따라 두 색상 사이를 보간합니다.
                // evilPower가 5일 때 1(evilColor), 0일 때 0(purifiedColor)이 됩니다.
                float lerpFactor = (float)evilPower / maxEvilPower;
                spriteRenderer.color = Color.Lerp(purifiedColor, evilColor, lerpFactor);
            }
        }
    }
}
