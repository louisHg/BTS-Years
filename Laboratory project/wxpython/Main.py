import wx
import random
import threading
from rpi_ws281x import *

from LoginPanel import LoginPanel
from led import led
from MonThread import MonThread



class TabPanel(wx.Panel):
    #----------------------------------------------------------------------
    def __init__(self, parent):
        """"""
        #INIT  COLOR AND PAGE
        wx.Panel.__init__(self, parent=parent)
        
        colors = ["red", "blue", "gray", "yellow", "green"]
        self.SetBackgroundColour(random.choice(colors))
        
        
        #Define the sizer
        vbox_left = wx.BoxSizer(wx.VERTICAL)
        vbox_right = wx.BoxSizer(wx.VERTICAL)

        hbox = wx.BoxSizer(wx.HORIZONTAL)

        driveList=["D:/", "E:/"]

        font = wx.Font(14, wx.SWISS, wx.NORMAL, wx.NORMAL)

        label = wx.StaticText(self, -1, "Nom :",size=(380, 20)) # Add type/name of source
        label.SetFont(font)
        label.SetSize(label.GetBestSize()) #adapte the size
        self.combo1 = wx.ComboBox(self, style=wx.CB_DROPDOWN, choices=driveList)
        btn1 = wx.Button(self, label="Valider")      
        txt1 = wx.StaticText(self, label="Numéro :")
        case1 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        txt2 = wx.StaticText(self, label="Armoire :")   
        case2 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        txt3 = wx.StaticText(self, label="Etagère :")   
        case3 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        txt4 = wx.StaticText(self, label="Date de l'achat :")   
        case4 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        txt5 = wx.StaticText(self, label="Quantité actuelle :")   
        case5 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        #self.listbox = wx.ListBox(self, 1, size=(380, 220))
        
        
        vbox_left.Add(label, 0, wx.BOTTOM | wx.TOP | wx.ALIGN_CENTER_HORIZONTAL, 5) #fixe le nom :
        vbox_left.Add(self.combo1, 0, wx.EXPAND | wx.ALIGN_CENTER_HORIZONTAL | wx.LEFT | wx.RIGHT, 15) #combo : menu déroulant
        vbox_left.Add(btn1, 0, wx.EXPAND | wx.ALL, 25)
        vbox_left.Add(txt1, 0, wx.ALL, 0)
        vbox_left.Add( case1, 0, wx.EXPAND | wx.ALL, 5 )
        vbox_left.Add(txt2, 0, wx.ALL, 0)
        vbox_left.Add( case2, 0, wx.EXPAND | wx.ALL, 5 )
        vbox_left.Add(txt3, 0, wx.ALL, 0)
        vbox_left.Add( case3, 0, wx.EXPAND | wx.ALL, 5 )
        vbox_left.Add(txt4, 0, wx.ALL, 0)
        vbox_left.Add( case4, 0, wx.EXPAND | wx.ALL, 5 )
        vbox_left.Add(txt5, 0, wx.ALL, 0)
        vbox_left.Add( case5, 0, wx.EXPAND | wx.ALL, 5 )
        #vbox_left.Add(self.listbox, 1, wx.EXPAND | wx.LEFT | wx.RIGHT | wx.TOP, 15) #Liste blanche

        label = wx.StaticText(self, -1, "Reference :",size=(380, 20)) # Add disk name
        label.SetFont(font)
        label.SetSize(label.GetBestSize()) #adapte the size
        self.combo2 = wx.ComboBox(self, style=wx.CB_DROPDOWN, choices=driveList)
        label1 = wx.StaticText(self, -1, "",size=(0, 72))
        txt1 = wx.StaticText(self, label="Poids actuel :")
        case1 = wx.TextCtrl( self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0 )
        btn1 = wx.Button(self, label="Quantité prélevée")      
        
        
        vbox_right.Add(label, 0, wx.BOTTOM | wx.TOP | wx.ALIGN_CENTER_HORIZONTAL, 5) #fixe la référence :
        vbox_right.Add(self.combo2, 0, wx.EXPAND | wx.ALIGN_CENTER_HORIZONTAL | wx.LEFT | wx.RIGHT, 15)
        vbox_right.Add(label1, 0, wx.BOTTOM | wx.TOP | wx.ALIGN_CENTER_HORIZONTAL, 5)
        vbox_right.Add(txt1, 0, wx.BOTTOM | wx.TOP | wx.ALIGN_CENTER_HORIZONTAL, 0)
        vbox_right.Add( case1, 0, wx.EXPAND | wx.ALL, 6 )
        vbox_right.Add(btn1, 0, wx.EXPAND | wx.ALL, 25)
        
        
        hbox.Add(vbox_left, 0, wx.EXPAND | wx.LEFT, 20)   # Définit sur l'horizontalité une partie Gauche
        hbox.Add(vbox_right, 0, wx.EXPAND | wx.RIGHT, 20) # Et une partie Droite
        self.SetSizer(hbox)
        self.Layout()
        
        # Ligne 1
        
        
        """sizer = wx.BoxSizer(wx.VERTICAL)
        txt1 = wx.StaticText(self, label="Nom :")
        txt1.Wrap( -1 )
        txt1.SetFont( wx.Font( 12, 70, 90, 90, False, wx.EmptyString ) )
        Case1 = wx.TextCtrl(self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0)
        txt2 = wx.StaticText(self, label="Reference :")
        Case2 = wx.TextCtrl(self, wx.ID_ANY, wx.EmptyString, wx.DefaultPosition, wx.DefaultSize, 0)
        
        sizer.Add(txt1, 0, wx.LEFT, 0)
        sizer.Add(Case1, 0, wx.EXPAND, 0 )
        sizer.Add(txt2, 0, wx.LEFT, 0 )
        sizer.Add(Case2, 0, wx.EXPAND, 0 )
        btn = wx.Button(self, label="Press Me")
        sizer.Add(btn, 0, wx.BOTTOM, 10)
        self.SetSizer(sizer)"""
        
        # Ligne 2
        
        

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
        """sizer = wx.BoxSizer(wx.VERTICAL)
        sizer.Add(self.nb, 1, wx.ALL|wx.EXPAND, 5)
        self.SetSizer(sizer)"""
        
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
        
        self.bandeau = led()
        color = Color(255, 0, 255)
        i = 0
        while i<100:
            self.bandeau.select_led(i,color,100.0)
            i = i +1
        

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
