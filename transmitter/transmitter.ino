#include <Printers.h>
#include <XBee.h>

XBee xbee = XBee();

int serialPortVar;
int serialPortVarTheLastOne = new int();

void setup() {
  Serial.begin(9600);
  xbee.setSerial(Serial);
}

void loop() {

    serialPortVar = Serial.parseInt();
  if(&& serialPortVar != 0 && serialPortVarTheLastOne != serialPortVar)
  {
    xbee.send(serialPortVar);
    serialPortVarTheLastOne = serialPortVar;  
  }

}
