from tkinter import *
from functools import partial

def show_selection(label, choices, listbox):
    choices = choices.get()
    text = ""
    for index in listbox.curselection():
        text += choices[index] + " "

    label.config(text=text)

root = Tk()
choices = Variable(root, ('P2R-866', 'PJ2-445', 'P3X-974'))
listbox = Listbox(root, listvariable=choices, selectmode="multiple")
listbox.insert('end', 'P3X-972', 'P3X-888')
label = Label(root, text='')
button = Button(root, text='Ok', command=partial(show_selection, label, choices, listbox))

listbox.grid(row=0, column=0)
button.grid(row=1, column=0)
label.grid(row=2, column=0)
root.mainloop()
