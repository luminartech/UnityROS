using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ros_CSharp;

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
    public string pubOdometryTopic = "/stanford/odometry";

    /// <summary>
    /// Example subscriber topic
    /// </summary>
    public string subVector3Topic = "/stanford/vector3";

    /// <summary>
    /// Example publisher
    /// </summary>
    Publisher<Messages.nav_msgs.Odometry> pubOdometry;

    /// <summary>
    /// Example subscriber
    /// </summary>
    Subscriber<Messages.geometry_msgs.Vector3> subVector3;
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
            if (GUILayout.Button("Publish Odometry", GUILayout.Width(250), GUILayout.Height(40)))
            {
                PublishOdometryMessage();
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
            pubOdometry = nodeHandle.advertise<Messages.nav_msgs.Odometry>(pubOdometryTopic, 1, false);

            // Setup subscribers
            subVector3 = nodeHandle.subscribe<Messages.geometry_msgs.Vector3>(subVector3Topic, 1, OnReceiveVector3);
        }
        else
        {
            Debug.LogError("ROS can only be initialized once per application launch. To re-initialize ROS you must close and re-launch the application.");
        }
    }


    /// <summary>
    /// Publishes the example nav_msgs/Odometry message
    /// </summary>
    void PublishOdometryMessage()
    {
        Messages.nav_msgs.Odometry msg = new Messages.nav_msgs.Odometry()
        {
            header = new Messages.std_msgs.Header(),
            pose = new Messages.geometry_msgs.PoseWithCovariance()
            {
                pose = new Messages.geometry_msgs.Pose()
                {
                    position = new Messages.geometry_msgs.Point(),
                    orientation = new Messages.geometry_msgs.Quaternion()
                }
            },
            twist = new Messages.geometry_msgs.TwistWithCovariance()
            {
                twist = new Messages.geometry_msgs.Twist()
                {
                    linear = new Messages.geometry_msgs.Vector3(),
                    angular = new Messages.geometry_msgs.Vector3()
                }
            }
        };

        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        // Position
        msg.pose.pose.position.x = pos.x;
        msg.pose.pose.position.y = pos.y;
        msg.pose.pose.position.z = pos.z;

        // Rotation
        msg.pose.pose.orientation.x = rot.x;
        msg.pose.pose.orientation.y = rot.y;
        msg.pose.pose.orientation.z = rot.z;
        msg.pose.pose.orientation.w = rot.w;

        // Linear velocity
        msg.twist.twist.linear.x = 0f;
        msg.twist.twist.linear.y = 0f;
        msg.twist.twist.linear.z = 0f;

        // Angular velocity
        msg.twist.twist.angular.x = 0f;
        msg.twist.twist.angular.y = 0f;
        msg.twist.twist.angular.z = 0f;

        // Publish
        pubOdometry.publish(msg);
    }


    /// <summary>
    /// Callback fired when the subVector3Topic receives a message
    /// </summary>
    /// <param name="data">Received message</param>
    void OnReceiveVector3(Messages.geometry_msgs.Vector3 data)
    {
        Debug.LogFormat("Received Vector3 message: ({0}, {1}, {2})", data.x.ToString("F4"), data.y.ToString("F4"), data.z.ToString("F4"));
    }
    #endregion
}
