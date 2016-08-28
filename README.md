# DroneAid_master

#Getting Started

The solution includes two projects for the use of the application. 

A Windows Phone Mobile Application was implemented in the 8.0 version (Silverlight) which can communicate through web service with a central server which can communicate with an Arduino Board which has an xbee on it for a peer-to-peer communication with the drone.

By choosing the key "Emergency Button", the location of the device is being collected and it's sent back to the server through Web Service. The Web service returns the location of the drone, the distance in meters, and the time it needs to reach the user. The data is being analyzed and are being projected on the screen, alongside with the drone's live tracking.


	

Just for completeness.

You can also add images with simple HTML tags:

<p align="center">
  <img src="your_relative_path_here" width="350"/>
  <img src="http://imgur.com/a/DsOTV" width="350"/>
</p>

![alt tag](http://imgur.com/a/DsOTV)


A web service was developed, using Visual Studio 2013. To be more specific, the .NET Web Api technology was used.
The HTTP GET call public DroneAidTransferInformation SetGeolocation(string longtitude, string latitdude) accepts as parameters the latitude and longtitude of the user and then it  communicates serially with the smart board "Arduino" for the piloting of the drone.

At last, it calculates and returns the distance and the time the drone will need to reach the user's location. The data is returned in Json form. At the web.config file of the web service, the geolocation of the server and the initial drone location can be set, as well as the baudrate for the serial communication with the Arduino, the serial port com which has been chosen, and the location of the log text file for the recording and pumping of information about possible exceptions.
As regards the Arduino, there has been a code adjustment for the communication between the two xbee boards. The first xbee is on the Arduino board and sends the information from the serial port to the second xbee which is atattched to the drone. 
In the following files you will find the web service project, the arduino code for the xbee transmitter and the xbee reciever as well as the source code of the mobile application.

#Website
http://droneaid.azurewebsites.net/
