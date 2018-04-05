using HoloToolkit.Unity.InputModule;
using UnityEngine;
using ResultTracker;

namespace DraggedObj
{
    public class HandDragging : MonoBehaviour, IManipulationHandler
    {
        public Vector3 lastPosition;

        private dataTracker results;
        private float DragSpeed;
        private float DragScale;
        private bool draggingEnabled;

        void Start()
        {
            draggingEnabled = true;
            DragSpeed = 5f;
            DragScale = 5f;
            results = GameObject.Find("[Study]").GetComponent<dataTracker>();
        }

        public void SetDragging(bool enabled)
        {
            draggingEnabled = enabled;
        }

        public void OnManipulationStarted(ManipulationEventData eventData)
        {
            InputManager.Instance.PushModalInputHandler(gameObject);
            lastPosition = transform.position;
            results.Num_clicks++;
            results.startInteraction();
        }

        public void OnManipulationUpdated(ManipulationEventData eventData)
        {
            if (draggingEnabled)
            {
                Drag(eventData.CumulativeDelta);
            }
        }

        public void OnManipulationCompleted(ManipulationEventData eventData)
        {
            InputManager.Instance.PopModalInputHandler();
            results.endInteraction(this.gameObject.name);
        }

        public void OnManipulationCanceled(ManipulationEventData eventData)
        {
            InputManager.Instance.PopModalInputHandler();
            results.endInteraction(this.gameObject.name);
        }

        void Drag(Vector3 positon)
        {
            var targetPosition = lastPosition + positon * DragScale;
            transform.position = Vector3.Lerp(transform.position, targetPosition, DragSpeed);
        }
    }
}