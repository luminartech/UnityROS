using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using uint8 = System.Byte;
using Messages.geometry_msgs;
using Messages.sensor_msgs;
using Messages.actionlib_msgs;

using Messages.std_msgs;
using String=System.String;

namespace Messages.object_recognition_msgs
{
#if !TRACE
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public class ObjectRecognitionAction : IRosMessage
    {

			public Messages.object_recognition_msgs.ObjectRecognitionActionGoal action_goal; //woo
			public Messages.object_recognition_msgs.ObjectRecognitionActionResult action_result; //woo
			public Messages.object_recognition_msgs.ObjectRecognitionActionFeedback action_feedback; //woo


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string MD5Sum() { return "7d8979a0cf97e5078553ee3efee047d2"; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasHeader() { return false; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsMetaType() { return true; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string MessageDefinition() { return @"ObjectRecognitionActionGoal action_goal
ObjectRecognitionActionResult action_result
ObjectRecognitionActionFeedback action_feedback"; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override MsgTypes msgtype() { return MsgTypes.object_recognition_msgs__ObjectRecognitionAction; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsServiceComponent() { return false; }

        [System.Diagnostics.DebuggerStepThrough]
        public ObjectRecognitionAction()
        {
            
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ObjectRecognitionAction(byte[] SERIALIZEDSTUFF)
        {
            Deserialize(SERIALIZEDSTUFF);
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ObjectRecognitionAction(byte[] SERIALIZEDSTUFF, ref int currentIndex)
        {
            Deserialize(SERIALIZEDSTUFF, ref currentIndex);
        }



        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override void Deserialize(byte[] SERIALIZEDSTUFF, ref int currentIndex)
        {
            int arraylength=-1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize=0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;
            
            //action_goal
            action_goal = new Messages.object_recognition_msgs.ObjectRecognitionActionGoal(SERIALIZEDSTUFF, ref currentIndex);
            //action_result
            action_result = new Messages.object_recognition_msgs.ObjectRecognitionActionResult(SERIALIZEDSTUFF, ref currentIndex);
            //action_feedback
            action_feedback = new Messages.object_recognition_msgs.ObjectRecognitionActionFeedback(SERIALIZEDSTUFF, ref currentIndex);
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override byte[] Serialize(bool partofsomethingelse)
        {
            int currentIndex=0, length=0;
            bool hasmetacomponents = false;
            byte[] thischunk, scratch1, scratch2;
            List<byte[]> pieces = new List<byte[]>();
            GCHandle h;
            
            //action_goal
            if (action_goal == null)
                action_goal = new Messages.object_recognition_msgs.ObjectRecognitionActionGoal();
            pieces.Add(action_goal.Serialize(true));
            //action_result
            if (action_result == null)
                action_result = new Messages.object_recognition_msgs.ObjectRecognitionActionResult();
            pieces.Add(action_result.Serialize(true));
            //action_feedback
            if (action_feedback == null)
                action_feedback = new Messages.object_recognition_msgs.ObjectRecognitionActionFeedback();
            pieces.Add(action_feedback.Serialize(true));
            //combine every array in pieces into one array and return it
            int __a_b__f = pieces.Sum((__a_b__c)=>__a_b__c.Length);
            int __a_b__e=0;
            byte[] __a_b__d = new byte[__a_b__f];
            foreach(var __p__ in pieces)
            {
                Array.Copy(__p__,0,__a_b__d,__a_b__e,__p__.Length);
                __a_b__e += __p__.Length;
            }
            return __a_b__d;
        }

        public override void Randomize()
        {
            int arraylength=-1;
            Random rand = new Random();
            int strlength;
            byte[] strbuf, myByte;
            
            //action_goal
            action_goal = new Messages.object_recognition_msgs.ObjectRecognitionActionGoal();
            action_goal.Randomize();
            //action_result
            action_result = new Messages.object_recognition_msgs.ObjectRecognitionActionResult();
            action_result.Randomize();
            //action_feedback
            action_feedback = new Messages.object_recognition_msgs.ObjectRecognitionActionFeedback();
            action_feedback.Randomize();
        }

        public override bool Equals(IRosMessage ____other)
        {
            if (____other == null) return false;
            bool ret = true;
            object_recognition_msgs.ObjectRecognitionAction other = (Messages.object_recognition_msgs.ObjectRecognitionAction)____other;

            ret &= action_goal.Equals(other.action_goal);
            ret &= action_result.Equals(other.action_result);
            ret &= action_feedback.Equals(other.action_feedback);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
