#include <FastLED.h>
FASTLED_USING_NAMESPACE
#define DATA_PIN 22
#define LED_TYPE WS2812B
#define COLOR_ORDER GRB
#define NUM_LEDS 360
CRGB leds[NUM_LEDS];
#define BRIGHTNESS 96
#define FRAMES_PER_SECOND 120

const int LEDValues [] = {0, 255};
const int LEDsPerSection = 30;
const int sections = 9;
int sectionPins[sections] = {A0, A1, A2, A3, A4, A5, A6, A7, A8};
float sectionRaw[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};
float sectionBuffer[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};
int sectionState[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};
float sectionRes[sections] = {0, 0, 0, 0, 0, 0, 0, 0, 0};

int resistor = 1000; // Ohms
float voltageScaler = 4.6; // Volts
int pressThreshold = 4000;

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
        sectionRaw[i] = analogRead(sectionPins[i]) / 1024.0;
        sectionBuffer[i] = (voltageScaler/sectionRaw[i]) - 1;
        sectionRes[i] = resistor*sectionBuffer[i];
        if (sectionRes[i] <= pressThreshold)
            sectionState[i] = 1;
        else
            sectionState[i] = 0;
    }
}

void setLEDs()
{
    if (sectionState[0])
    {
        for (int i = 30; i < 90 ; i++)
        {
            CRGBPalette16 palette = PartyColors_p;
            uint8_t BeatsPerMinute = 62;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            leds[i] = ColorFromPalette(palette, gHue+(i*2), beat-gHue+(i*10));
        }

    }
    else
    {
        for (int i = 30; i < 90; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[1] || (sectionState[4]))
    {
        for (int i = 0; i < 30; i++)
        {
            CRGBPalette16 palette = PartyColors_p;
            uint8_t BeatsPerMinute = 62;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            leds[i] = ColorFromPalette(palette, gHue+(i*2), beat-gHue+(i*10));
        }

    }
    else
    {
        for (int i = 0; i < 30; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[2])
    {
        for (int i = 300; i < 360; i++)
        {
            CRGBPalette16 palette = PartyColors_p;
            uint8_t BeatsPerMinute = 62;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            leds[i] = ColorFromPalette(palette, gHue+(i*2), beat-gHue+(i*10));

        }

    }
    else
    {
        for (int i = 300; i < 360; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[3] || (sectionState[4]))
    {
        for (int i = 90; i < 120; i++)
        {
            CRGBPalette16 palette = PartyColors_p;
            uint8_t BeatsPerMinute = 62;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            leds[i] = ColorFromPalette(palette, gHue+(i*2), beat-gHue+(i*10));
        }

    }
    else
    {
        for (int i = 90; i < 120; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[5] || (sectionState[4]))
    {
        for (int i = 270; i < 300; i++)
        {
            CRGBPalette16 palette = PartyColors_p;
            uint8_t BeatsPerMinute = 62;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            leds[i] = ColorFromPalette(palette, gHue+(i*2), beat-gHue+(i*10));
        }

    }
    else
    {
        for (int i = 270; i < 300; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[6])
    {
        for (int i = 120; i < 180; i++)
        {
            CRGBPalette16 palette = PartyColors_p;
            uint8_t BeatsPerMinute = 62;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            leds[i] = ColorFromPalette(palette, gHue+(i*2), beat-gHue+(i*10));
        }

    }
    else
    {
        for (int i = 120; i < 180; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[7] || (sectionState[4]))
    {
        for (int i = 180; i < 210; i++)
        {
            CRGBPalette16 palette = PartyColors_p;
            uint8_t BeatsPerMinute = 62;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            leds[i] = ColorFromPalette(palette, gHue+(i*2), beat-gHue+(i*10));
        }

    }
    else
    {
        for (int i = 180; i < 210; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }

    if (sectionState[8])
    {
        for (int i = 210; i < 270; i++)
        {
            CRGBPalette16 palette = PartyColors_p;
            uint8_t BeatsPerMinute = 62;
            uint8_t beat = beatsin8( BeatsPerMinute, 64, 255);
            leds[i] = ColorFromPalette(palette, gHue+(i*2), beat-gHue+(i*10));
        }

    }
    else
    {
        for (int i = 210; i < 270; i++)
        {
            leds[i].setRGB(0, 0, 0);
        }
    }
}
