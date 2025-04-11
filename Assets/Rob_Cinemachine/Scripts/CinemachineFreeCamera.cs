using UnityEngine;

namespace RobCinemachineFreelookCamera
{
    public class CinemachineFreeCamera : MonoBehaviour
    {
        //Movement
        [Header("Player")]
        [SerializeField] private float m_playerMoveSpeed;

        [Header("Camera")]
        [SerializeField] private Transform m_playerCameraLookTarget;
        [SerializeField] private float m_lookSensitivity = 100f;
        [SerializeField] private float m_cameraLookRotationSmoothSpeed = 10;

        [Header("Camera Min Max Clamp")]
        [Tooltip("X = Min, Y = Max")]
        [SerializeField] private Vector2 m_clampMinMax;
       

        private float m_currentPitch = 0f;
        private float m_currentYaw = 0f;

        
        //Animator
        [SerializeField] Animator m_animator;


        public bool isInInteractionArea = false;

        private void Start()
        {
            //SetCursor();
        }

        void Update()
        {
            Move();
            Look();

            if(Input.GetKeyDown(KeyCode.F) && isInInteractionArea)
            {
                m_animator.SetTrigger("IsInteracting");
            }
        }
        private void SetCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void Move()
        {
            m_playerCameraLookTarget.position = transform.position;

            Vector3 move = Vector3.zero;

            move.x = Input.GetAxis("Horizontal");
            move.z = Input.GetAxis("Vertical");

            m_animator.SetFloat("horizontal", move.x);
            m_animator.SetFloat("vertical", move.z);

            move = m_playerCameraLookTarget.TransformDirection(move);

            move.y = 0; //cancel out the camera tilt
                        //make the direction lengh 1 again and multi by the speed 
            move = move.normalized * m_playerMoveSpeed * Time.deltaTime;

            transform.position += move;

            /*if (move.sqrMagnitude != 0)
            {
                transform.forward = move.normalized;
            }*/

            if (move.sqrMagnitude != 0)
            {
                //transform.forward = move.normalized;
                Vector3 rot = m_playerCameraLookTarget.rotation.eulerAngles;
                rot.x = 0;
                rot.z = 0;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rot), 
                    Time.deltaTime * m_cameraLookRotationSmoothSpeed);
            }
        }
        private void Look()
        {
            float mouseX = Input.GetAxis("Mouse X") * m_lookSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * m_lookSensitivity * Time.deltaTime;

            m_currentYaw += mouseX;
            m_currentPitch -= mouseY;
            m_currentPitch = Mathf.Clamp(m_currentPitch, m_clampMinMax.x, m_clampMinMax.y);

            Quaternion targetRot = Quaternion.Euler(m_currentPitch, m_currentYaw, 0f);
            m_playerCameraLookTarget.rotation = Quaternion.Slerp(m_playerCameraLookTarget.rotation, targetRot, Time.deltaTime * m_cameraLookRotationSmoothSpeed);
        }

        public void SetIneractionStatus(GameObject gameObject)
        {
            isInInteractionArea = !isInInteractionArea;

        }
    }
}
