import wx

class login ( wx.Panel ):

    def __init__( self, parent ):
        wx.Panel.__init__ ( self, parent, id = wx.ID_ANY, pos = wx.DefaultPosition, size = wx.Size( 800,600 ), style = wx.TAB_TRAVERSAL )

        BoxSizer01 = wx.BoxSizer( wx.VERTICAL )

        self.login_button = wx.Button( self, wx.ID_ANY, u"Login", wx.DefaultPosition, wx.DefaultSize, 0 )
        self.login_button.SetDefault() 
        BoxSizer01.Add( self.login_button, 0, wx.ALIGN_CENTER|wx.ALL, 5 )


        self.SetSizer( BoxSizer01 )
        self.Layout()

        # Connect Events
        self.login_button.Bind( wx.EVT_BUTTON, self.on_login )


    # Virtual event handlers, overide them in your derived class
    def on_login( self, event ):
        self.Hide()
        self.Parent.nb.Show()
        self.Parent.logout_button.Show()
        self.Parent.Layout()

