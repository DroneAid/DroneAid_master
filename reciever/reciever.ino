#include <Printers.h>
#include <XBee.h>

XBee xbee = XBee();
XBeeResponse response = XBeeResponse();

void setup() {
  
  // start serial
  Serial.begin(9600);
  xbee.setSerial(Serial);
  
}


void loop() {
    
    xbee.readPacket();
    
    if (xbee.getResponse().isAvailable()) 
  {
      // got something
    } 
}
