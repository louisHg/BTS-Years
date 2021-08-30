from tkinter import Tk, StringVar, Label, Checkbutton
from functools import partial

def update_label(label, var):
    """
    Met à jour le texte d'un label en utilisant un BooleanVar.
    """
    text = var.get()
    label.config(text=text)


root = Tk()
is_red = StringVar(root, 'red')
label = Label(root, text=is_red.get())
checkbox = Checkbutton(root, variable=is_red, onvalue='red', offvalue='white', command=partial(update_label, label, is_red))

label.grid(row=0, column=0)
checkbox.grid(row=1, column=0)
root.mainloop()
