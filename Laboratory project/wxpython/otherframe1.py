#-------------------------------------------------------------------------------
# Name:        module1
# Purpose:
#
# Author:      HUYGHE.L
#
# Created:     08/02/2021
# Copyright:   (c) HUYGHE.L 2021
# Licence:     <your licence>
#-------------------------------------------------------------------------------
import wx
import Frame3

class OtherFrame(wx.Frame):
    """
    Class used for creating frames other than the main one
    """

    def __init__(self, title, parent=None):
        wx.Frame.__init__(self, parent=parent, title=title)
        self.Bind(wx.EVT_CLOSE, self.OnClose)
        self.Show()
        self.parent=parent

    def OnClose(self,event):
        self.parent.frame_number=1
        self.Destroy()

class MyPanel(wx.Panel):

    def __init__(self, parent):
        wx.Panel.__init__(self, parent)
        btn = wx.Button(self, label='Create New Frame')
        btn.Bind(wx.EVT_BUTTON, self.on_new_frame)
        self.frame_number = 1

    def on_new_frame(self, event):
        if self.frame_number ==1:
            title = 'SubFrame {}'.format(self.frame_number)
            self.frame = OtherFrame(title,self)
            self.frame_number += 1

class MainFrame(Frame3.MyFrame3):

    def __init__(self,parent):
        Frame3.MyFrame3.__init__(self,parent)
        self.panel = MyPanel(self)
        self.Show(True)
        self.Bind(wx.EVT_CLOSE, self.OnClose)

    def Button5click( self, event ):
        self.m_textCtrl3.SetValue("bonjour")
        event.Skip()

    def OnClose(self, event):
        if self.panel.frame_number==2:
            self.panel.frame.Destroy()
        self.Destroy()



if __name__ == '__main__':
    app = wx.App(False)
    frame = MainFrame(None)
    app.MainLoop()
