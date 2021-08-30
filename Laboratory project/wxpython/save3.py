import wx
from login import login

class MyFrame ( wx.Frame ):

    def __init__( self, parent ):
        wx.Frame.__init__ ( self, parent, id = wx.ID_ANY, title = u"Page de connexion", pos = wx.DefaultPosition, size = wx.Size( 800,600 ), style = wx.DEFAULT_FRAME_STYLE|wx.TAB_TRAVERSAL )

        self.SetSizeHintsSz( wx.DefaultSize, wx.DefaultSize )

        BoxSizer0 = wx.BoxSizer( wx.VERTICAL )
        
        self.m_staticText1 = wx.StaticText( self, wx.ID_ANY, u"Page de connexion", wx.DefaultPosition, wx.DefaultSize, wx.ALIGN_CENTRE )
        self.m_staticText1.Wrap( -1 )
        self.m_staticText1.SetFont( wx.Font( 20, 70, 90, 90, False, wx.EmptyString ) )
        
        
        BoxSizer0.Add( self.m_staticText1, 0, wx.ALL|wx.EXPAND, 5 )
        
        BoxSizer2 = wx.BoxSizer( wx.HORIZONTAL )
        self.m_staticText2 = wx.StaticText( self, wx.ID_ANY, u"Identifiant", wx.DefaultPosition, wx.DefaultSize, 0 )
        self.m_staticText2.Wrap( -1 )
        self.m_staticText2.SetFont( wx.Font( 12, 70, 90, 90, False, wx.EmptyString ) )
        self.m_textCtrl1 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        
        BoxSizer2.Add( self.m_staticText2, 0, wx.ALL|wx.EXPAND, 5 )
        BoxSizer2.Add( self.m_textCtrl1, 1, wx.ALL, 5 )
        BoxSizer0.Add( BoxSizer2, 0, wx.EXPAND, 5 )
        
        BoxSizer3 = wx.BoxSizer( wx.HORIZONTAL )

        self.m_staticText3 = wx.StaticText( self, wx.ID_ANY, u"Mot de passe", wx.DefaultPosition, wx.DefaultSize, 0 )
        self.m_staticText3.Wrap( -1 )
        self.m_staticText3.SetFont( wx.Font( 12, 70, 90, 90, False, wx.EmptyString ) )
        self.m_textCtrl2 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        
        BoxSizer3.Add( self.m_staticText3, 0, wx.ALL, 5 )
        BoxSizer3.Add( self.m_textCtrl2, 1, wx.ALL, 5 )
        
        BoxSizer0.Add( BoxSizer3, 0, wx.EXPAND, 5 )
        
        # Add login panel
        self.login_panel = login(self)
        BoxSizer0.Add(self.login_panel, 1, wx.EXPAND | wx.ALL, 0)
#valider
        
        # Add notebook panel and its pages
        self.nb = wx.Notebook( self, wx.ID_ANY, wx.DefaultPosition, wx.DefaultSize, 0 )
        self.nb_subpanel1 = wx.Panel( self.nb, wx.ID_ANY, wx.DefaultPosition, wx.DefaultSize, wx.TAB_TRAVERSAL )
        self.nb.AddPage( self.nb_subpanel1, u"something", False )
        self.nb_subpanel2 = wx.Panel( self.nb, wx.ID_ANY, wx.DefaultPosition, wx.DefaultSize, wx.TAB_TRAVERSAL )
        self.nb.AddPage( self.nb_subpanel2, u"something else", False )

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

