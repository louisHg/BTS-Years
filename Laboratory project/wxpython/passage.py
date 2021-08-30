sizer = wx.BoxSizer(wx.VERTICAL)
# Third button is twice the size of the second button
sizer.Add(wx.Button(self, -1, 'An extremely long button text'), 0, 0, 0)
sizer.Add(wx.Button(self, -1, 'Small button'), 1, 0, 0)
sizer.Add(wx.Button(self, -1, 'Another button'), 2, 0, 0)
sizer.Add(wx.StaticText(self, -1, 'Nom :'), 0, wx.ALIGN_LEFT, 0)
sizer.SetSizeHints(self)
self.SetSizer(sizer)

