import socket
import threading
from tkinter import Tk, Label, Text, Scrollbar, Entry, mainloop
from tkinter.constants import DISABLED, VERTICAL, NORMAL, END, NS

ventana = Tk()
titulo = Label(ventana, text = "Chat Cliente_CarlosT", font="Verdana 15 bold")
textArea = Text(ventana, height =15, width=60)
scroll=Scrollbar(command=textArea.yview, orient=VERTICAL)
cajaTexto = Entry(ventana)

socket = socket.socket()
host = "localhost"
puerto = 9999
socket.connect((host, puerto))

def eventoEnviar(event):
    try:
        datos =""
        datos = "\nCliente: " + cajaTexto.get().strip()
        insertarTexto(datos)
        socket.send(datos.encode(encoding='utf_8', errors = "strict"))
        cajaTexto.delete(0, END)
        pass
    except:
        print("ERROR AL ENVIAR MENSAJE DESDE CLIENTE")
    
def insertarTexto(texto):
    textArea.config(state = NORMAL)
    textArea.insert(END, texto)
    textArea.config(state=DISABLED)
    
def recibirDatos():
    try:
        while(True):
            insertarTexto(socket.recv(1024).decode('utf_8'))
    except:
        print("ERROR AL RECIBIR MENSAJES DESDE SERVIDOR")
        
titulo.grid(row=0, column=0)
textArea.config(state=DISABLED)
textArea.grid(row=1, column=0)
scroll.grid(row=1, column=1, sticky=NS)

cajaTexto.bind('<Return>', eventoEnviar)
cajaTexto.grid(row=2, column=0)

threading.Thread(target=recibirDatos).start()
mainloop()
        
    