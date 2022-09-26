#include <SoftwareSerial.h>

#define VRX_PIN A0
#define VRY_PIN A1

SoftwareSerial btSerial(2, 3);  // RX, TX (Cross connect to HC05)

void setup() {
  Serial.begin(9600);
  btSerial.begin(9600);

  pinMode(VRX_PIN, INPUT);
  pinMode(VRY_PIN, INPUT);
}

void loop() {

  int vrx = analogRead(VRX_PIN);  // x-axis joystick
  int vry = analogRead(VRY_PIN);  // y-axis joystick

  String vrxDirection;
  String vryDirection;

  // technically I can just write if vrx == 1023 (actual exact value)
  // but I didn't want to just to be "safe"

  if (vrx > 1000) {  // exact: 1023
    vrxDirection = "R";
  } else if (vrx < 10) {  // exact: 0
    vrxDirection = "L";
  } else {               // exact: 505
    vrxDirection = "C";  // Center
  }

  if (vry > 1000) {  // exact: 1023
    vryDirection = "D";
  } else if (vry < 10) {  // exact: 0
    vryDirection = "U";
  } else {               // exact: 505
    vryDirection = "C";  // Center
  }

  vrxDirection = "vrx: " + vrxDirection;
  vryDirection = "vry: " + vryDirection;

  Serial.println(vrxDirection);
  Serial.println(vryDirection);

  btSerial.println(vrxDirection);
  btSerial.println(vryDirection);

  delay(30);
}