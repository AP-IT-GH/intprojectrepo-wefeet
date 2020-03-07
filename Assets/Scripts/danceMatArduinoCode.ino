// Analog pins for each mat section
const int section1 = A0;
const int section2 = A1;
const int section3 = A2;
const int section4 = A3;
const int section5 = A4;
const int section6 = A5;
const int section7 = A6;
const int section8 = A7;
const int section9 = A8;

// Variables for section states
int section1State = 0;
int section2State = 0;
int section3State = 0;
int section4State = 0;
int section5State = 0;
int section6State = 0;
int section7State = 0;
int section8State = 0;
int section9State = 0;

int Vcc = 5; // Volts
int pressThreshold = 1; // Volts
void setup() 
{
  // initialize serial communications at 9600 bps:
  Serial.begin(9600);
}
void loop() 
{
  //getStates();
  getDummyStates();
  String stringOut = String(section1State)+String(section2State)+String(section3State)+String(section4State)+String(section5State)+String(section6State)+String(section7State)+String(section8State)+String(section9State)+",";
  // print the results to the Serial Monitor:
  Serial.print(stringOut);
  // wait 2 milliseconds before the next loop for the analog-to-digital
  // converter to settle after the last reading:
  delay(2);
}
void getDummyStates ()
{
  section1State = random(0,2);
  section2State = random(0,2);
  section3State = random(0,2);
  section4State = random(0,2);
  section5State = random(0,2);
  section6State = random(0,2);
  section7State = random(0,2);
  section8State = random(0,2);
  section9State = random(0,2);
}
void getStates() 
{
  // Analog readings converted to voltage and tested if pressed
  section1State = analogRead(section1)*Vcc/1024.00;
  if (section1State <= pressThreshold)
    section1State = 1;
  else
    section1State = 0;
    
  section2State = analogRead(section2)*Vcc/1024.00;
  if (section2State <= pressThreshold)
    section2State = 1;
  else
    section2State = 0;
    
  section3State = analogRead(section3)*Vcc/1024.00;
  if (section3State <= pressThreshold)
    section3State = 1;
  else
    section3State = 0;
    
  section4State = analogRead(section4)*Vcc/1024.00;
  if (section4State <= pressThreshold)
    section4State = 1;
  else
    section4State = 0;
    
  section5State = analogRead(section5)*Vcc/1024.00;
  if (section5State <= pressThreshold)
    section5State = 1;
  else
    section5State = 0;
  
  section6State = analogRead(section6)*Vcc/1024.00;
  if (section6State <= pressThreshold)
    section6State = 1;
  else
    section6State = 0;

  section7State = analogRead(section7)*Vcc/1024.00;
  if (section7State <= pressThreshold)
    section7State = 1;
  else
    section7State = 0;
    
  section8State = analogRead(section8)*Vcc/1024.00;
  if (section8State <= pressThreshold)
    section8State = 1;
  else
    section8State = 0;
  
  section9State = analogRead(section9)*Vcc/1024.00;
  if (section9State <= pressThreshold)
    section9State = 1;
  else
    section9State = 0;
}
