import socket,binascii
mac = "3085A9997334"#这里填写自己机器的mac地址
magic_data = 'FF'*6 + mac *16
send_data = binascii.unhexlify(magic_data)
address='255.255.255.255'
port=9
s = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
s.setsockopt(socket.SOL_SOCKET,socket.SO_BROADCAST,1)
s.sendto(send_data,(address,port))

