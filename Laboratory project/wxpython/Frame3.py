
import wx
import wx.xrc

###########################################################################
## Class MyFrame3
###########################################################################

class MyFrame3 ( wx.Frame ):

	def __init__( self, parent ):
		wx.Frame.__init__ ( self, parent, id = wx.ID_ANY, title = wx.EmptyString, pos = wx.DefaultPosition, size = wx.Size( 793,320 ), style = wx.DEFAULT_FRAME_STYLE|wx.TAB_TRAVERSAL )

		self.SetSizeHintsSz( wx.DefaultSize, wx.DefaultSize )

		bSizer9 = wx.BoxSizer( wx.VERTICAL )

		self.m_staticText6 = wx.StaticText( self, wx.ID_ANY, u"Gestion laboratoire", wx.DefaultPosition, wx.DefaultSize, wx.ALIGN_CENTRE )
		self.m_staticText6.Wrap( -1 )
		self.m_staticText6.SetFont( wx.Font( 30, 70, 90, 90, False, wx.EmptyString ) )

		bSizer9.Add( self.m_staticText6, 0, wx.ALL|wx.EXPAND, 5 )

		bSizer10 = wx.BoxSizer( wx.HORIZONTAL )

		self.m_staticText7 = wx.StaticText( self, wx.ID_ANY, u"Nombre de led :", wx.DefaultPosition, wx.DefaultSize, 0 )
		self.m_staticText7.Wrap( -1 )
		self.m_staticText7.SetFont( wx.Font( 10, 70, 90, 90, False, wx.EmptyString ) )

		bSizer10.Add( self.m_staticText7, 0, wx.ALL, 5 )

		self.m_textCtrl3 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer10.Add( self.m_textCtrl3, 0, wx.ALL, 5 )


		bSizer9.Add( bSizer10, 0, wx.EXPAND, 5 )

		bSizer12 = wx.BoxSizer( wx.VERTICAL )

		self.m_button5 = wx.Button( self, wx.ID_ANY, u"MyButton", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer12.Add( self.m_button5, 0, wx.ALL, 5 )


		bSizer9.Add( bSizer12, 0, wx.EXPAND, 5 )

		bSizer13 = wx.BoxSizer( wx.HORIZONTAL )

		self.m_staticText8 = wx.StaticText( self, wx.ID_ANY, u"Poid actuel de la balance", wx.DefaultPosition, wx.DefaultSize, 0 )
		self.m_staticText8.Wrap( -1 )
		self.m_staticText8.SetFont( wx.Font( 10, 70, 90, 90, False, wx.EmptyString ) )

		bSizer13.Add( self.m_staticText8, 0, wx.ALL, 5 )

		self.m_textCtrl4 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer13.Add( self.m_textCtrl4, 0, wx.ALL, 5 )


		bSizer9.Add( bSizer13, 0, wx.EXPAND, 5 )

		bSizer14 = wx.BoxSizer( wx.VERTICAL )

		self.m_button6 = wx.Button( self, wx.ID_ANY, u"MyButton", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer14.Add( self.m_button6, 0, wx.ALL, 5 )


		bSizer9.Add( bSizer14, 0, wx.EXPAND, 5 )

		bSizer7 = wx.BoxSizer( wx.VERTICAL )

		self.m_button4 = wx.Button( self, wx.ID_ANY, u"Fermer", wx.DefaultPosition, wx.DefaultSize, 0 )
		self.m_button4.SetBackgroundColour( wx.Colour( 215, 0, 5 ) )

		bSizer7.Add( self.m_button4, 0, wx.ALL|wx.ALIGN_RIGHT, 5 )


		bSizer9.Add( bSizer7, 0, wx.EXPAND, 5 )


		self.SetSizer( bSizer9 )
		self.Layout()

		self.Centre( wx.BOTH )

		# Connect Events
		self.m_button5.Bind( wx.EVT_BUTTON, self.Button5click )
		self.m_button4.Bind( wx.EVT_BUTTON, self.Button4click )

	def __del__( self ):
		pass


	# Virtual event handlers, overide them in your derived class
	def Button5click( self, event ):
		event.Skip()

	def Button4click( self, event ):
		event.Skip()



