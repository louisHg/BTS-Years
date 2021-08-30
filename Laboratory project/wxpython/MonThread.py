import threading
import time
from rpi_ws281x import *

from led import led


class MonThread(threading.Thread):
        def __init__(self,jusqua,event):
            threading.Thread.__init__(self)
            self.jusqua=jusqua
            self.event=event

        def run(self):
            while (1):
                print("coucou",self.jusqua)
                for i in range(0,self.jusqua):
                    print("coucou",i)
                    time.sleep(0.10)
                    self.bandeau = led()
                    color = Color(255, 0, 255)
                    self.bandeau.select_led(i,color,100.0)
                time.sleep(2)
                color = Color(0, 0, 0)
                self.bandeau.select_led(self.jusqua,color,100.0)
                self.event.set()

# event=threading.Event()
       # event.clear()
       # self.monThread=MonThread(10,event)
       # self.monThread.start()
       # event.wait()