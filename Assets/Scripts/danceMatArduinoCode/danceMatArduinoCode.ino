const int sections = 9;
int sectionPins[sections] = {A0, A1, A2, A3, A4, A5, A6, A7, A8};
float sectionRaw[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};
float sectionBuffer[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};
int sectionState[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};

int resistor = 10; // Ohms
float voltageScaler = 4.6; // Volts
int pressThreshold = 100; // Ohms
String stringOutBuffer = String(sectionState[0])+String(sectionState[1])+String(sectionState[2])+String(sectionState[3])+String(sectionState[4])+String(sectionState[5])+String(sectionState[6])+String(sectionState[7])+String(sectionState[8])+",";

void setup() 
{
  Serial.begin(9600);
}

void loop() 
{
  String stringOut = String(sectionState[0])+String(sectionState[1])+String(sectionState[2])+String(sectionState[3])+String(sectionState[4])+String(sectionState[5])+String(sectionState[6])+String(sectionState[7])+String(sectionState[8])+",";
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
  for (int i = 0; i < sections; i++)
    sectionState[i] = random(0,2);
}

void getStates() 
{
  for (int i = 0; i < sections; i++) 
  {
    sectionRaw[i] = analogRead(sectionPins[i])*voltageScaler/1024.00;
    sectionBuffer[i] = (voltageScaler/sectionRaw[i]) - 1;
    sectionRaw[i] = resistor*sectionBuffer[i];
    if (sectionRaw[i] <= pressThreshold)
      sectionState[i] = 1;
    else 
      sectionState[i] = 0;
  }
}
