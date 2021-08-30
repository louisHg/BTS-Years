import wx

class MyFrame(wx.Frame):

	def __init__(self, parent, id, title):
		wx.Frame.__init__(self, parent, id, title)
		self.timer = wx.Timer(self, 1)
		self.count = 0
		self.Bind(wx.EVT_TIMER, self.OnTimer, self.timer)
		panel = wx.Panel(self, -1)
		self.gauge = wx.Gauge(panel, -1, 50, size=(250, 25))
		self.timer.Start(100)


	def OnTimer(self, event):
		self.count = self.count +1
		self.gauge.SetValue(self.count)

class MyApp(wx.App):
	def OnInit(self):
		frame = MyFrame(None, -1, 'gauge.py')
		frame.Show(True)
		return True

app = MyApp(0)
app.MainLoop()
