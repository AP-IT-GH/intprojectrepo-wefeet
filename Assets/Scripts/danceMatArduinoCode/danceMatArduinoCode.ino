#include <FastLED.h>
#define LED_PIN 22
#define NUM_LEDS 180 //360
CRGB leds[NUM_LEDS];
const int LEDsPerSection = 30;
const int sections = 9;
int sectionPins[sections] = {A0, A1, A2, A3, A4, A5, A6, A7, A8};
float sectionRaw[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};
float sectionBuffer[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};
int sectionState[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};

int resistor = 10; // Ohms
float voltageScaler = 4.6; // Volts
int pressThreshold = 100; // Ohms
int TEMPpressThreshold = 1;
String stringOutBuffer = String(sectionState[0])+String(sectionState[1])+String(sectionState[2])+String(sectionState[3])+String(sectionState[4])+String(sectionState[5])+String(sectionState[6])+String(sectionState[7])+String(sectionState[8])+",";
int clearLEDs = 0;
void setup()
{
    Serial.begin(9600);
    FastLED.addLeds<WS2812, LED_PIN, GRB>(leds, NUM_LEDS);
}

void loop()
{
    String stringOut = String(sectionState[0])+String(sectionState[1])+String(sectionState[2])+String(sectionState[3])+String(sectionState[4])+String(sectionState[5])+String(sectionState[6])+String(sectionState[7])+String(sectionState[8])+",";
    getStates();
    //getDummyStates();
    // print the results to the Serial Monitor:
    if (stringOut != stringOutBuffer)
    {
        Serial.print(stringOut);
        setLEDs();
    }
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
        /*
        sectionBuffer[i] = (voltageScaler/sectionRaw[i]) - 1;
        sectionRaw[i] = resistor*sectionBuffer[i];
        if (sectionRaw[i] <= pressThreshold)
            sectionState[i] = 1;
        else
            sectionState[i] = 0;
        */
        if (sectionRaw[i] >= TEMPpressThreshold)
            sectionState[i] = 1;
        else
            sectionState[i] = 0;

    }
}
void setLEDs()
{
    int offset = 0;

    if (sectionState[0])
    {
        offset = 0;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {
            int r = random(0, 256);
            int g = random(0, 256);
            int b = random(0, 256);
            leds[i] = CRGB(r, g, b);
        }

    }
    else
    {
        offset = 0;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {
            leds[i] = CRGB(0, 0, 0);
        }
    }

    if (sectionState[1])
    {
        offset = 60;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {
            int r = random(0, 256);
            int g = random(0, 256);
            int b = random(0, 256);
            leds[i] = CRGB(r, g, b);
        }

    }
    else
    {
        offset = 60;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {
            leds[i] = CRGB(0, 0, 0);
        }
    }

    if (sectionState[2])
    {
        offset = 90;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {
            int r = random(0, 256);
            int g = random(0, 256);
            int b = random(0, 256);
            leds[i] = CRGB(r, g, b);
        }

    }
    else
    {
        offset = 90;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {
            leds[i] = CRGB(0, 0, 0);
        }
    }

    /*   if (sectionState[3])
       {
           offset = 300;
           for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
           {
               int r = random(0, 256);
               int g = random(0, 256);
               int b = random(0, 256);
               leds[i] = CRGB(r, g, b);
           }

       }
       else
       {
           offset = 300;
           for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
           {
               leds[i] = CRGB(0, 0, 0);
           }
       }

       if (sectionState[4])
       {
           for (int i = 0; i < LEDsPerSection; i++)
           {
               int r = random(0, 256);
               int g = random(0, 256);
               int b = random(0, 256);
               leds[i+60] = CRGB(r, g, b);
               leds[i+150] = CRGB(r, g, b);
               leds[i+240] = CRGB(r, g, b);
               leds[i+300] = CRGB(r, g, b);
           }

       }
       else
       {
           for (int i = 0; i < LEDsPerSection; i++)
           {
               leds[i+60] = CRGB(0, 0, 0);
               leds[i+150] = CRGB(0, 0, 0);
               leds[i+240] = CRGB(0, 0, 0);
               leds[i+300] = CRGB(0, 0, 0);
           }
       }
    */
    if (sectionState[5])
    {
        offset = 150;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {
            int r = random(0, 256);
            int g = random(0, 256);
            int b = random(0, 256);
            leds[i] = CRGB(r, g, b);
        }

    }
    else
    {
        offset = 150;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {
            leds[i] = CRGB(0, 0, 0);
        }
    }
    /*
        if (sectionState[6])
        {
            offset = 270;
            for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
            {
                int r = random(0, 256);
                int g = random(0, 256);
                int b = random(0, 256);
                leds[i] = CRGB(r, g, b);
            }

        }
        else
        {
            offset = 270;
            for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
            {
                leds[i] = CRGB(0, 0, 0);
            }
        }

        if (sectionState[7])
        {
            offset = 240;
            for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
            {
                int r = random(0, 256);
                int g = random(0, 256);
                int b = random(0, 256);
                leds[i] = CRGB(r, g, b);
            }

        }
        else
        {
            for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
            {
                leds[i] = CRGB(0, 0, 0);
            }
        }

        if (sectionState[8])
        {
            offset = 180;
            for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
            {
                int r = random(0, 256);
                int g = random(0, 256);
                int b = random(0, 256);
                leds[i] = CRGB(r, g, b);
            }

        }
        else
        {
            offset = 240;
            for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
            {
                leds[i] = CRGB(0, 0, 0);
            }
        }
    */
    FastLED.show();
}
