#include <iostream>
#include <ros/ros.h>
#include <stanford_msgs/ExampleCustom.h>

ros::Publisher pubCustom;

void msg_cb (const geometry_msgs::Vector3ConstPtr& incomingMsg)
{
  stanford_msgs::ExampleCustom outgoingMsg;
  
  outgoingMsg.input.x = incomingMsg->x;
  outgoingMsg.input.y = incomingMsg->y;
  outgoingMsg.input.z = incomingMsg->z;
  outgoingMsg.output.x = incomingMsg->z;
  outgoingMsg.output.y = -incomingMsg->x;
  outgoingMsg.output.z = incomingMsg->y;

  pubCustom.publish(outgoingMsg);
}

int main (int argc, char** argv)
{
  // Initialize ROS connection
  ros::init(argc, argv, "stanford_example_node");
  ros::NodeHandle nh;

  // Create a ROS subscriber for the input data
  ros::Subscriber sub = nh.subscribe("/stanford/vector3", 1, msg_cb);
  
  // Create the publisher for the converted data
  pubCustom = nh.advertise<stanford_msgs::ExampleCustom>("/stanford/vector3converted", 1);

  // Spin
  ros::spin ();
}
