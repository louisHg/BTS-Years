import wx

#import the newly created GUI file
import Frame4


class CalcFrame(Frame4.MyFrame4):
   def __init__(self,parent):
        Frame4.MyFrame4.__init__(self,parent)
        

   def Button1click( self, event ):
            k = 0
            for k in range(101):
                k = k+1
                self.gauge.SetValue(k)
            event.Skip()
app = wx.App(False)
frame = CalcFrame(None)
frame.Show(True)
#start the applications
app.MainLoop()