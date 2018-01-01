﻿using UnityEngine;

namespace UniLife.GOAP.MinerExample {
    public class DigOreAction : Action {
        public float miningDuration = 0;

        float mStartTime = 0;
        
        protected override void Init() {
            mStartTime = 0;
        }

        public override void SetupStateFlags() {
            AddPrecondition(StateFlagNames.HAS_TOOL, true);
            AddPrecondition(StateFlagNames.HAS_ORE, false);
            AddPrecondition(StateFlagNames.IS_TIRED, false);

            AddEffect(StateFlagNames.IS_TIRED, true);
            AddEffect(StateFlagNames.HAS_ORE, true);
            AddEffect(StateFlagNames.IS_TIRED, true);
        }

        public override bool Perform(GameObject pAgent) {
            if (mStartTime == 0)
                mStartTime = Time.time;
            //Debug.Log("Mining Ore");
            if (Time.time - mStartTime > miningDuration) {
                Debug.Log("Mining done");
                isDone = true;
            }
            return true;
        }

        public override bool CheckProceduralPrecondition(Agent pAgent) {
            target = GameObject.Find("Mine");
            return target != null;
        }
        
        public override bool IsRanged() {
            return true;
        }
    }
}