#!/usr/bin/env python3
# rpi_ws281x library strandtest example
# Author: Tony DiCola (tony@tonydicola.com)
#
# Direct port of the Arduino NeoPixel library strandtest example.  Showcases
# various animations on a strip of NeoPixels.

import time
from rpi_ws281x import *
import argparse


class led:
    
    def __init__(self):
        LED_COUNT      = 16      # Number of LED pixels.
        LED_PIN        = 18      # GPIO pin connected to the pixels (18 uses PWM!).
        LED_FREQ_HZ    = 800000  # LED signal frequency in hertz (usually 800khz)
        LED_DMA        = 10      # DMA channel to use for generating signal (try 10)
        LED_BRIGHTNESS = 255     # Set to 0 for darkest and 255 for brightest
        LED_INVERT     = False   # True to invert the signal (when using NPN transistor level shift)
        LED_CHANNEL    = 0       # set to '1' for GPIOs 13, 19, 41, 45 or 53
        self.strip = Adafruit_NeoPixel(LED_COUNT, LED_PIN, LED_FREQ_HZ, LED_DMA, LED_INVERT, LED_BRIGHTNESS, LED_CHANNEL)
        self.strip.begin()
    
    
    def select_led(self,led,color,duree):
        self.color = color
        self.strip.setPixelColor(led, color)
        self.strip.show()
      #  time.sleep(duree/1000.0)
      #  color=Color(0, 0, 0)
      #  self.strip.setPixelColor(led, color)
      #  self.strip.show()
    def select_led_continue(self,led,color,duree):
        i = strip.numPixels()
        for i in range(strip.numPixels()):
            self.color = color
            self.strip.setPixelColor(led, color)
            self.strip.show()
            time.sleep(wait_ms/1000.0)
        
      #  time.sleep(duree/1000.0)
      #  color=Color(0, 0, 0)
      #  self.strip.setPixelColor(led, color)
      #  self.strip.show()

            
            
# Main program logic follows:
if __name__ == '__main__':
    # Process arguments
    parser = argparse.ArgumentParser()
    parser.add_argument('-c', '--clear', action='store_true', help='clear the display on exit')
    args = parser.parse_args()

    bandeau = led()
    color = Color(255, 0, 255)
    bandeau.select_led(4,color,100.0)
    # Create NeoPixel object with appropriate configuration.
  # bandeau.strip = Adafruit_NeoPixel(LED_COUNT, LED_PIN, LED_FREQ_HZ, LED_DMA, LED_INVERT, LED_BRIGHTNESS, LED_CHANNEL)
    # Intialize the library (must be called once before other functions).
    
    

   
    


