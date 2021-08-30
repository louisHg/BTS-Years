import wx
import random
from LoginPanel import LoginPanel

class TabPanel(wx.Panel):
    #----------------------------------------------------------------------
    def __init__(self, parent):
        """"""
        wx.Panel.__init__(self, parent=parent)
        
        colors = ["red", "blue", "gray", "yellow", "green"]
        self.SetBackgroundColour(random.choice(colors))
        
        btn = wx.Button(self, label="Press Me")
        sizer = wx.BoxSizer(wx.VERTICAL)
        sizer.Add(btn, 0, wx.ALL, 10)
        self.SetSizer(sizer)
    


class MyFrame ( wx.Frame ):

    def __init__( self, parent ):
        wx.Frame.__init__ ( self, parent, id = wx.ID_ANY, title = u"Gestion laboratoire", pos = wx.DefaultPosition, size = wx.Size( 800,600 ), style = wx.DEFAULT_FRAME_STYLE|wx.TAB_TRAVERSAL )

        self.SetSizeHintsSz( wx.DefaultSize, wx.DefaultSize )
#debut contenu
        BoxSizer0 = wx.BoxSizer( wx.VERTICAL )
        
        
        
        # Add login panel
        self.login_panel = LoginPanel(self)
        BoxSizer0.Add(self.login_panel, 1, wx.EXPAND | wx.ALL, 0)
        
        
        
        # Add notebook panel and its pages
        self.nb = wx.Notebook( self, wx.ID_ANY, wx.DefaultPosition, wx.DefaultSize, 0 )#
        tab_one = TabPanel( self.nb )
        self.nb.AddPage(tab_one, 'Gestion laboratoire')
        sizer = wx.BoxSizer(wx.VERTICAL)
        sizer.Add(self.nb, 1, wx.ALL|wx.EXPAND, 5)
        self.SetSizer(sizer)
        
        # End notebook       
        
        
               
        BoxSizer0.Add( self.nb, 1, wx.EXPAND |wx.ALL, 0 )

        # Adds a logout button
        self.logout_button = wx.Button( self, wx.ID_ANY, u"Logout", wx.DefaultPosition, wx.DefaultSize, 0 )
        BoxSizer0.Add( self.logout_button, 0, wx.ALIGN_CENTER|wx.ALL, 5 )

        # Hide nb and logout button
        self.nb.Hide()
        self.logout_button.Hide()


        self.SetSizer( BoxSizer0 )
        self.Layout()

        self.Centre( wx.BOTH )
        self.Show()

        # Connect Events
        self.logout_button.Bind( wx.EVT_BUTTON, self.on_logout )

    # Virtual event handlers, override them in your derived class
    def on_logout( self, event ):
        self.nb.Hide()
        self.logout_button.Hide()
        self.login_panel.Show()
        self.Layout()

if __name__ == "__main__":
    app = wx.App()
    MyFrame(None)
    app.MainLoop()

