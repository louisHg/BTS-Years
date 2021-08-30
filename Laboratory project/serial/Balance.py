import serial, time
import threading
from binascii import hexlify

class Balance(serial.Serial):
    def __init__(self,com):
        serial.Serial.__init__(self)
        self.port = com
        self.baudrate = 9600
        self.bytesize = serial.EIGHTBITS #number of bits per bytes
        self.parity = serial.PARITY_NONE #set parity check: no parity
        self.stopbits = serial.STOPBITS_ONE #number of stop bits
        #ser.timeout = None          #block read
        self.timeout = 1            #non-block read
        #ser.timeout = 2              #time out block read
        self.xonxoff = False     #disable software flow control
        self.rtscts = False     #disable hardware (RTS/CTS) flow control
        self.dsrdtr = False       #disable hardware (DSR/DTR) flow control
        self.writeTimeout = 2     #timeout for write
        self._thread_en_vie=0
        self.recu=0
        self.message=[]
        self.connecte=0
        

    def connect(self):

        try:
            self._thread_en_vie=1
            self._thread = threading.Thread(target=self.read_from_port, args=())
            self._thread.start()
            self.open()
            return 1

        except:
            
            self._thread_en_vie=0
            return 0

    def stop_Balance(self):
        self._thread_en_vie=0
        self._thread.join()
        self.close()


    def read_from_port(self):
        temps=0
        while self._thread_en_vie:
           try:
               data = self.readline()
               #print data
               if len(data)>0:
                    
                    self.message=data.split()
                    self.recu=1
                    temps=0
                    self.connecte=1
               
               else:
                    if temps<3:
                       temps=temps+1
                       self.message=["","","NM"]
                       self.recu=1
                    else:
                       self.connecte=0
                       temps=0
               if self.connecte==0:
                   self.message=["","","NC"]
                   self.recu=1

           except:
            pass
