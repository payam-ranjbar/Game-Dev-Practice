using UnityEngine;
using UnityEngine.Playables;

namespace TimelineUtils
{
    public class MultiAimPlayableAsset : PlayableAsset
    {
        public ExposedReference<TimelineMultiAimControl> multiAim;
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<MultiAimControlBehavior>.Create(graph);
            var behavior = playable.GetBehaviour();
            behavior.multiAimControl = multiAim.Resolve(graph.GetResolver());

            return playable;
        }
    }
}