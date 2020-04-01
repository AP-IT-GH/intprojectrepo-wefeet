#include <FastLED.h>
FASTLED_USING_NAMESPACE
#define DATA_PIN 22
#define LED_TYPE WS2812B
#define COLOR_ORDER GRB
#define NUM_LEDS 180 // tot = 360
CRGB leds[NUM_LEDS];
#define BRIGHTNESS 96
#define FRAMES_PER_SECOND 120

const int LEDsPerSection = 30;
const int sections = 9;
int sectionPins[sections] = {A0, A1, A2, A3, A4, A5, A6, A7, A8};
float sectionRaw[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};
float sectionBuffer[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};
int sectionState[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};

int resistor = 10; // Ohms
float voltageScaler = 4.6; // Volts
int pressThreshold = 100; // Ohms

void setup()
{
    delay(3000); // 3 second delay for recovery
    Serial.begin(9600);
    // tell FastLED about the LED strip configuration
    FastLED.addLeds<LED_TYPE,DATA_PIN,COLOR_ORDER>(leds, NUM_LEDS).setCorrection(TypicalLEDStrip);
    // set master brightness control
    FastLED.setBrightness(BRIGHTNESS);
}

uint8_t gHue = 0; // rotating "base color"
String stringOutBuffer = String(sectionState[0])+String(sectionState[1])+String(sectionState[2])+String(sectionState[3])+String(sectionState[4])+String(sectionState[5])+String(sectionState[6])+String(sectionState[7])+String(sectionState[8])+",";

void loop()
{
    String stringOut = String(sectionState[0])+String(sectionState[1])+String(sectionState[2])+String(sectionState[3])+String(sectionState[4])+String(sectionState[5])+String(sectionState[6])+String(sectionState[7])+String(sectionState[8])+",";
    getStates();
    setLEDs();
    // print the results to the Serial Monitor:
    if (stringOut != stringOutBuffer)
    {
        Serial.print(stringOut);
    }
    // send the 'leds' array out to the actual LED strip
    FastLED.show();
    // insert a delay to keep the framerate modest
    FastLED.delay(1000/FRAMES_PER_SECOND);

    // do some periodic updates
    EVERY_N_MILLISECONDS(20)
    {
        gHue++;    // slowly cycle the "base color" through the rainbow
    }

    stringOutBuffer = stringOut;

    // wait 2 milliseconds before the next loop for the analog-to-digital
    // converter to settle after the last reading:
    delay(2);
}

void getStates()
{
    for (int i = 0; i < sections; i++)
    {

        sectionBuffer[i] = (voltageScaler/sectionRaw[i]) - 1;
        sectionRaw[i] = resistor*sectionBuffer[i];
        if (sectionRaw[i] <= pressThreshold)
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

            // colored stripes pulsing at a defined Beats-Per-Minute (BPM)
            uint8_t BeatsPerMinute = 62;
            CRGBPalette16 palette = PartyColors_p;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            for (int k = 0; k < i; k++)  //9948
            {
                leds[k] = ColorFromPalette(palette, gHue+(k*2), beat-gHue+(k*10));
            }
        }

    }
    else
    {
        offset = 0;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[1])
    {
        offset = 60;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {

            // colored stripes pulsing at a defined Beats-Per-Minute (BPM)
            uint8_t BeatsPerMinute = 62;
            CRGBPalette16 palette = PartyColors_p;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            for (int k = 0; k < i; k++)  //9948
            {
                leds[k] = ColorFromPalette(palette, gHue+(k*2), beat-gHue+(k*10));
            }
        }

    }
    else
    {
        offset = 60;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[2])
    {
        offset = 90;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {

            // colored stripes pulsing at a defined Beats-Per-Minute (BPM)
            uint8_t BeatsPerMinute = 62;
            CRGBPalette16 palette = PartyColors_p;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            for (int k = 0; k < i; k++)  //9948
            {
                leds[k] = ColorFromPalette(palette, gHue+(k*2), beat-gHue+(k*10));
            }
        }

    }
    else
    {
        offset = 90;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }
/*
    if (sectionState[3])
    {
        offset = 300;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {

            // colored stripes pulsing at a defined Beats-Per-Minute (BPM)
            uint8_t BeatsPerMinute = 62;
            CRGBPalette16 palette = PartyColors_p;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            for (int k = 0; k < i; k++)  //9948
            {
                leds[k] = ColorFromPalette(palette, gHue+(k*2), beat-gHue+(k*10));
            }
        }

    }
    else
    {
        offset = 300;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[4])
    {
        for (int i = 0; i < LEDsPerSection; i++)
        {
            // random colored speckles that blink in and fade smoothly
            fadeToBlackBy( leds, i, 10);
            int pos = random16(i);
            leds[pos+60] += CHSV(gHue + random8(64), 200, 255);
            leds[pos+150] += CHSV(gHue + random8(64), 200, 255);
            leds[pos+240] += CHSV(gHue + random8(64), 200, 255);
            leds[pos+300] += CHSV(gHue + random8(64), 200, 255);
        }

    }
    else
    {
        for (int i = 0; i < LEDsPerSection; i++)
        {
            leds[i+60].setRGB(0, 0, 0);
            leds[i+150].setRGB(0, 0, 0);
            leds[i+240].setRGB(0, 0, 0);
            leds[i+300].setRGB(0, 0, 0);
        }
    }
*/
    if (sectionState[5])
    {
        offset = 150;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {

            // colored stripes pulsing at a defined Beats-Per-Minute (BPM)
            uint8_t BeatsPerMinute = 62;
            CRGBPalette16 palette = PartyColors_p;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            for (int k = 0; k < i; k++)  //9948
            {
                leds[k] = ColorFromPalette(palette, gHue+(k*2), beat-gHue+(k*10));
            }
        }

    }
    else
    {
        offset = 150;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }
/*
    if (sectionState[6])
    {
        offset = 270;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {

            // colored stripes pulsing at a defined Beats-Per-Minute (BPM)
            uint8_t BeatsPerMinute = 62;
            CRGBPalette16 palette = PartyColors_p;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            for (int k = 0; k < i; k++)  //9948
            {
                leds[k] = ColorFromPalette(palette, gHue+(k*2), beat-gHue+(k*10));
            }
        }

    }
    else
    {
        offset = 270;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[7])
    {
        offset = 240;
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {

            // colored stripes pulsing at a defined Beats-Per-Minute (BPM)
            uint8_t BeatsPerMinute = 62;
            CRGBPalette16 palette = PartyColors_p;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            for (int k = 0; k < i; k++)  //9948
            {
                leds[k] = ColorFromPalette(palette, gHue+(k*2), beat-gHue+(k*10));
            }
        }

    }
    else
    {
        for (int i = 0 + offset; i < LEDsPerSection + offset; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[8])
    {
        offset = 180;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {

            // colored stripes pulsing at a defined Beats-Per-Minute (BPM)
            uint8_t BeatsPerMinute = 62;
            CRGBPalette16 palette = PartyColors_p;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            for (int k = 0; k < i; k++)  //9948
            {
                leds[k] = ColorFromPalette(palette, gHue+(k*2), beat-gHue+(k*10));
            }
        }

    }
    else
    {
        offset = 240;
        for (int i = 0 + offset; i < 2*LEDsPerSection + offset; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }
*/
}
