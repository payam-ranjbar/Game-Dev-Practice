using UnityEngine;
using UnityEngine.Playables;

namespace TimelineUtils
{
    public class MultiAimControlBehavior : PlayableBehaviour
    {
        public TimelineMultiAimControl multiAimControl;
        public float duration;
        public GameObject aimTarget;

        private Vector3 initialPos;
        

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {

            var target = playerData as TimelineMultiAimControl;

            // aimTarget = playable.get
            if (target != null)
            {
                var currentPos = target.aimTargetHandle.transform.position;
                
                // var toPos = Vector3.Lerp(currentPos)
                // target.aimTargetHandle.transform.position = ;
            }
            base.ProcessFrame(playable, info, playerData);
            
        }
    }
}