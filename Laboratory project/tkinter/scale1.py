from tkinter import IntVar, Tk, Scale, Entry

root = Tk()
value = IntVar(root)
scale = Scale(root, from_=4, to=16, showvalue=True, label='degres',
variable=value, tickinterval=4, orient='h')
entry = Entry(root, textvariable=value)

scale.grid(row=0, column=0)
entry.grid(row=0, column=1)

root.mainloop()
