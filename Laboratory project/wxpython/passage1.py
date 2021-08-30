import wx

class MyDialog(wx.Dialog):

    def __init__(self, parent, id, title):

        wx.Dialog(parent, id, title, wx.DefaultPosition, wx.DefaultSize,
                  wx.DEFAULT_DIALOG_STYLE | wx.RESIZE_BORDER)

        topsizer = wx.BoxSizer(wx.VERTICAL)

        # create text ctrl with minimal size 100x60
        topsizer.Add(
                wx.TextCtrl(self, -1, "My text.", wx.DefaultPosition, wx.Size(100,60), wx.TE_MULTILINE),
                wx.SizerFlags(1).Align().Expand().Border(wx.ALL, 10))

        button_sizer = wx.BoxSizer(wx.HORIZONTAL)
        button_sizer.Add(
                wx.Button(self, wx.ID_OK, "OK"),
                wx.SizerFlags(0).Align().Border(wx.ALL, 10))

        button_sizer.Add(
                wx.Button(self, wx.ID_CANCEL, "Cancel"),
                wx.SizerFlags(0).Align().Border(wx.ALL, 10))

        topsizer.Add(
                button_sizer,
                wx.SizerFlags(0).Center())

        self.SetSizerAndFit(topsizer) # use the sizer for layout and set size and hints
