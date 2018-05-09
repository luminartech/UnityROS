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

namespace Messages.pcl_msgs
{
#if !TRACE
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public class Vertices : IRosMessage
    {

			public uint[] vertices;


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string MD5Sum() { return "39bd7b1c23763ddd1b882b97cb7cfe11"; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasHeader() { return false; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsMetaType() { return false; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string MessageDefinition() { return @"uint32[] vertices"; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override MsgTypes msgtype() { return MsgTypes.pcl_msgs__Vertices; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsServiceComponent() { return false; }

        [System.Diagnostics.DebuggerStepThrough]
        public Vertices()
        {
            
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Vertices(byte[] SERIALIZEDSTUFF)
        {
            Deserialize(SERIALIZEDSTUFF);
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Vertices(byte[] SERIALIZEDSTUFF, ref int currentIndex)
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
            
            //vertices
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(SERIALIZEDSTUFF, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (vertices == null)
                vertices = new uint[arraylength];
            else
                Array.Resize(ref vertices, arraylength);
            for (int i=0;i<vertices.Length; i++) {
                //vertices[i]
                piecesize = Marshal.SizeOf(typeof(uint));
                h = IntPtr.Zero;
                if (SERIALIZEDSTUFF.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(SERIALIZEDSTUFF, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Alloc failed");
                vertices[i] = (uint)Marshal.PtrToStructure(h, typeof(uint));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
            }
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
            
            //vertices
            hasmetacomponents |= false;
            if (vertices == null)
                vertices = new uint[0];
            pieces.Add(BitConverter.GetBytes(vertices.Length));
            for (int i=0;i<vertices.Length; i++) {
                //vertices[i]
                scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(vertices[i], h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
            }
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
            
            //vertices
            arraylength = rand.Next(10);
            if (vertices == null)
                vertices = new uint[arraylength];
            else
                Array.Resize(ref vertices, arraylength);
            for (int i=0;i<vertices.Length; i++) {
                //vertices[i]
                vertices[i] = (uint)rand.Next();
            }
        }

        public override bool Equals(IRosMessage ____other)
        {
            if (____other == null) return false;
            bool ret = true;
            pcl_msgs.Vertices other = (Messages.pcl_msgs.Vertices)____other;

            if (vertices.Length != other.vertices.Length)
                return false;
            for (int __i__=0; __i__ < vertices.Length; __i__++)
            {
                ret &= vertices[__i__] == other.vertices[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
