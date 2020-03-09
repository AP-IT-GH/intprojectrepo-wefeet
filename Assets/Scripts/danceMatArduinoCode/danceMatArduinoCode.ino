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
float section1Raw = 0;
float section2Raw = 0;
float section3Raw = 0;
float section4Raw = 0;
float section5Raw = 0;
float section6Raw = 0;
float section7Raw = 0;
float section8Raw = 0;
float section9Raw = 0;

float section1Buffer = 0;
float section2Buffer = 0;
float section3Buffer = 0;
float section4Buffer = 0;
float section5Buffer = 0;
float section6Buffer = 0;
float section7Buffer = 0;
float section8Buffer = 0;
float section9Buffer = 0;

int section1State = 0;
int section2State = 0;
int section3State = 0;
int section4State = 0;
int section5State = 0;
int section6State = 0;
int section7State = 0;
int section8State = 0;
int section9State = 0;

int resistor = 10; // Ohms
float voltageScaler = 4.6; // Volts
int pressThreshold = 100; // Ohms
String stringOutBuffer = String(section1State)+String(section2State)+String(section3State)+String(section4State)+String(section5State)+String(section6State)+String(section7State)+String(section8State)+String(section9State)+",";
void setup() 
{
  // initialize serial communications at 9600 bps:
  Serial.begin(9600);
}
void loop() 
{
  String stringOut = String(section1State)+String(section2State)+String(section3State)+String(section4State)+String(section5State)+String(section6State)+String(section7State)+String(section8State)+String(section9State)+",";
  getStates();
  //getDummyStates();
  
  // print the results to the Serial Monitor:
  if (stringOut != stringOutBuffer)
      Serial.print(stringOut);
      
  stringOutBuffer = stringOut;
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
  section1Raw = analogRead(section1)*voltageScaler/1024.00;
  section1Buffer = (voltageScaler/section1Raw) - 1;
  section1Raw = resistor*section1Buffer;
  if (section1Raw <= pressThreshold)
    section1State = 1;
  else 
    section1State = 0;

  section2Raw = analogRead(section2)*voltageScaler/1024.00;
  section2Buffer = (voltageScaler/section2Raw) - 1;
  section2Raw = resistor*section2Buffer;
  if (section2Raw <= pressThreshold)
    section2State = 1;
  else 
    section2State = 0;

  section3Raw = analogRead(section3)*voltageScaler/1024.00;
  section3Buffer = (voltageScaler/section3Raw) - 1;
  section3Raw = resistor*section3Buffer;
  if (section3Raw <= pressThreshold)
    section3State = 1;
  else 
    section3State = 0;

  section4Raw = analogRead(section4)*voltageScaler/1024.00;
  section4Buffer = (voltageScaler/section4Raw) - 1;
  section4Raw = resistor*section4Buffer;
  if (section4Raw <= pressThreshold)
    section4State = 1;
  else 
    section4State = 0;

  section5Raw = analogRead(section5)*voltageScaler/1024.00;
  section5Buffer = (voltageScaler/section5Raw) - 1;
  section5Raw = resistor*section5Buffer;
  if (section5Raw <= pressThreshold)
    section5State = 1;
  else 
    section5State = 0;

  section6Raw = analogRead(section6)*voltageScaler/1024.00;
  section6Buffer = (voltageScaler/section6Raw) - 1;
  section6Raw = resistor*section6Buffer;
  if (section6Raw <= pressThreshold)
    section6State = 1;
  else 
    section6State = 0;

  section7Raw = analogRead(section7)*voltageScaler/1024.00;
  section7Buffer = (voltageScaler/section7Raw) - 1;
  section7Raw = resistor*section7Buffer;
  if (section7Raw <= pressThreshold)
    section7State = 1;
  else 
    section7State = 0;

  section8Raw = analogRead(section8)*voltageScaler/1024.00;
  section8Buffer = (voltageScaler/section8Raw) - 1;
  section8Raw = resistor*section8Buffer;
  if (section8Raw <= pressThreshold)
    section8State = 1;
  else 
    section8State = 0;

  section9Raw = analogRead(section9)*voltageScaler/1024.00;
  section9Buffer = (voltageScaler/section9Raw) - 1;
  section9Raw = resistor*section9Buffer;
  if (section9Raw <= pressThreshold)
    section9State = 1;
  else 
    section9State = 0;
}
