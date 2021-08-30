import wx

class TabPanel( wx.Panel ):
    
    def __init__( self, parent ):
        wx.Panel.__init__(self, parent=parent)
        
        

class DemoNotebookFrame( wx.Frame ):
    
    def __init__( self ):
        wx.Frame.__init__ ( self, None, id = wx.ID_ANY, title = u"Gestion laboratoire", size = wx.Size( 800,600 ))
        
        panel = wx.Panel(self)
        
        notebook = wx.Notebook(panel, style=wx.NB_LEFT)
        tab_one = TabPanel( notebook )
        notebook.AddPage(tab_one, 'Tab 1')
        
        tab_two = TabPanel(notebook)
        notebook.AddPage(tab_two, 'Tab 2')
        
        sizer = wx.BoxSizer(wx.VERTICAL)
        sizer.Add(notebook, 1, wx.ALL|wx.EXPAND, 5)
        panel.SetSizer(sizer)
        self.Show()
        
if __name__ == "__main__":
    app = wx.App()
    frame = DemoNotebookFrame()
    app.MainLoop()
