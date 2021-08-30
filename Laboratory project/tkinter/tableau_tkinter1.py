from tkinter import Label, Tk
root = Tk()
lab1 = Label(root, text='hello')
lab2 = Label(root, text='world')
lab1.grid(column=0, row=0)
lab2.grid(column=0, row=1)
root.mainloop()

