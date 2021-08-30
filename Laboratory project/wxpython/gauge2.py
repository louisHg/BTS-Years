import wx
import time

class MyPanel(wx.Panel):
    """
    class MyPanel creates a panel with a slider, button and a gauge (progress bar)
    this class inherits wx.Panel
    (putting your components/widgets on a panel increases versatility)
    """
    def __init__(self, parent, id):
        # create a panel
        wx.Panel.__init__(self, parent, id)
        self.SetBackgroundColour("white")

        # default id = -1 is used, initial value = 50, min value = 0, max value = 100
        self.slider1 = wx.Slider(self, -1, 50, 0, 100, (10, 10), (390, 50),
            wx.SL_HORIZONTAL | wx.SL_AUTOTICKS | wx.SL_LABELS)

        # default id = -1 is used, range is 0 to 100, default is horizontal style
        self.gauge1 = wx.Gauge(self, -1, 100, (10, 70), (390, 25))

        # set gauge to initial slider position
        self.pos1 = self.slider1.GetValue()
        self.gauge1.SetValue(self.pos1)

        str1 = "the gauge is bound to the slider, just click and drag the pointer"
        self.label1 = wx.StaticText(self, -1, str1, (10, 100))
        str2 = "the gauge can be driven with a timer loop"
        self.label2 = wx.StaticText(self, -1, str2, (10, 140))
        self.button1 = wx.Button(self, -1, "Press to start timer", (10, 170))

        # respond to changes in slider position ...
        self.slider1.Bind(wx.EVT_SLIDER, self.sliderUpdate)
        # respond to the click of the button
        self.button1.Bind(wx.EVT_BUTTON, self.button1Click)

    def sliderUpdate(self, event):
        # get the slider position
        self.pos1 = self.slider1.GetValue()
        # set the gauge position
        self.gauge1.SetValue(self.pos1)

    def button1Click(self, event):
        """starts a timed loop 0 to 100"""
        for k in range(101):
            # move the progress bar/gauge
            self.gauge1.SetValue(k)
            # move the slider too for the fun of it
            self.slider1.SetValue(k)
            # 0.015 second intervals
            time.sleep(0.015)


app = wx.PySimpleApp()
# create a window/frame, no parent, -1 is default ID, title, size
frame = wx.Frame(None, -1, "wxGauge Test1", size = (420, 310))
# call the derived class, -1 is default ID
MyPanel(frame,-1)
# show the frame
frame.Show(True)
# start the event loop
app.MainLoop()
