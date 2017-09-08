CFLAGS = -O -lm
LIBDIR = -L../epnetCpp/diehard
LIBS = -ldiehard


all: mainepnet


mainepnet: mainepnet.o
	g++ $(LIBDIR) $(LIBS) -o mainepnet mainepnet.o

mainepnet.o: mainepnet.cpp
	g++ $(CFLAGS) -c mainepnet.cpp

clean:
	rm -f mainepnet.o
	rm -f mainepnet
	
