import time
from Balance import *
import mysql.connector

balance=Balance("/dev/ttyUSB0")   #modifier
if balance.connect()==0:
    print ("error port or thread balance ")
    exit()


try:
    while(1):
         
         
        if balance.recu==1:
               print (balance.message)
               balance.recu=0
         


except KeyboardInterrupt:                               #interruption clavier
    pass
balance.stop_Balance()


