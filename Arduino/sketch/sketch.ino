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

// int brightness = 0;    // how bright the LED is
// int fadeAmount = 5;    // how many points to fade the LED by

void loop() {
  // if (btSerial.available() > 0) {
  //   Serial.print(btSerial.readString());
  // }
  // change the brightness for next time through the loop:
  // btSerial.println(brightness);

  // brightness = brightness + fadeAmount;

  // reverse the direction of the fading at the ends of the fade:
  // if (brightness <= 0 || brightness >= 255) {
  //   fadeAmount = -fadeAmount;
  // }
  // wait for 30 milliseconds to see the dimming effect
  delay(30);
    
  int vrx = analogRead(VRX_PIN);
  int vry = analogRead(VRY_PIN);

  String vrxDirection;
  String vryDirection;

  // technically I can just write if vrx == 1023 (actual exact value)
  // but I didn't want to just to be "safe"



  if (vrx > 1000) { // exact: 1023
      vrxDirection = "R";
  } else if (vrx < 10) { // exact: 0
    vrxDirection = "L";
  } else { // exact: 505
    vrxDirection = "C"; // Center
  }

if (vry > 1000) { // exact: 1023
      vryDirection = "D";
  } else if (vry < 10) { // exact: 0
    vryDirection = "U";
  } else { // exact: 505
    vryDirection = "C"; // Center
  }
  
  vrxDirection  = "vrx: " + vrxDirection;
  vryDirection  = "vry: " + vryDirection;

  Serial.println(vrxDirection);
  Serial.println(vryDirection);

  btSerial.println(vrxDirection);
  btSerial.println(vryDirection);

}