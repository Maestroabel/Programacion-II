import os.path
from os import path

def Codificar():
    for linea in Lineas:
        
        columnas = linea.split(',')  
        fechayTiempo = columnas[0]

        try:
            Signo = fechayTiempo.index('-', 20)
            Signo = 1      
        except:
            Signo = 0      

        TempMinima = int(columnas[1])
        TempMaxima = int(columnas[2])
        Precipitacion = int(columnas[3])
        clima = (((TempMinima << 7) | TempMaxima) << 7) | Precipitacion

        fechayTiempo = fechayTiempo.replace('-', ' ')
        fechayTiempo = fechayTiempo.replace('T', ' ')       
        fechayTiempo = fechayTiempo.replace(':', ' ')
        fechayTiempo = fechayTiempo.replace('.', ' ')
        fechayTiempo = fechayTiempo.replace('+', ' ') 
        tiempo = fechayTiempo.split(' ')
        Tnumero = [int(i) for i in tiempo]
        
        tiempoBi = Tnumero[0] << 4
        tiempoBi = (tiempoBi | Tnumero[1]) << 5
        tiempoBi = (tiempoBi | Tnumero[2]) << 5
        tiempoBi = (tiempoBi | Tnumero[3]) << 6
        tiempoBi = (tiempoBi | Tnumero[4]) << 6
        tiempoBi = (tiempoBi | Tnumero[5]) << 10
        tiempoBi = (tiempoBi | Tnumero[6]) << 1
        tiempoBi = (tiempoBi | Signo) << 5
        tiempoBi = (tiempoBi | Tnumero[7]) << 6
        tiempoBi = (tiempoBi | Tnumero[8])

        Salida = open('Salida.csv', 'a')
        Entrada= open('Entrada.csv', 'r')
        Salida.write("\n{},{}".format(tiempoBi, clima))
        Salida.close()

        print("{},{}".format(tiempoBi, clima))
        Linea = Entrada.readline()
        print(linea)
#_________________________________________________________

Salida = open('Salida.csv', 'w')
Salida.write('DatoYtiempo,Clima')
Salida.close()
 
if (path.exists('Entrada.csv') == True):
    Entrada = open('Entrada.csv', 'r') 
    Lineas = Entrada.readlines()[1:]
    Codificar()
    Entrada.close()
else:
    Entrada = open('Entrada.csv', 'w') 
    Entrada.write("FechayTiempo,TempMinima,TempMaxima,Precipitacion")
    Entrada.write("\n2020-07-13T19:30:25.525-04:00,25,34,30")
    Entrada.write("\n2015-08-25T10:24:45.620-02:00,19,24,56")
    Entrada.write("\n1995-12-15T15:23:35.248+03:00,45,56,85")
    Entrada.write("\n2005-05-05T09:10:47.152+07:00,14,28,65")
    Entrada.write("\n2001-12-26T12:00:19.884-04:00,30,38,75")
    Entrada.close()
