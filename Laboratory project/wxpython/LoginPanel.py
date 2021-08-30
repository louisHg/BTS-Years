import wx

class LoginPanel ( wx.Panel ):

    def __init__( self, parent ):
        wx.Panel.__init__ ( self, parent, id = wx.ID_ANY, pos = wx.DefaultPosition, size = wx.Size( 800,800 ), style = wx.TAB_TRAVERSAL )
        BoxSizer01 = wx.BoxSizer( wx.VERTICAL )
        BoxSizer1 = wx.BoxSizer( wx.VERTICAL )
        
        self.m_staticText1 = wx.StaticText( self, wx.ID_ANY, u"Page de connexion", wx.DefaultPosition, wx.DefaultSize, wx.ALIGN_CENTRE )
        self.m_staticText1.Wrap( -1 )
        self.m_staticText1.SetFont( wx.Font( 20, 70, 90, 90, False, wx.EmptyString ) )
        
        
        BoxSizer1.Add( self.m_staticText1, 0, wx.ALL|wx.EXPAND, 5 )
        BoxSizer01.Add( BoxSizer1, 0, wx.EXPAND, 5 )
        
        BoxSizer3 = wx.BoxSizer( wx.HORIZONTAL )
        self.m_staticText2 = wx.StaticText( self, wx.ID_ANY, u"Identifiant     ", wx.DefaultPosition, wx.DefaultSize, 0 )
        self.m_staticText2.Wrap( -1 )
        self.m_staticText2.SetFont( wx.Font( 12, 70, 90, 90, False, wx.EmptyString ) )
        self.m_textCtrl1 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        
        BoxSizer3.Add( self.m_staticText2, 0, wx.ALL|wx.EXPAND, 5 )
        BoxSizer3.Add( self.m_textCtrl1, 1, wx.ALL, 5 )
        BoxSizer01.Add( BoxSizer3, 0, wx.EXPAND, 5 )
        
        BoxSizer4 = wx.BoxSizer( wx.HORIZONTAL )

        self.m_staticText3 = wx.StaticText( self, wx.ID_ANY, u"Mot de passe", wx.DefaultPosition, wx.DefaultSize, 0 )
        self.m_staticText3.Wrap( -1 )
        self.m_staticText3.SetFont( wx.Font( 12, 70, 90, 90, False, wx.EmptyString ) )
        self.m_textCtrl2 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        
        BoxSizer4.Add( self.m_staticText3, 0, wx.ALL, 5 )
        BoxSizer4.Add( self.m_textCtrl2, 1, wx.ALL, 5 )
        
        BoxSizer01.Add( BoxSizer4, 0, wx.EXPAND, 5 )
#fin contenu


        

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
