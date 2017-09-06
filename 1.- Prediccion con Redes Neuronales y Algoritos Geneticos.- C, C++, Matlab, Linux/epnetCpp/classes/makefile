#obsolete now, designed for a test
OBJS = testNetwork.o C_network.o
CC = g++
DEBUG = -g
CFLAGS = -Wall -c $(DEBUG)
LFLAGS = -Wall $(DEBUG)

testNetwork : $(OBJS)
	$(CC) $(LFLAGS) $(OBJS) -o testNetwork

testNetwork.o : C_network.hpp testNetwork.hpp testNetwork.cpp 
	$(CC) $(CFLAGS) testNetwork.cpp

C_network.o : C_network.hpp C_network.cpp
	$(CC) $(CFLAGS) C_network.cpp

clean:
	\rm *.o testNetwork
