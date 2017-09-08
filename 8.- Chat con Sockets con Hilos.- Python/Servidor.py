import socketserver
import threading
from tkinter import Tk, Label, Text, Scrollbar, Entry, mainloop
from tkinter.constants import DISABLED, VERTICAL, NS, END, NORMAL

class Controlador(socketserver.BaseRequestHandler):
    def construir(self):
        self.ventana = Tk()
        self.titulo = Label(self.ventana, text = "Chat Servidor_CarlosT", font="Verdana 15 bold")
        self.titulo.grid(row=0, column=0)
        
        self.textArea = Text(self.ventana, height =15, width =60)
        self.textArea.config(state=DISABLED)
        self.textArea.grid(row=1, column=0)
        
        self.scroll = Scrollbar(command=self.textArea.yview, orient=VERTICAL)
        self.scroll.grid(row=1, column=1, sticky=NS)
        self.textArea.configure(yscrollcommand=self.scroll.set)
        
        self.cajaTexto = Entry(self.ventana)        
        self.cajaTexto.bind('<Return>', self.eventoEnviar)
        self.cajaTexto.grid(row=2, column=0)

        
        mainloop()
        
    def eventoEnviar(self, datos):        
        try:
            datos = ""
            datos = "\nServidor:" +self.cajaTexto.get().strip()
            self.insertarTexto(datos)
            self.request.send(datos.encode(encoding='utf_8', errors='strict'))
            self.cajaTexto.delete(0, END)
            
        except:
            print("ERROR AL ENVIAR MENSAJE DESDE SERVIDOR")
            
    def insertarTexto(self, datos):
            self.textArea.config(state=NORMAL)
            self.textArea.insert(END, datos)
            self.textArea.config(state=DISABLED)
            
    def handle(self):
        threading.Thread(target = self.construir).start()
        try:
            while(True):
                self.insertarTexto(self.request.recv(1024).decode('utf_8'))
        
        except:
            print("ERROR AL RECIBIR MENSAJE DESDE CLIENTE")

host = "localhost"
puerto = 9999
servidor =socketserver.TCPServer((host, puerto), Controlador)
servidor.serve_forever()        
            
