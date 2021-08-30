import wx
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

class MainFrame(wx.Frame):

    def __init__(self):
        wx.Frame.__init__(self, None, title='Main Frame', size=(800, 600))
        self.panel = MyPanel(self)
        self.Show()
        self.Bind(wx.EVT_CLOSE, self.OnClose)

    def OnClose(self, event):
        if self.panel.frame_number==2:
            self.panel.frame.Destroy()
        self.Destroy()


if __name__ == '__main__':
    app = wx.App(False)
    frame_init = MainFrame()
    app.MainLoop()
