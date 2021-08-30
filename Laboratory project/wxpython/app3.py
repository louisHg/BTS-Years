import wx

#import the newly created GUI file
import Frame3
class CalcFrame(Frame3.MyFrame3):
   def __init__(self,parent):
        Frame3.MyFrame3.__init__(self,parent)

   def Button5click( self, event ):
            self.m_textCtrl3.SetValue("bonjour")
            event.Skip()
   def Button4click( self, event ):
            frame.Show(False)
            self.Close()
app = wx.App(False)
frame = CalcFrame(None)
frame.Show(True)
#start the applications
app.MainLoop()
