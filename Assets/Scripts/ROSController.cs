using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ros_CSharp;

/// <summary>
/// Basic example of communicating with ROS
/// </summary>
public class ROSController : MonoBehaviour
{
    #region Fields
    /// <summary>
    /// ROS Master URI
    /// </summary>
    public string rosUri = "http://localhost:11311";

    /// <summary>
    /// Name of ROS node Unity will create
    /// </summary>
    public string primaryNodeName = "UnityROS";

    /// <summary>
    /// Example publisher topic
    /// </summary>
    public string pubVector3Topic = "/stanford/vector3";

    /// <summary>
    /// Example subscriber topic for the custom node
    /// </summary>
    public string subCustomNodeTopic = "/stanford/vector3converted";

    /// <summary>
    /// Example publisher
    /// </summary>
    Publisher<Messages.geometry_msgs.Vector3> pubVector3;

    /// <summary>
    /// Example subscriber
    /// </summary>
    Subscriber<Messages.geometry_msgs.Vector3> subVector3;

    /// <summary>
    /// Example subscriber for the custom node
    /// </summary>
    Subscriber<Messages.stanford_msgs.ExampleCustom> subCustomNode;
    #endregion


    #region Methods
    /// <summary>
    /// Basic debug UI
    /// </summary>
    void OnGUI()
    {
        if (!ROS.initialized)
        {
            if (GUILayout.Button("Init ROS", GUILayout.Width(250), GUILayout.Height(40)))
            {
                InitROS();
            }
        }
        else
        {
            if (GUILayout.Button("Publish Vector3", GUILayout.Width(250), GUILayout.Height(40)))
            {
                PublishVector3();
            }
        }
    }


    /// <summary>
    /// Initializes ROS
    /// </summary>
    public void InitROS()
    {
        if (!ROS.initialized)
        {
            if (string.IsNullOrEmpty(rosUri))
            {
                UnityEngine.Debug.LogError("ROS Master URI is empty. This must be populated with the Master address of your target roscore instance.");
                return;
            }

            ROS.Init(new string[] { "__master:=" + rosUri }, primaryNodeName);
            NodeHandle nodeHandle = new NodeHandle();

            // Setup publishers
            pubVector3 = nodeHandle.advertise<Messages.geometry_msgs.Vector3>(pubVector3Topic, 1, false);


            // Setup subscribers
            subVector3 = nodeHandle.subscribe<Messages.geometry_msgs.Vector3>(pubVector3Topic, 1, OnReceiveVector3);
            subCustomNode = nodeHandle.subscribe<Messages.stanford_msgs.ExampleCustom>(subCustomNodeTopic, 1, OnReceiveCustomNodeData);
        }
        else
        {
            Debug.LogError("ROS can only be initialized once per application launch. To re-initialize ROS you must close and re-launch the application.");
        }
    }


    /// <summary>
    /// Publishes the example geometry_msgs/Vector3 message
    /// </summary>
    void PublishVector3()
    {
        Messages.geometry_msgs.Vector3 msg = new Messages.geometry_msgs.Vector3();

        msg.x = 1.0f;
        msg.y = 2.0f;
        msg.z = 3.0f;

        // Publish
        pubVector3.publish(msg);
    }


    /// <summary>
    /// Callback fired when the pubVector3 Topic receives a message
    /// </summary>
    /// <param name="data">Received message</param>
    void OnReceiveVector3(Messages.geometry_msgs.Vector3 data)
    {
        Debug.LogFormat("Received Vector3 message: ({0}, {1}, {2})", data.x.ToString("F4"), data.y.ToString("F4"), data.z.ToString("F4"));
    }


    /// <summary>
    /// Callback fired when the subCustomNode Topic receives a message
    /// </summary>
    /// <param name="data">Received message</param>
    void OnReceiveCustomNodeData(Messages.stanford_msgs.ExampleCustom data)
    {
        Debug.LogFormat("Received converted data from custom node: Input: ({0}, {1}, {2}), Output: ({3}, {4}, {5})", 
            data.input.x.ToString("F4"), data.input.y.ToString("F4"), data.input.z.ToString("F4"),
            data.output.x.ToString("F4"), data.output.y.ToString("F4"), data.output.z.ToString("F4"));
    }
    #endregion
}
