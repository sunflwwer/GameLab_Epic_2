using UnityEngine;

namespace GMTK.PlatformerToolkit {
    //This script is used by both movement and jump to detect when the character is touching the ground
    public class characterGround : MonoBehaviour {
        private bool onGround;

        [Header("Layer Masks")]
        [SerializeField][Tooltip("Which layers are read as the ground")] private LayerMask groundLayer;

        private void OnCollisionEnter2D(Collision2D collision) {
            if (((1 << collision.gameObject.layer) & groundLayer) != 0) {
                onGround = true;
            }
        }

        private void OnCollisionStay2D(Collision2D collision) {
            if (((1 << collision.gameObject.layer) & groundLayer) != 0) {
                onGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision) {
            if (((1 << collision.gameObject.layer) & groundLayer) != 0) {
                onGround = false;
            }
        }

        //Send ground detection to other scripts
        public bool GetOnGround() { return onGround; }
    }
}