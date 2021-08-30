import wx

#import the newly created GUI file
import Frame1
class CalcFrame(Frame1.MyFrame1):
   def __init__(self,parent):
        Frame1.MyFrame1.__init__(self,parent)

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

