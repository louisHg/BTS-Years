from functools import partial
from tkinter import *

def update_label(label, text):
    """
    Modifie le texte d'un label.
    """
    label.config(text='OUI')

root = Tk()
label = Label(root, text='YO')
button = Button(root, text='clic', command=partial(update_label, label, text='Merci'))

label.grid(column=0, row=0)
button.grid(column=0, row=1)
root.mainloop()
