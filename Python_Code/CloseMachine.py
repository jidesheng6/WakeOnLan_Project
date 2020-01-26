import socket
Clien_Soc = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
Clien_Soc.sendto(b"off",("192.168.3.224",7856))
